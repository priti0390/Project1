using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using HRSData.Pages.CoreServices;
using HRSData.Pages.CoreServices.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HeartTest.Steps.CoreServices
{
    [Binding]
    public class Tenant_Services : APIHelper
    {
        [When(@"I perform Get request for tenant service")]
        public void WhenIPerformGetRequestForTenantService()
        {
            BaseModel<Tenant>.currentServicePage = APIHelper.getRequest<Tenant>(dataEx["Endpoint"], "",Common.keyword_BearerToken);
        }

        [When(@"I perform Get requests for tenant service")]
        public void WhenIPerformGetRequestsForTenantService()
        {
            BaseModel<Tenant>.currentServicePage = APIHelper.getRequest<Tenant>(Common.endpoint,"" ,Common.keyword_BearerToken);
        }

        [Then(@"I Validate count of cognitoUserPoolId")]
        public void WhenIValidateCountofcognitoUserPoolId()
        {
            TenantService.validatecountcognitoUserPoolId();
        }

        [When(@"I perform Post request for tenant service")]
        public void WhenIPerformPostRequestForTenantService() 
        {
            BaseModel<Tenant>.currentServicePage = APIHelper.postRequest<Tenant>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

      


        [When(@"I update payload of Tanant Service for put request")]
        public void ThenIupdatepayloadofTenantServiceforputrequest(Table e)
        {
            UpdatePayload(e);
        }
       

        [When(@"I perform Put request for tenant service")]
        public void WhenIPerformPutRequestForTenantService()
        {
            BaseModel<Tenant>.currentServicePage=APIHelper.putRequest<Tenant>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [Then(@"I Validate name parameter")]
        public void ThenIValidateNameParameter()
        {
            APIHelper.validateparameter<Tenant>(Common.endpoint, "Name", APIHelper.GetJObjectValue("Name", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate address parameter")]
        public void ThenIValidateaddressParameter()
        {
            APIHelper.validateparameter<Tenant>(Common.endpoint, "address", APIHelper.GetJObjectValue("address", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }
        [Then(@"I Validate email parameter")]
        public void ThenIValidateemailParameter()
        {
            APIHelper.validateparameter<Tenant>(Common.endpoint, "address", APIHelper.GetJObjectValue("address", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }
        [Then(@"I Validate phone parameter")]
        public void ThenIValidatephoneParameter()
        {
            APIHelper.validateparameter<Tenant>(Common.endpoint, "phone", APIHelper.GetJObjectValue("phone", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }
        [Then(@"I Validate code parameter")]
        public void ThenIValidatecodeParameter()
        {
            APIHelper.validateparameter<Tenant>(Common.endpoint, "code", APIHelper.GetJObjectValue("code", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [When(@"I retrieve data using ID via Get Request")]
        public void WhenIPerformgetRequestviaID()
        {
            BaseModel<Tenant>.currentServicePage = APIHelper.getRequest<Tenant>(Common.endpoint, Common.id, Common.keyword_BearerToken);
        }

        [When(@"I perform Delete request for tenant service against parameter value as ""(.*)""")]
        public void WhenIPerformDeleteRequestForTenantServiceAgainstParameterValueAs(string p0)
        {
            APIHelper.deleteRequest<Tenant>(Common.endpoint, p0, Common.keyword_BearerToken);
        }

        [When(@"I perform Get request with deleted parameter")]
        public void WhenIperformGetrequestwithdeletedparameter()
        {
            APIHelper.getRequest<Tenant>(Common.endpoint,Common.id, Common.keyword_BearerToken);
            ReportingHelpers.ChildTest.Pass("I performed delete request against ID: "+ Common.id);
        }
        

        [Then(@"I validate status code for Delete request")]
        public void ThenIvalidatestatuscodeforDeleterequest()
        {
            APIHelper.validateStatusCodeDelete();
        }
        
        [When(@"I generate payload of Tenant Service for Post request")]
        public void WhenIgeneratepayloadofTenantforpostrequest(Table e)
        {
            APIDatahelper.featureToJSON<Organizations>(e);
        }

        [Then(@"I Validate Schema for request payload")]
        public void ThenIValidateSchemaforrequestpayload(Table e)
        {
            APIHelper.ValidateSchemaAttributes(Common.jsonObj, APIDatahelper.getFeatureData(e, "schemafile"));
        }

        [Then(@"I Validate Schema for tenant API response")]
        public void ThenIValidateSchemafortenantAPI(Table e)
        {
            APIHelper.ValidateSchemaforAPI<Tenant>(Common.endpoint, APIDatahelper.getFeatureData(e, "schemafile"),Common.keyword_BearerToken,Common.id);
        }
    }


}
