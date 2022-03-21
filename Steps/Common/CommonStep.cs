using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using HeartFramework.BaseAPI;
using HeartFramework.Config;
using HeartFramework.Helpers;
using HeartTest.Features.CoreServices;
using HRSData.Pages.CoreServices;
using HRSData.Pages.CoreServices.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HeartTest.Steps.Services
{ 
    [Binding]
    public class CommonStep : APIHelper
    {
        [Given(@"I Set UP URL For APIs with Endpoint as ""(.*)""")]
        public void GivenISetUPURLForAPIsWithEndpointAs(string endpoint)
        {
            if (endpoint.Contains("{") && endpoint.Contains("}"))
            {
                int start_index = endpoint.IndexOf("{");
                int end_index = endpoint.IndexOf("}");
                string param_val = endpoint.Substring(start_index, end_index - start_index + 1);
                if(param_val.Equals("{id}"))
                endpoint = endpoint.Replace(param_val, Common.subId);
                if (param_val.Equals("{hrn}"))
                endpoint = endpoint.Replace(param_val, Common.id);
            }
            Common.endpoint = endpoint;
            APIHelper.SetURL(Common.endpoint);
            ReportingHelpers.ChildTest.Pass("Endpoint: " + Common.endpoint);
        }

        [Given(@"I Set UP URL For APIs with Endpoint")]
        public void GivenISetUpURLsForAPI(Table e)
        {
            Common.endpoint = APIDatahelper.getFeatureData(e, "Endpoint");
            APIHelper.SetURL(Common.endpoint);
            ReportingHelpers.ChildTest.Pass("Endpoint: " + Common.endpoint);
        }

        
        [Given(@"I Retrieve Token Key for API")]
        public void GivenIRetrieveTokenKeyForAPI()
        {
            IntializingTokenCredentials(Environment.CurrentDirectory.ToString() + Settings.TestData);
            Common.Token_Id = APIHelper.getTokenViaCognito(Common.appPoolID, Common.clientId, Common.identityPoolID, Common.username, Common.password, Common.accesstoken, Common.secrettoken);
         }

        [Given(@"I Validate Expiry for API Token")]
        public void GivenIValidateExpiryforAPI()
        {
            Common.TokenFlag=APIHelper._isEmptyOrInvalidToken(Common.Token_Id);
        }
            

        [Then(@"I validate status code for Get requests")]
        public void ThenIValidateGetStatusCode()
        {
              APIHelper.validateStatusCodeGet();
        }

        [Then(@"I validate status code for Put requests")]
        public void ThenIValidatePutStatusCode()
        {
            APIHelper.validateStatusCodePut();
        }

        [Then(@"I validate status code for all Put requests")]
        public void ThenIValidateallPutStatusCode()
        {
            APIHelper.validateStatusCodePutMultiple();
        }

        [Then(@"I validate status code for Patch requests")]
        public void ThenIValidatePatchStatusCode()
        {
            APIHelper.validateStatusCodePatch();
        }

        [Then(@"I validate status code for all Patch requests")]
        public void ThenIValidateAllPatchStatusCode()
        {
            APIHelper.validateStatusCodePatchMultiple();
        }

        [Then(@"I Validate content type for response as ""(.*)""")]
        public void ThenIValidateContentTypeForResponseAs(string contenttype)
        {            
            APIHelper.validateContentType("Content-Type", contenttype);
        }

        [Then(@"I Validate content type for all response as ""(.*)""")]
        public void ThenIValidateContentTypeForAllResponseAs(string contenttype)
        {
            APIHelper.validateContentTypeforMultipleResponses("Content-Type", contenttype);
        }

        [Then(@"I Validate content type for response")]
        public void ThenIValidatecontenttypeforresponse(Table e)
        {
            APIHelper.validateContentType("Content-Type", APIDatahelper.getFeatureData(e, "Content-Type"));
        }

        [Then(@"I Validate new record after post request")]
        public void ThenIValidatenewrecordafterpostrequest()
        {
            APIHelper.Validatenewrecordafterpostrequest(Common.id);
        }

        [Then(@"I Validate all new records after post request")]
        public void ThenIValidateAllNewRecordsAfterPostRequest()
        {
            APIHelper.Validatenewmultiplerecordsafterpostrequest(Common.idArray);
        }
    }
    
}
