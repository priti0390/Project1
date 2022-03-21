using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using ChoETL;
using HeartFramework.BaseAPI;
using HeartFramework.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HeartFramework.Helpers
{
    public class Item
    {
        public string appPoolID;
        public string clientId;
        public string identityPoolID;
        public string Username;
        public string Password;
        public string AccessKey;
        public string SecretKey;
    }
    public class APIHelper : Settings_API
    {
        /// <summary>
        /// Method to set up URL including BaseURL and endpoint 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static void SetURL(string endpoint)
        {
            Settings_API.BaseURL = new Uri(Settings.AUT + endpoint);
            Settings_API.Endpoint = endpoint;
            ReportingHelpers.ChildTest.Pass("API URL: " + Settings_API.BaseURL);
        }

        /// <summary>
        /// Method to initialize bearer token related credentials
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void IntializingTokenCredentials(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                dynamic items = JsonConvert.DeserializeObject<Item>(json);
                Common.appPoolID = items.appPoolID;
                Common.clientId = items.clientId;
                Common.identityPoolID = items.identityPoolID;
                Common.username = items.Username;
                Common.password = CryptHelper.DecryptString(items.Password);
                Common.accesstoken = CryptHelper.DecryptString(items.AccessKey);
                Common.secrettoken = CryptHelper.DecryptString(items.SecretKey);
            }
        }

        /// <summary>
        /// Method to generate bearer token via cognito
        /// </summary>
        /// <returns>Tkn_ID</returns>
        public static string getTokenViaCognito(string appPoolID, string clientId, string identityPoolID, string username, string password, string accesskey, string secretkey)
        {
            int exp_flag = 0;
            string Tkn_Access = "";
            string Tkn_ID = "";
            string Tkn_Refresh = "";
            try
            {
                var newRegion = RegionEndpoint.GetBySystemName(appPoolID.ToString().Split('_')[0]);
                AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(accesskey, secretkey, newRegion);
                CognitoUserPool userPool = new CognitoUserPool(appPoolID, clientId, provider);
                CognitoUser user = new CognitoUser(username, clientId, userPool, provider);
                InitiateAdminNoSrpAuthRequest autRequest = new InitiateAdminNoSrpAuthRequest() { Password = password };
                var authresponse = user.StartWithAdminNoSrpAuthAsync(autRequest);
                Task.WaitAll(authresponse);
                Tkn_Access = authresponse.Result.AuthenticationResult.AccessToken;
                Tkn_Refresh = authresponse.Result.AuthenticationResult.RefreshToken;
                Tkn_ID = authresponse.Result.AuthenticationResult.IdToken;
            }
            catch (Exception e)
            {
                exp_flag = 1;
                if (e.Message.Contains("not authorized"))
                {
                    ReportingHelpers.ChildTest.Info("Please connect to cisco vpn anyconnect Secure Mobility Client");
                    ReportingHelpers.ChildTest.Fail("Exception has been thrown with message as->" + e.Message);
                    Common.expFlag = 1;
                }
            }
            if (exp_flag == 1)
            {
                return null;
            }
            else
            {
                ReportingHelpers.ChildTest.Info("App Pool ID->" + appPoolID);
                ReportingHelpers.ChildTest.Info("Client Id->" + clientId);
                ReportingHelpers.ChildTest.Info("Identity PoolID->" + identityPoolID);
                LogHelpers.info("username->" + username);
                LogHelpers.info("accesskey->" + accesskey);
                LogHelpers.info("secretkey->" + secretkey);
                return Tkn_ID;
            }
        }

        /// <summary>
        /// Method to authenticate any service based on authentication type
        /// </summary>
        /// <param name="auth_type"></param>
        /// <returns></returns>
        public static void authenticatingRequest(string auth_type)
        {
            switch (auth_type)
            {
                case "Basic Auth":
                    Dictionary<String, String> dataEx1 = ExcelHelpers.getRowData(1, "Accounts");
                    Basic_Auth(dataEx1["Username"], CryptHelper.DecryptString(dataEx1["Password"]));
                    break;
                case "API Key":
                //yet to implement
                case "OAuth2.0":
                    OAuth2(dataEx["AccessToken"]);
                    break;
                case "Bearer Token":
                    if (Common.TokenFlag == true)
                    {
                        bearerToken(Common.Token_Id);
                    }
                    else
                    {
                        ReportingHelpers.ChildTest.Fail("Token got expired with token id->" + Common.Token_Id);
                    }
                    break;
                case "":
                    break;
            }
        }

        /// <summary>
        /// Method to execute rest request of T type
        /// </summary>
        /// <param name="restRequest"></param>
        /// <returns>IRestResponse<List<T>></returns>
        public static IRestResponse<List<T>> executeRestrequest<T>(IRestRequest restRequest) where T : new()
        {
            IRestResponse<List<T>> restres = Settings_API.restclient.Execute<List<T>>(restRequest);
            return restres;
        }

        /// <summary>
        /// Method to store values to be deleted
        /// </summary>
        /// <param name="content"></param>,<param name="del_param"></param>
        /// <returns>Common.param_delreq</returns>

        public static string storeDeleteparam(dynamic content, string del_param)
        {
            int exp_flag = 0;
            try
            {
                JObject obj = JObject.Parse(content);
                Common.param_delreq = (string)obj["data"][del_param];
            }
            catch (Exception e)
            {
                exp_flag = 1;
                ReportingHelpers.ChildTest.Fail(e.Message.ToString() + Environment.NewLine);
            }
            return Common.param_delreq;
        }

        /// <summary>
        ///Method to deserialize the response
        /// </summary>
        /// <param name="IRestResponse"></param>
        /// <returns>deserialized_json</returns>
        public static dynamic deserializeJson(IRestResponse resp)
        {
            int exp_flag = 0;
            var deserialized_json = string.Empty;
            try
            {
                deserialized_json = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(resp.Content));
            }
            catch(Exception e)
            {
                exp_flag = 1;
            }
            if (exp_flag == 1)
            {
                return "";
            }
            else
            {
                return deserialized_json;
            }
        }

        /// <summary>
        ///Method to handle multiple get requests
        /// </summary>
        /// <param name=""></param>
        /// <returns><Multiple Json responses</returns>

        public static dynamic getRequestMultiple<T>(string endpoint, string param = "", string auth_type = "", dynamic[] id = null) where T : new()
        {
            for (int i=0;i<id.Length;i++)
            {
                Common.id = id[i];
                Common.jsonObjMultiple[i] = getRequest<T>(endpoint, param, auth_type,id[i]);
                Settings_API.restRequestMultiple[i] = Settings_API.restRequest;
                Settings_API.responseMultiple[i] = Settings_API.response1;
            }
            return Common.jsonObjMultiple;
        }


        /// <summary>
        ///Method to handle get request
        /// </summary>
        /// <param name=""></param>
        /// <returns>Json response</returns>
        public static dynamic getRequest<T>(string endpoint, string param = "", string auth_type = "", string id = "") where T : new()
        {
            setupTLSSecurity();
            dynamic jsonOutput;
            JObject json = null;
            if (id != "")
                Common.id = id;
            authenticatingRequest(auth_type);
            if (id == "" || id == null || endpoint.Contains(Common.id))
            {
                InitializeRestRequest(endpoint, Method.GET);
            }
            else
            {
                InitializeRestRequest(endpoint + "/" + Common.id, Method.GET);
            }
            addParameterGet(param);
            Settings_API.response1 = executeRestrequest<T>(Settings_API.restRequest);
            if ((int)Settings_API.response1.StatusCode != Statuscode.NOT_FOUND)
            {
                jsonOutput = deserializeJson(Settings_API.response1);
                try
                {
                    json = JObject.Parse(jsonOutput);
                }
                catch (Exception e)
                {
                    ReportingHelpers.ChildTest.Info(e.Message);
                }
                if(id!="")
                    ReportingHelpers.ChildTest.Pass("I performed get Request against id: " + id + " to validate the response");
            }
            Common.jsonPayload = json;
            //Common.jsonObj = json.ToString();
            return json;
        }



        /// <summary>
        /// Validate parameters passed in response like filter, sort, pagination, etc
        /// </summary>
        /// <param name="Parameter_type"></param>
        /// <param name="Field"></param>

        public void validateParametersInGetResponse(string Parameter_type, string Field)
        {
            string ExpectedParameter = null;
            bool ExpectedBoolParameter = false;

            if (Common.jsonPayload.ToString().Contains(Parameter_type))
            {
                if (Common.jsonPayload.SelectToken(Parameter_type) == null)
                {
                    if (Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).Type != null)
                    {
                        if (Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).Type.ToString().Equals("Boolean"))
                        {
                          ExpectedBoolParameter = System.Convert.ChangeType(Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).ToString(), typeof(Boolean));
                        }
                    }
                    else ExpectedParameter = System.Convert.ChangeType(Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).ToString(), typeof(string));
                }

                else if ((Common.jsonPayload.SelectToken(Parameter_type).Equals(null)) || (Common.jsonPayload.SelectToken(Parameter_type).Equals("")))
                {
                    if (!(Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).Type.ToString().Equals("Boolean")))
                    {
                        ExpectedParameter = System.Convert.ChangeType(Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).ToString(), typeof(string));
                    }
                    else ExpectedBoolParameter = System.Convert.ChangeType(Common.jsonPayload.SelectToken("data").SelectToken(Parameter_type).ToString(), typeof(Boolean));
                }
                else
                {
                    ExpectedParameter = System.Convert.ChangeType(Common.jsonPayload.SelectToken(Parameter_type).ToString(), typeof(string));
                }

                if (ExpectedParameter == null || ExpectedParameter == "")
                {
                    if (ExpectedBoolParameter.Equals(bool.Parse(Field)))
                    {
                        ReportingHelpers.ChildTest.Pass(Parameter_type + " attribute in response is correct. i.e." + Parameter_type + " : " + Field);
                    }
                    else ReportingHelpers.ChildTest.Fail(Parameter_type + " attribute in response is not correct. Expected : " + Field + " Actual : " + ExpectedBoolParameter);

                }

                else
                {
                    if (!(ExpectedParameter.Contains(Field)))
                    {
                        ReportingHelpers.ChildTest.Fail(Parameter_type + " attribute in response is not correct. Expected : " + Field + " Actual : " + ExpectedParameter);
                    }

                    else ReportingHelpers.ChildTest.Pass(Parameter_type + " attribute in response is correct. i.e." + Parameter_type + " : " + ExpectedParameter);
                }
            }
        }

        /// <summary>
        /// Validate Sorting in Get Response
        /// </summary>
        /// <param name="Field"></param>
        public void getSort(string Field)
        {

            validateParametersInGetResponse("sort", Field);

            List<string> ResponseId = new List<string>() { };
            List<string> SortedResponseId = new List<string>();
            int count = Common.jsonPayload.SelectToken("data").Count;

            for (int i = 0; i < count; i++)
            {

                SortedResponseId.Add(System.Convert.ChangeType(Common.jsonPayload.SelectToken("data")[i].SelectToken(Field).ToString(), typeof(string)));
            }
            ResponseId = SortedResponseId;
            SortedResponseId.Sort();

            if (SortedResponseId.SequenceEqual(ResponseId))
                ReportingHelpers.ChildTest.Pass("Response is sorted with field : " + Field);

            else ReportingHelpers.ChildTest.Fail("Response is not sorted for field : " + Field);
        }

        /// <summary>
        /// Validate Filtering in Get Request - Validates filter attribute and checks if any record with different value than provided is present
        /// </summary>
        /// <param name="Field"></param>

        public void getFilter(string Field)
        {
            validateParametersInGetResponse("filters", Field);

            int count = Common.jsonPayload.SelectToken("data").Count;
            int notFiltered = 0;

            for (int i = 0; i < count; i++)
            {
                if (!(System.Convert.ChangeType(Common.jsonPayload.SelectToken("data")[i].SelectToken(Field).ToString(), typeof(string))).Equals(Common.keyword_Param_val))
                {
                    notFiltered++;
                }
            }
            if (notFiltered != 0)
                ReportingHelpers.ChildTest.Fail("Response is not filtered for field : " + Field);
            else ReportingHelpers.ChildTest.Pass("Response is filtered for field : " + Field);


        }

        public static void validateStatusCodePostas204()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.NO_CONTENT))
            {
                ReportingHelpers.ChildTest.Pass("Validated Status code for Post Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validate status code for Post Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
                Common.expFlag = 1;
            }
        }


        /// <summary>
        /// Validate Pagination in Get Request - validates the pagination -> page size attribute in response as well as no.of Records in the response
        /// </summary>
        /// <param name="Field"></param>

        public void getPagination(string Field)
        {
            validateParametersInGetResponse("pagination", Field);


            if (Common.jsonPayload.SelectToken("data").Count == Convert.ToInt32(Common.keyword_Param_val))
            {
                ReportingHelpers.ChildTest.Pass("Pagination[" + Field + "] is correct. Expected and actual" + Field + " is : " + Common.keyword_Param_val);
            }

            else ReportingHelpers.ChildTest.Fail("Pagination with " + Field + " is not correct. Expected value is : " + Common.keyword_Param_val + "Actual Value is : " + Common.jsonPayload.SelectToken("data").Count);

        }

        /// <summary>
        ///Method to handle multiple post requests
        /// </summary>
        /// <param name=""></param>
        /// <returns>Json response</returns>

        public static dynamic postMultipleRequests<T>(string endpoint, dynamic[] payload, string auth_type = "") where T : new()
        {
            Common.idArray = new dynamic[payload.Length];
            Settings_API.restRequestMultiple = new dynamic[payload.Length];
            Settings_API.responseMultiple = new dynamic[payload.Length];
            dynamic[] classNameTokens = new dynamic[payload.Length];
            for (int i = 0; i < payload.Length; i++)
            {
                Common.idArray[i] = postRequest<T>(endpoint, payload[i].ToString(), auth_type);
                Settings_API.restRequestMultiple[i] = Settings_API.restRequest;
                Settings_API.responseMultiple[i] = Settings_API.response1;
            }
            return Common.idArray;
        }
        /// <summary>
        ///Method to handle post request
        /// </summary>
        /// <param name=""></param>
        /// <returns>Json response</returns>

        public static dynamic postRequest<T>(string endpoint, string payload, string auth_type = "", string filename = "", string id = "") where T : new()
        {
            if (id == "" || id == null || endpoint.Contains(Common.id))
            {
                InitializeRestRequest(endpoint, Method.POST);
            }
            else
            {
                InitializeRestRequest(endpoint + "/" + Common.id, Method.POST);
            }

            LogHelpers.info("Json payload is :" + payload);
            if (auth_type.Equals(Common.auth_OAuth2))
            {
                Settings_API.restRequest.AddBody(payload);
                Settings_API.restRequest.AddHeader(Common.keyword_contentType, Common.ContentType);
                Settings_API.restRequest.RequestFormat = DataFormat.Json;
            }
            else
            {
                addParameterPost(Common.ContentutfType, payload);
            }
            if (filename != "")
            {
                Settings_API.restRequest.AddParameter(Common.keyword_contentType, Common.ContentTypeMultiPartFormData);
                Settings_API.restRequest.AddFile(Common.File, filename);
            }
            setJsonFormat();
            authenticatingRequest(auth_type);
            setupTLSSecurity();
            Settings_API.response1 = executeRestrequest<T>(Settings_API.restRequest);
            var jsonOutput = deserializeJson(Settings_API.response1);
            if (!(jsonOutput == "" || jsonOutput == null))
            {
                var userObj = JObject.Parse(jsonOutput);
                if (userObj[Common.constData] != null)
                {
                    if (userObj[Common.constData]["hrn"] != null)
                        Common.id = Convert.ToString(userObj[Common.constData]["hrn"]);
                }
                else
                {
                    if (userObj["hrn"] != null)
                        Common.id = Convert.ToString(userObj["hrn"]);
                    else
                        Common.subId = Convert.ToString(userObj["id"]);
                }

            }
            //updateCache("hrn",Common.id);
            //string s=readCache("hrn");
            //Common.id = jsonOutput;
            return Common.id;
        }


        /// <summary>
        ///Method to update value under cache.json
        /// </summary>
        public static void updateCache(dynamic key, dynamic value)
        {
            IDictionary<string, dynamic> d = new Dictionary<string, dynamic>();
            d.Add(new KeyValuePair<string, dynamic>(key, value));
            string filename = Environment.CurrentDirectory.ToString() + "\\Data\\Cache.json";
            using (StreamWriter file = File.CreateText(filename))
            //using (StreamWriter file = File.CreateText(@"C:\\Azure\\QA_HeartFramework_API\\Heart\\HeartTest\\Data\\Cache.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, d);
            }
        }


        /// <summary>
        ///Method to read value from cache.json
        /// </summary>
        /// 
        public static dynamic readCache(string key)
        {
            using (StreamReader r = new StreamReader(@"C:\\Azure\\QA_HeartFramework_API\\Heart\\HeartTest\\Data\\Cache.json"))
            {
                string json = r.ReadToEnd();
                JObject obj = JObject.Parse(json);
                return obj["hrn"];
            }
        }
        /// <summary>
        ///Method to add header say tenant ID
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static void addHeaders(string header)
        {
            if (!(header == null | header == ""))
                Settings_API.restRequest.AddHeader(Common.keyword_header, Common.keyword_header_val);
        }


        /// <summary>
        ///Method to handle multiple put request
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static dynamic putRequestMultiple<T>(string endpoint, dynamic[] payload, string auth_type = "") where T : new()
        {
            for (int i = 0; i < Common.jsonObjMultiple.Length; i++)
            {
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                Common.id = Common.idArray[i];
                putRequest<T>(endpoint, JObject.Parse(Common.jsonObjMultiple[i]).SelectToken(Common.constData).ToString(), auth_type);
                Settings_API.restRequestMultiple[i] = Settings_API.restRequest;
                Settings_API.responseMultiple[i] = Settings_API.response1;
            }
            return Common.jsonObjMultiple;
        }
        /// <summary>
        ///Method to handle put request
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static dynamic putRequest<T>(string endpoint, string payload, string auth_type = "") where T : new()
        {
            InitializeRestRequest(endpoint + "/" + Common.id, Method.PUT);
            authenticatingRequest(auth_type);
            setJsonFormat();
            setupTLSSecurity();
            Settings_API.restRequest.AddBody(payload);
            LogHelpers.info("Json payload is :" + payload);
            addParameterPost(Common.ContentutfType, payload);
            Settings_API.restclient.Execute(Settings_API.restRequest);
            Settings_API.response1 = executeRestrequest<T>(Settings_API.restRequest);
            var tcs = new TaskCompletionSource<bool>();

            var asyncHandler = Settings_API.restclient.ExecuteAsync<T>(Settings_API.restRequest, (response) =>
            {
                tcs.SetResult(Settings_API.response1.ResponseStatus == ResponseStatus.Completed);
            });
            var jsonOutput = deserializeJson(Settings_API.response1);
            return jsonOutput;
        }

        /// <summary>
        ///Method to handle multiple patch request
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static dynamic patchRequestMultiple<T>(string endpoint, dynamic[] payload, string auth_type = "") where T : new()
        {
            for (int i = 0; i < Common.jsonObjMultiple.Length; i++)
            {
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                Common.id = Common.idArray[i];
                patchRequest<T>(endpoint, Common.jsonObjMultiple[i].ToString(), auth_type);
                Settings_API.restRequestMultiple[i] = Settings_API.restRequest;
                Settings_API.responseMultiple[i] = Settings_API.response1;
            }
            return Common.jsonObjMultiple;
        }

        /// <summary>
        ///Method to handle patch request
        /// </summary>
        /// <param name=""></param>
        /// <returns>jsonOutput</returns>
        public static dynamic patchRequest<T>(string endpoint, string payload, string auth_type = "") where T : new()
        {
            try
            {
                InitializeRestRequest(endpoint + "/" + Common.id, Method.PATCH);
                authenticatingRequest(auth_type);
                setJsonFormat();
                setupTLSSecurity();
                Settings_API.restRequest.AddBody(payload);
                LogHelpers.info("Json payload is :" + payload);
                addParameterPost(Common.ContentutfType, payload);
                Settings_API.restclient.Execute(Settings_API.restRequest);
                Settings_API.response1 = executeRestrequest<T>(Settings_API.restRequest);
            }
            catch (Exception e)
            {
                Common.expFlag = 1;
            }
            var jsonOutput = deserializeJson(Settings_API.response1);
            return jsonOutput;
        }

        /// <summary>
        ///Method to handle multiple delete request
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static void deleteRequestMultiple<T>(string endpoint, Table table, string auth_type = "") where T : new()
        {
            Table t = new Table((string[])table.Header);
            Settings_API.restRequestMultiple = new dynamic[table.Rows.Count];
            Settings_API.responseMultiple = new dynamic[table.Rows.Count];
            dynamic[] paramvalMultiple = new dynamic[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                t.AddRow(table.Rows[i]);
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                deleteRequest<T>(endpoint, t.ToString(), auth_type);
                Settings_API.restRequestMultiple[i] = Settings_API.restRequest;
                Settings_API.responseMultiple[i] = Settings_API.response1;
                t = new Table((string[])table.Header);
            }
        }

        /// <summary>
        ///Method to generate query parameter for the request
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        public static string queryParameter(string endpoint, dynamic parameter_val)
        {
            string s = endpoint;
            if (s.Contains("{") && s.Contains("}"))
            {
                int startbrace_index = s.IndexOf('{');
                int endbrace_index = s.IndexOf('}');
                s = s.Remove(startbrace_index, endbrace_index - startbrace_index + 1).Insert(startbrace_index, Convert.ToString(parameter_val));
            }
            else
            {
                //ReportingHelpers.ChildTest.Fail("braces { or } doesn't exist against endpoint, actual endpoint is: "+s);
            }
            return s;
        }



        /// <summary>
        ///Method to handle delete request for the service
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static void deleteRequest<T>(string endpoint, string param_val = "", string auth_type = "") where T : new()
        {
            if (param_val == "")
            {
                InitializeRestRequest(endpoint, Method.DELETE);
            }
            else
            {
                InitializeRestRequest(endpoint + "/" + param_val, Method.DELETE);
            }
            setJsonFormat();
            authenticatingRequest(auth_type);
            setupTLSSecurity();
            Settings_API.response1 = executeRestrequest<T>(Settings_API.restRequest);
            if (((int)Settings_API.response1.StatusCode).Equals(Statuscode.NO_CONTENT))
            {
                if (param_val != "")
                {
                    Common.id = param_val;
                }
                Common.delete_flag = true;
                ReportingHelpers.ChildTest.Pass("Records got deleted successfully against id -> " + Common.subId + " with status code as ->" + (int)Settings_API.response1.StatusCode);
            }
            else
            {
                if (param_val != "")
                {
                    Common.id = param_val;
                }
                Common.delete_flag = false;
                ReportingHelpers.ChildTest.Fail("Failed to delete records against id -> " + Common.subId + " with status code as ->" + (int)Settings_API.response1.StatusCode);
            }
        }

        /// <summary>
        ///Method to add the header
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static void addHeader()
        {
            Settings_API.restRequest.AddHeader(Common.keyword_accept, Common.ContentType);
        }

        /// <summary>
        ///Method to set up the json format
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static void setJsonFormat()
        {
            Settings_API.restRequest.RequestFormat = DataFormat.Json;
        }

        /// <summary>
        ///Method to authenticate using basic authorization
        /// </summary>
        /// <param name="username"></param><param name="password"></param>
        /// <returns></returns>

        public static void Basic_Auth(string username, string password)
        {
            Settings_API.restclient.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        /// <summary>
        ///Method to authenticate using OAUth2.0
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <returns></returns>

        public static void OAuth2(string accesstoken)
        {
            Settings_API.restRequest.AddHeader(Common.keyword_Authorization, Common.keyword_Bearer + " " + accesstoken);
        }

        /// <summary>
        ///Method to authenticate using JWT Token
        /// </summary>
        /// <param name="JWToken"></param>
        /// <returns></returns>

        public static void bearerToken(string JWToken)
        {
            Settings_API.restclient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(JWToken, "Bearer");
            if (Common.Auth_Message == false)
            {
                Common.Auth_Message = true;
                ReportingHelpers.ChildTest.Pass("API got authenticated through valid Token with token id. Please refer to to log to get exact JWT Token ID");
                LogHelpers.info("API got authenticated through valid Token with token id: " + JWToken);
            }
        }

        /// <summary>
        ///Method to check the validity of the token
        /// </summary>
        /// <param name="token"></param>
        /// <returns>bool</returns>

        public static bool _isEmptyOrInvalidToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                ReportingHelpers.ChildTest.Fail("JWT Token ID is : Null");
                return false;
            }
            var jwtToken = new JwtSecurityToken(token);
            ReportingHelpers.ChildTest.Pass("Time Zone->" + TimeZoneInfo.Local.DisplayName);
            var expiry_date = TimeZoneInfo.ConvertTimeFromUtc(jwtToken.ValidTo, TimeZoneInfo.Local);
            var curr_time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);

            if (expiry_date > curr_time)
            {
                ReportingHelpers.ChildTest.Pass("Valid Token having Token ID available in the log");
                ReportingHelpers.ChildTest.Pass("Expiry Date for Token-> " + expiry_date);
                ReportingHelpers.ChildTest.Pass("Current Date for Token-> " + curr_time);
                return true;
            }
            else
            {
                Common.itr = Common.itr + 1;
                ReportingHelpers.ChildTest.Fail("In-Valid Token having Token ID available in the log");
                ReportingHelpers.ChildTest.Fail("Expiry Date for Token -> " + expiry_date);
                ReportingHelpers.ChildTest.Fail("Current Date for Token -> " + curr_time);
                ReportingHelpers.ChildTest.Info("Generating New Token");
                if (Common.itr <= 5)
                {
                    Common.Token_Id = APIHelper.getTokenViaCognito(Common.appPoolID, Common.clientId, Common.identityPoolID, Common.username, Common.password, Common.accesstoken, Common.secrettoken);
                    _isEmptyOrInvalidToken(Common.Token_Id);
                    return true;
                }
                else
                {
                    ReportingHelpers.ChildTest.Fail("Valid token is not getting generated even after five attempts, check the logs");
                    return false;
                }
            }
        }

        /// <summary>
        ///Method to initialize rest request
        /// </summary>
        /// <param name="endpoint"></param><param name="method"></param>
        /// <returns></returns>

        public static void InitializeRestRequest(string endpoint, Method method)
        {
            Settings_API.restRequest = new RestRequest(endpoint, method);
        }

        /// <summary>
        ///Method to Get Json Content
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>

        public static dynamic getJsonContent(IRestResponse response)
        {
            return response.Content;
        }

        /// <summary>
        ///Method to set up TLS Setting for service connection
        /// </summary>
        public static void setupTLSSecurity()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        /// <summary>
        ///Method to add paramter with Post request
        /// </summary>
        public static void addParameterPost(string ContentutfType, string payload)
        {
            Settings_API.restRequest.AddParameter(ContentutfType, payload, ParameterType.RequestBody);
        }


        public static void addParameterGet(string Param)
        {
            if (!(Param == null | Param == ""))
                Settings_API.restRequest.AddQueryParameter(Param, Common.keyword_Param_val);
        }


        /// <summary>
        ///Method to validate status code for delete request
        /// </summary>
        public static void validateStatusCodeDelete()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.NOT_FOUND) && Common.delete_flag == true)
            {
                ReportingHelpers.ChildTest.Pass("Validated Status code for Delete Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NOT_FOUND);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to delete record <br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NOT_FOUND);
                ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content);
                Common.expFlag = 1;
            }
        }

        /// <summary>
        ///Method to validate status code for mutliple Get request
        /// </summary>
        public static void validateStatusCodeGetMultiple()
        {
            for (int i = 0; i < Settings_API.responseMultiple.Length; i++)
            {
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                validateStatusCodeGet();
            }
        }

        /// <summary>
        ///Method to validate status code for get request
        /// </summary>
        public static void validateStatusCodeGet()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.OK))
            {
                ReportingHelpers.ChildTest.Pass("Validated Status code for Get Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.OK);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validate Status code for Get Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.OK);
                ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content);
                Common.expFlag = 1;
            }
        }

        public static void validateStatusCodeDeleteas204()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.NO_CONTENT))
            {
                ReportingHelpers.ChildTest.Pass("Validated Status code for Get Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validate Status code for Get Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
                ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content);
                Common.expFlag = 1;
            }
        }

        /// <summary>
        ///Method to validate status code for mutliple Put request
        /// </summary>
        public static void validateStatusCodePostMultiple()
        {
            for (int i = 0; i < Settings_API.responseMultiple.Length; i++)
            {
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                validateStatusCodePost();
            }
        }

        /// <summary>
        ///Method to validate status code for post request
        /// </summary>
        public static void validateStatusCodePost()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.CREATED))
                ReportingHelpers.ChildTest.Pass("Validated Status code for Post Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.CREATED);
            else if (statuscode.Equals((int)Statuscode.OK))
                ReportingHelpers.ChildTest.Fail("Validated Status code for Post Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.OK);
            else if (statuscode.Equals((int)Statuscode.NO_CONTENT))
                ReportingHelpers.ChildTest.Fail("Validated Status code for Post Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validate status code for Post Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.CREATED);
                ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content);
                Common.expFlag = 1;
            }
        }


        /// <summary>
        ///Method to validate status code for mutliple put request
        /// </summary>
        public static void validateStatusCodePutMultiple()
        {
            for (int i = 0; i < Settings_API.responseMultiple.Length; i++)
            {
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                ReportingHelpers.ChildTest.Pass("Validated Status code against ID: " + Common.idArray[i] + "<br>");
                validateStatusCodePut();
            }
        }


        /// <summary>
        ///Method to validate status code for put request
        /// </summary>
        public static void validateStatusCodePut()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.NO_CONTENT))
                ReportingHelpers.ChildTest.Pass("Status code for Put Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
            else if (statuscode.Equals((int)Statuscode.CREATED))
                ReportingHelpers.ChildTest.Pass("Status code for Put Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.CREATED);
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validated Status code for Put Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
                ReportingHelpers.ChildTest.Info("Error Message is : " + Settings_API.response1.Content);
                Common.expFlag = 1;
            }
        }

        /// <summary>
        ///Method to validate status code for mutliple Patch request
        /// </summary>
        public static void validateStatusCodePatchMultiple()
        {
            for (int i = 0; i < Settings_API.responseMultiple.Length; i++)
            {
                Settings_API.restRequest = Settings_API.restRequestMultiple[i];
                Settings_API.response1 = Settings_API.responseMultiple[i];
                ReportingHelpers.ChildTest.Pass("Validated Status code against ID: " + Common.idArray[i] + "<br>");
                validateStatusCodePatch();
            }
        }

        /// <summary>
        ///Method to validate status code for patch request
        /// </summary>
        public static void validateStatusCodePatch()
        {
            int statuscode = (int)Settings_API.response1.StatusCode;
            if (statuscode.Equals((int)Statuscode.NO_CONTENT))
            {
                ReportingHelpers.ChildTest.Pass("Status code for above Patch Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validate status code for above Patch Request<br>Actual Status Code: " + statuscode + "<br>Expected Status code:  " + (int)Statuscode.NO_CONTENT);
                ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content);
                Common.expFlag = 1;
            }
        }


        /// <summary>
        ///Method to validate error message after Post
        /// </summary>
        public static void ValidateExpectedError(dynamic id, int expStatusCode, string errMsg)
        {
            try
            {
                if ((int)Settings_API.response1.StatusCode == expStatusCode)
                {
                    ReportingHelpers.ChildTest.Pass("Actual Status Code is correct as expected which is : " + (int)Settings_API.response1.StatusCode);

                    string RespErr = Settings_API.response1.Content.Replace("\\u0027", "");
                    if (RespErr.Trim().Contains(errMsg))
                        ReportingHelpers.ChildTest.Pass("Actual error message is correct as expected which is : " + errMsg);

                    else ReportingHelpers.ChildTest.Fail("Actual error message is not as expected. Actual error " + RespErr + " should contain expected error which is : " + errMsg);

                }

                else
                {
                    ReportingHelpers.ChildTest.Fail("Actual status code is not as expected. Expected Status Code is : " + expStatusCode + " and Actual Status Code is : " + (int)Settings_API.response1.StatusCode);
                    ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content.Replace("\\u0027", ""));
                }
            }
            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Fail("Exception has been thrown with message as ->" + e.Message);
            }

        }


        /// <summary>
        ///Method to validate schema attribute for payload and responses
        /// </summary>
        /// <param name="payload"</param><param name="filename"</param>
        /// <returns>bool</returns>
        public static bool ValidateSchemaAttributes(string payload, string filename)
        {
            int pass = 0;
            string schemaJson = File.ReadAllText(Environment.CurrentDirectory.ToString() + Settings.jsonfilepath + filename);
            JsonSchema schema = JsonSchema.Parse(schemaJson);
            JObject person = JObject.Parse(payload);
            foreach (var item in person)
            {

                if (item.Key.Equals("data"))
                {
                    foreach (dynamic j in person[item.Key])
                    {
                        string actual_type = schema.Properties[item.Key].Properties[j.Name].Type.ToString();
                        string expected_type = person.SelectToken(item.Key).SelectToken(j.Name).Type.ToString();

                        if (actual_type.Contains(expected_type))
                        {
                            ReportingHelpers.ChildTest.Pass("Validated schema for " + j.Name + " <br>actual : " + actual_type + "<br> expected: " + expected_type);
                            pass = pass + 1;
                        }
                        else
                        {
                            ReportingHelpers.ChildTest.Fail("Failed to validated schema for " + j.Name + "<br> actual : " + actual_type + "<br> expected: " + expected_type);
                        }
                    }
                }
                else
                {
                    if (schema.Properties["data"].Properties[item.Key].Type.ToString().Contains(person.SelectToken(item.Key).Type.ToString()))
                    {
                        pass = pass + 1;

                        ReportingHelpers.ChildTest.Pass("Validated schema for " + item.Key + "<br> actual : " + schema.Properties["data"].Properties[item.Key].Type.ToString() + "<br> expected: " + person.SelectToken(item.Key).Type);
                    }
                    else
                    {
                        ReportingHelpers.ChildTest.Fail("Failed to validate schema for " + item.Key + "<br> actual : " + schema.Properties["data"].Properties[item.Key].Type.ToString() + "<br> expected: " + person.SelectToken(item.Key).Type);
                    }
                }
            }
            if (pass == person.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///Method to retrieve multiple values from json objects
        /// </summary>
        /// <param name="key"</param><param name="jsonobj"</param>
        /// <returns>classNameTokens</returns>

        public static dynamic GetJObjectMultipleValues(string key, dynamic[] jsonobj)
        {
            dynamic[] classNameTokens = new dynamic[jsonobj.Length];
            for (int i = 0; i < jsonobj.Length; i++)
            {
                classNameTokens[i] = GetJObjectValue(key, jsonobj[i].ToString());
            }
            return classNameTokens;
        }


        /// <summary>
        ///Method to retrieve value from json object
        /// </summary>
        /// <param name="key"</param><param name="jsonobj"</param>
        /// <returns>classNameTokens</returns>
        public static dynamic GetJObjectValue(string key, string jsonobj)
        {
            JToken tStr = null;
            dynamic classNameTokens = null;
            JObject jObject = JObject.Parse(jsonobj);
            if (key.Contains("/"))
            {
                int slashCnt = key.Count(f => f == '/');
                for (int counter = 0; counter <= slashCnt; counter++)
                {
                    if (tStr == null)
                    {
                        if (Regex.IsMatch(key.ToString().Split('/')[counter], @"^\d+$"))
                        {
                            tStr = tStr[Int32.Parse(key.ToString().Split('/')[counter])];
                        }
                        else
                        {
                            if (jObject.SelectToken(Common.constData) == null)
                                tStr = jObject.SelectToken(key.ToString().Split('/')[counter]);
                            else
                                tStr = jObject.SelectToken(Common.constData).SelectToken(key.ToString().Split('/')[counter]);
                        }
                    }
                    else
                    {
                        if (Regex.IsMatch(key.ToString().Split('/')[counter], @"^\d+$"))
                        {
                            tStr = tStr[Int32.Parse(key.ToString().Split('/')[counter])];
                        }
                        else
                        {
                            tStr = tStr.SelectToken(key.ToString().Split('/')[counter]);
                        }
                    }
                    if (counter == slashCnt)
                    {
                        classNameTokens = tStr;
                        break;
                    }
                }
            }
            else
            {
                if (jObject.SelectToken(key) == null)
                    classNameTokens = jObject.SelectToken(Common.constData).SelectToken(key);
                else
                    classNameTokens = jObject.SelectToken(key);
                //classNameTokens = jObject.SelectToken(".." + key);
                //classNameTokens = jObject.SelectToken(key);
                //classNameTokens = jObject[key];
            }
            return classNameTokens.ToString();
        }

        /// <summary>
        ///Method to validate multiple attributes for the responses
        /// </summary>
        public static void validatemutlipleparameters<T>(string Endpoint, string Field, dynamic Field_value, dynamic id, string auth = "") where T : new()
        {
            for (int i = 0; i < id.Length; i++)
            {
                Common.id = Common.idArray[i];
                validateparameter<T>(Endpoint, Field, Field_value[i], id[i], auth = "");
            }
        }


        /// <summary>
        ///Method to validate attribute value for the response
        /// </summary>

        public static void validateparameter<T>(string Endpoint, string Field, string Field_value, string id, string auth = "") where T : new()
        {
            try
            {
                if (id == "")
                    BaseModel<T>.currentServicePage = APIHelper.getRequest<T>(Endpoint, id, auth);
                else
                    BaseModel<T>.currentServicePage = APIHelper.getRequest<T>(Endpoint, "", auth, Common.id);
                var classNameTokens = APIHelper.GetJObjectValue(Field, BaseModel<T>.currentServicePage.ToString());
                if (classNameTokens.Equals(Field_value))
                {
                    if (classNameTokens == "")
                    {
                        ReportingHelpers.ChildTest.Pass("Validated " + Field + "<br> Actual Value: Null / blank " + "<br> Expected Value: Null / blank");
                    }
                    else
                    {
                        ReportingHelpers.ChildTest.Pass("Validated " + Field + "<br> Actual Value: " + Field_value + "<br> Expected Value: " + classNameTokens.ToString());
                    }
                }
                else
                {
                    ReportingHelpers.ChildTest.Fail("Failed to validate " + Field + "<br> Actual Value: " + Field_value + "<br> Expected Value: " + classNameTokens.ToString());
                }
            }
            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Info("Exception has been thrown with message as ->" + e.Message);
            }



        }


        /// <summary>
        ///Method to validate multiple records post request
        /// </summary>

        public static void Validatenewmultiplerecordsafterpostrequest(dynamic id)
        {
            try
            {
                for (int i = 0; i < Settings_API.responseMultiple.Length; i++)
                {
                    Settings_API.response1 = Settings_API.responseMultiple[i];
                    Validatenewrecordafterpostrequest(id[i]);
                }
            }
            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Fail("Exception has been thrown with message as ->" + e.Message);
            }
        }


        /// <summary>
        ///Method to validate new record post request
        /// </summary>
        public static void Validatenewrecordafterpostrequest(dynamic id)
        {
            try
            {
                if ((int)Settings_API.response1.StatusCode == 200 || (int)Settings_API.response1.StatusCode == 201)
                {
                    ReportingHelpers.ChildTest.Pass("New record created successfully after post request.<br>Generated Id : " + id + "<br>Status code : " + (int)Settings_API.response1.StatusCode);
                }
                else
                {
                    ReportingHelpers.ChildTest.Fail("Failed to create record for post request." + "<br>Status code : " + (int)Settings_API.response1.StatusCode);
                    ReportingHelpers.ChildTest.Info("Actual error is : " + Settings_API.response1.Content);
                }
            }
            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Fail("Exception has been thrown with message as ->" + e.Message);
            }

        }

        /// <summary>
        ///Method to validate schema for API for each service
        /// </summary>
        public static void ValidateSchemaforAPI<T>(string endpoint, string schemafilename, string auth_type = "", string param = "") where T : new()
        {
            string schemaJson = File.ReadAllText(Environment.CurrentDirectory.ToString() + Settings.jsonfilepath + schemafilename);
            JsonSchema schema = JsonSchema.Parse(schemaJson);
            authenticatingRequest(auth_type);
            setupTLSSecurity();
            if (param == "" || Common.id == "")
            {
                InitializeRestRequest(endpoint, Method.GET);
            }
            else
            {
                InitializeRestRequest(endpoint + "/" + param, Method.GET);
            }
            Settings_API.response1 = executeRestrequest<T>(Settings_API.restRequest);
            string person_str = deserializeJson(Settings_API.response1);
            LogHelpers.info("Service schema is ->" + schema);
            string[] ids = Regex.Matches(person_str, @"\{.*?\},").Cast<Match>().Select(m => m.Value).ToArray();
            if (ids.Length == 0)
            {
                LogHelpers.info("ids mentioned under json response is-> " + person_str);
                JObject person = JObject.Parse(person_str);
                bool b = ValidateSchemaAttributes(person_str, schemafilename);
                bool valid = person.IsValid(schema);
                if (valid == true && b == true)
                {
                    ReportingHelpers.ChildTest.Pass("Validated single record Schema response sccessfully for the Service");
                }
                else
                {
                    try
                    {

                    }
                    catch (Exception e)
                    {
                        LogHelpers.error("Failed to validate single Schema for the Service response for above record id" + e.Message);
                    }
                }
            }
            else
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    try
                    {
                        JObject person = JObject.Parse(ids[i].Split("},")[0] + "}}}");
                        bool b = ValidateSchemaAttributes(ids[i].Split("},")[0] + "}}}", schemafilename);
                        bool valid = person.IsValid(schema);
                        if (valid == true && b == true)
                        {
                            ReportingHelpers.ChildTest.Pass("Validated all attributes for above Schema sccessfully for the Service");
                        }
                        else
                        {
                            ReportingHelpers.ChildTest.Fail("Failed to validate Schema for the Service for above record id");
                        }
                    }
                    catch (Exception e)
                    {
                        //ReportingHelpers.ChildTest.Fail("Exception has been thrown as ->" + e.Message + " for above Record Id");
                    }
                }
            }



        }

        /// <summary>
        ///Method to create payload for post request
        /// </summary>
        public static void CreatePayload<T>(string sheetname) where T : new()
        {
            BaseModel<T>.currentServicePage = APIDatahelper.MappingExcelToServiceModel<T>(sheetname);
        }

        /// <summary>
        ///New Method to update payload for mutliple put request
        /// </summary>
        public static void UpdateMultiplePayload(Table table)
        {
            Table t = new Table((string[])table.Header);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                t.AddRow(table.Rows[i]);
                Common.jsonObj = Common.jsonObjMultiple[i].ToString();
                UpdatePayload(t);
                Common.jsonObjMultiple[i] = Common.jsonObj;
                t = new Table((string[])table.Header);
            }
        }

        /// <summary>
        ///New Method to update payload for put request
        /// </summary>
        public static void UpdatePayload(Table table)
        {
            foreach (TableRow dr in table.Rows)
            {
                foreach (var s in dr)
                {
                    string tempStr = null;
                    tempStr = APIDatahelper.UpdateTokenValue(JObject.Parse(Common.jsonObj.ToString()), s.Key, s.Value).ToString();
                    JObject j = JObject.Parse(tempStr);
                    Common.jsonObj = j.ToString();
                }
            }
            string json = JsonConvert.SerializeObject(Common.jsonObj, Formatting.Indented);
            Common.jsonObj = JsonConvert.DeserializeObject(json).ToString();
            if (Common.jsonObj.Contains("_DateStamp"))
                Common.jsonObj = Common.jsonObj.Replace("DateStamp", DateTime.Now.ToString(Settings.TimeStampFormat));
        }




        /// <summary>
        ///Method to validate content type for multiple API responses
        /// </summary>

        public static void validateContentTypeforMultipleResponses(string contenttype, string contenttypevalue)
        {
            for (int i = 0; i < Settings_API.responseMultiple.Length; i++)
            {
                Settings_API.response1 = Settings_API.responseMultiple[i];
                ReportingHelpers.ChildTest.Pass("Validated Content Type against ID: " + Common.idArray[i] + "<br>");
                validateContentType(contenttype, contenttypevalue);
            }
        }

        /// <summary>
        ///Method to validate content type for API response
        /// </summary>
        public static void validateContentType(string contenttype, string contenttypevalue)
        {
            if (Settings_API.response1.ContentType.Equals(contenttypevalue))
            {
                ReportingHelpers.ChildTest.Pass("API content type is: " + contenttypevalue);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail("Failed to validate API content type: " + contenttypevalue);
            }
        }

        /// <summary>
        ///Method to validate header for API response
        /// </summary>
        public static void validateHeaderResponse(string headerType, string headerValue)
        {
            switch (headerType)
            {
                case "Content-Type":
                    validateContentType(headerType, headerValue);
                    break;
                case "":
                    break;
            }
        }

        /// <summary>
        ///Method to validate content type for API request 
        /// </summary>
        public static void validateContentTypeRequest(string contenttype, string contenttypevalue)
        {

        }

        /// <summary>
        ///Method to validate header for API request
        /// </summary>
        public static void validateHeaderRequest(string headerType, string headerValue)
        {
            switch (headerType)
            {
                case "Content-Type":
                    validateContentTypeRequest(headerType, headerValue);
                    break;
                case "":
                    break;
            }
        }
        /// <summary>
        ///Method to set up Json object using API response
        /// </summary>

        public static void setJsonobject()
        {
            if (Common.jsonPayload != null)
                Common.jsonObj = Common.jsonPayload.ToString();
            Common.jsonObj = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(Settings_API.response1.Content.ToString()));
        }
        /// <summary>
        ///Method to validate page size for API request
        /// </summary>
        public static void validatePagesize(string size, string size_val)
        {

        }
    }
}
