using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HeartFramework.BaseAPI
{
    /// <summary>
    /// Declaring all static variables used
    /// </summary>

    public static class Common
    {
        public static string ContentType = "application/JSON";
        public static string ContentTypeMultiPartFormData="multipart/form-data";
        public static string File = "file";
        public static string WordDocPath = "SampleDocuments\\";
        public static string keyword_accept = "Accept";
        public static string keyword_API = "API";
        public static string auth_type = "Basic Auth";
        public static string auth_OAuth2 = "OAuth 2.0";
        public static string keyword_Authorization = "Authorization";
        public static string keyword_Bearer = "Bearer";
        public static string param_delreq = "Bearer";
        public static string keyword_contentType="Content-Type";
        public static string keyword_BearerToken="Bearer Token";
        public static bool Auth_Message = false;
        public static string endpoint;
        public static string ContentutfType="application/json; charset=utf-8";
        public static string keyword_header = "x-hrs-clear-tenant-id";
        public static string keyword_header_val = "1";
        public static string keyword_Param_val="";
        //Bearer Token Auth related Constants and Literals
        public static string Token_Id;
        public static bool TokenFlag;
        public static string appPoolID;
        public static string clientId;
        public static string identityPoolID;
        public static string username;
        public static string password;
        public static string accesstoken;
        public static string secrettoken;
        public static int itr=0;


        public static string jsonObj;
        public static dynamic[] jsonObjMultiple;
        public static dynamic jsonPayload;
        public static dynamic id;
        public static dynamic subId;
        public static dynamic[] idArray;
        public static bool delete_flag=false;
        public static int expFlag = 0;
        public static string constData = "data";
        public static string consPerson = "person";
        public static string constorganization = "organization";
        public static string consttenant = "tenant";
        public static string constagreement = "agreement";
        public static string constList = "list";

        public static dynamic schemaFile = new Dictionary<string, string>(){
    {"Person", "ProfileService_Person_Schema.json"},
    {"Organizations", "ProfileService_Organization_Schema.json"},
    {"Tenant", "tenantServiceDataSchema.json"},
        {"AgreementsModel", "agreementsDataSchema.json"},
        {"ListModel", "ListService_Schema.json"},
        {"DocumentModel", "DocumentService_Schema.json"}
        };
       
       

    }
}
