using Dynamitey.DynamicObjects;
using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using HRSData.Pages.CoreServices.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices
{
    public static class TenantService
    {
        public static void validatecountcognitoUserPoolId()
        {
            /*int c = 0;
            for(int i=0;i< BaseModel<Tenant>.currentServicePage.Count();i++)
            {
                if (BaseModel<Tenant>.currentServicePage[i].cognitoUserPoolId != null)
                {
                    c = c + 1;
                }
            }
            ////ReportingHelpers.ChildTest.Pass("Count of cognitoUserPoolId, which is not null is: "+c);*/
        }

        public static void validatenamefortenant(string Field, string Field_value)
        {
            Dictionary<String, String> dataEx = ExcelHelpers.getRowData("POC_CoreServices");
            
            if (dataEx["id_value"] == "")
            BaseModel<Tenant>.currentServicePage = APIHelper.getRequest<Tenant>(dataEx["Endpoint"],Common.id, Common.keyword_BearerToken);
            else
            BaseModel<Tenant>.currentServicePage = APIHelper.getRequest<Tenant>(dataEx["Endpoint"], dataEx["id_value"], Common.keyword_BearerToken);

            //JObject json = JObject.Parse(BaseModel<Tenant>.currentServicePage);
            if (BaseModel<Tenant>.currentServicePage.SelectToken(Field).ToString().Equals(Field_value))
            {
                LogHelpers.info("Current value for name against id: " + BaseModel<Tenant>.currentServicePage.SelectToken("id").ToString() + " is: " + BaseModel<Tenant>.currentServicePage.SelectToken(Field).ToString()+" matching with supplied value as -> "+ Field_value);
            }
            else
            {
                LogHelpers.error("Current value for name against id: " + BaseModel<Tenant>.currentServicePage.SelectToken("id").ToString() + " is: " + BaseModel<Tenant>.currentServicePage.SelectToken(Field).ToString()+ " not matching with supplied value as -> " + Field_value);
            }
        }


        public static void _isContains(JObject json, string value)
        {
            //bool contains = false;
            //Object.keys(json).some(key => {
            //    contains = typeof json[key] === 'object' ? _isContains(json[key], value) : json[key] === value;
            //    return contains;
            //});
            //return contains;
            //var searchedTokens = JToken.FindTokens(key);
            //int count = searchedTokens.Count;

            //if (count == 0)
            //    return $"The key you have to serach is not present in json, Key: {key}";

            //foreach (JToken token in searchedTokens)
            //{
            //    if (!occurence.HasValue)
            //        jToken.SetByPath(token.Path, value);
            //    else
            //    if (occurence.Value == searchedTokens.IndexOf(token))
            //        jToken.SetByPath(token.Path, value);
            //}

            //return jToken;

        }

        
        }
}
