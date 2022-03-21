using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public enum Verb
{
    GET,
    POST,
    PUT,
    DELETE
}
namespace HeartFramework.Helpers
{
    public class WebServiceHelpers
    {
       
          /*    var client = new WebServiceHelpers();
                client.EndPoint = @"https://restcountries.eu";
                client.Method = Verb.GET;
                var pdata = client.PostData;
                var response = client.Request("/rest/v1/currency/eur");*/
            
            public string EndPoint { get; set; }
            public Verb Method { get; set; }
            public string ContentType { get; set; }
            public string PostData { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

        public WebServiceHelpers()
            {
                EndPoint = "";
                Method = Verb.GET;
                ContentType = "application/JSON";
                PostData = "";
            }

            public WebServiceHelpers(string endpoint, Verb method, string postData, string username, string password)
            {
                EndPoint = endpoint;
                Method = method;
                ContentType = "text/json";
                PostData = postData;
                UserName = username;
                Password = password;
            }


            public string Request()
            {
                return Request("");
            }

            public string Request(string parameters)
            {
                var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(UserName+":"+Password));
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return responseValue;
                }
            }

        }
    }


