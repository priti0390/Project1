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
    public class ProfileService_Person : APIHelper
    {
        [When(@"I perform Get Request for Profile service - Person")]
        public void WhenIPerformGetRequestForProfileServicePerson()
        {
            BaseModel<Person>.currentServicePage = APIHelper.getRequest<Person>(Common.endpoint, Common.id, Common.keyword_BearerToken, "");
        }

        [When(@"I perform Post request for Profile service - Person")]
        public void WhenIPerformPostRequestForProfileServicePerson()
        {
            //BaseModel<Person>.currentServicePage = APIHelper.postRequest<Person>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
            BaseModel<Person>.currentServicePage = APIHelper.postMultipleRequests<Person>(Common.endpoint, Common.jsonObjMultiple, Common.keyword_BearerToken);
        }

        [When(@"I generate payload of Profile service - Person Service for Post request")]
        public void WhenIgeneratepayloadofProfileServicePerson(Table e)
        {
            //APIDatahelper.featureToJSON<Person>(e);
            APIDatahelper.featureToJSONformultipleDatas<Person>(e);
        }

        [When(@"I update payload of Profile service - Person Service for put request")]
        public void WhenIUpdatepayloadofProfileServicePersonforPutRequest(Table e)
        {
            UpdateMultiplePayload(e);
            //UpdatePayload(e);
        }

        [When(@"I provide attributes against Profile service - Person for patch request")]
        public void WhenIgeneratepayloadofProfileServicePersonforPatchRequest(Table e)
        {
            APIDatahelper.featureToJSONformultipleDatas<Person>(e);
            //APIDatahelper.featureToJSON<Person>(e);
        }

        [When(@"I Validate Schema of Profile service - Person Service for request payload having schemafile as ""(.*)""")]
        public void WhenIValidateSchemaOfProfileService_PersonServiceForRequestPayloadHavingSchemafileAs(string schemafile)
        {
            APIHelper.ValidateSchemaAttributes(Common.jsonObj, schemafile);
        }


        [When(@"I Validate Schema of Profile service - Person Service for request payload")]
        public void WhenIvalidateschemaofProfileServicePerson(Table e)
        {
            APIHelper.ValidateSchemaAttributes(Common.jsonObj,  APIDatahelper.getFeatureData(e, "schemafile"));
        }

        [When(@"I perform Patch request for Profile service - Person Service")]
        public void WhenIperformPatchrequestforProfileServicePerson()
        {
            BaseModel<Person>.currentServicePage = APIHelper.patchRequestMultiple<Person>(Common.endpoint, Common.jsonObjMultiple, Common.keyword_BearerToken);
            //BaseModel<Person>.currentServicePage = APIHelper.patchRequest<Person>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }
        


         [When(@"I retrieve data using ID via Get Request for Profile service - Person Service")]
        public void WhenIretrieveIDViaforPutRequestProfilePerson()
        {
            BaseModel<Person>.currentServicePage = APIHelper.getRequestMultiple<Person>(Common.endpoint, "", Common.keyword_BearerToken, Common.idArray);
            //BaseModel<Person>.currentServicePage = APIHelper.getRequest<Person>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
        }

        [When(@"I retrieve data against parameter value as ""(.*)"" for Profile service - Person Service")]
        public void WhenIRetrieveDataAgainstParameterValueAsForProfileService_PersonService(string p0)
        {
            BaseModel<Person>.currentServicePage = APIHelper.getRequest<Person>(Common.endpoint, "", Common.keyword_BearerToken, p0);
        }

        [When(@"I retrieve data against mutliple parameter value for Profile service - Person Service")]
        public void WhenIRetrieveDataAgainstMutlipleParameterValueForProfileService_PersonService()
        {
            BaseModel<Person>.currentServicePage = APIHelper.getRequestMultiple<Person>(Common.endpoint, "", Common.keyword_BearerToken, Common.idArray);
        }
        [When(@"I perform Put request for Profile service - Person Service")]
        public void WhenIPerformPutRequestForProfileservicePerson()
        {
            BaseModel<Person>.currentServicePage = APIHelper.putRequestMultiple<Person>(Common.endpoint, Common.jsonObjMultiple, Common.keyword_BearerToken);
            //BaseModel<Person>.currentServicePage = APIHelper.putRequest<Person>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [Then(@"I Validate name parameter for Profile service - Person")]
        public void ThenIValidateNameParameterforProfileServicePerson()
        {
            APIHelper.validateparameter<Person>(Common.endpoint, "name", APIHelper.GetJObjectValue("name", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate lastName parameter for Profile service - Person")]
        public void ThenIValidatelastNameParameterforProfileServicePerson()
        {
            //APIHelper.validateparameter<Person>(Common.endpoint, "lastName", APIHelper.GetJObjectValue("lastName", Common.jsonObj), Common.id, Common.keyword_Bearer);
            APIHelper.validatemutlipleparameters<Person>(Common.endpoint, "lastName", APIHelper.GetJObjectMultipleValues("lastName", Common.jsonObjMultiple), Common.idArray, Common.keyword_Bearer);
        }

        [Then(@"I Validate firstName parameter for Profile service - Person")]
        public void ThenIValidatefirstNameParameterforProfileServicePerson()
        {
            //APIHelper.validateparameter<Person>(Common.endpoint, "firstName", APIHelper.GetJObjectValue("firstName", Common.jsonObj), Common.id, Common.keyword_Bearer);
            APIHelper.validatemutlipleparameters<Person>(Common.endpoint, "firstName", APIHelper.GetJObjectMultipleValues("firstName", Common.jsonObjMultiple), Common.idArray, Common.keyword_Bearer);
        }

        [Then(@"I Validate city under contactInformation parameter for Profile service - Person")]
        public void ThenIValidatecityundercontactinformationforProfileServicePerson()
        {
            APIHelper.validatemutlipleparameters<Person>(Common.endpoint, "contactInformation/city", APIHelper.GetJObjectMultipleValues("contactInformation/city", Common.jsonObjMultiple), Common.idArray, Common.keyword_Bearer);
            //APIHelper.validateparameter<Person>(Common.endpoint, "contactInformation/city", APIHelper.GetJObjectValue("contactInformation/city", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate Schema for Profile service - Person API response having schemafile as ""(.*)""")]
        public void ThenIValidateSchemaForProfileService_PersonAPIResponseHavingSchemafileAs(string schemafilename)
        {
            if (Common.id == null)
                APIHelper.ValidateSchemaforAPI<Person>(Common.endpoint, schemafilename, Common.keyword_BearerToken, "hrn:hrs:profile:org:1:9");
            else
                APIHelper.ValidateSchemaforAPI<Person>(Common.endpoint, schemafilename, Common.keyword_BearerToken, Common.id);
        }


        [Then(@"I Validate Schema for Profile service - Person API response")]
        public void ThenIValidateSchemaforProfileServicePerson(Table e)
        {
            if(Common.id==null)
                APIHelper.ValidateSchemaforAPI<Person>(Common.endpoint, APIDatahelper.getFeatureData(e, "schemafile"),Common.keyword_BearerToken, "hrn:hrs:profile:org:1:9");
            else
                APIHelper.ValidateSchemaforAPI<Person>(Common.endpoint, APIDatahelper.getFeatureData(e, "schemafile"),Common.keyword_BearerToken, Common.id);
        }

        [When(@"I perform Delete request for Profile service - Person Service")]
        public void WhenIPerformDeleteRequestForProfileServicePerson()
        {
            if (dataEx["id_value"] == "")
                APIHelper.deleteRequest<Person>(Common.endpoint, Common.id, Common.keyword_BearerToken);
            else
                APIHelper.deleteRequest<Person>(Common.endpoint, dataEx["id_value"], Common.keyword_BearerToken);
        }
        [When(@"I perform Get request for Profile service - Person with deleted parameter")]
        public void WhenIperformGetrequestwithdeletedparameterProfileServicePerson()
        {
            if (dataEx["id_value"] == "")
                APIHelper.getRequest<Person>(Common.endpoint, Common.id, Common.keyword_BearerToken);
            else
                APIHelper.getRequest<Person>(Common.endpoint, dataEx["id_value"], Common.keyword_BearerToken);
        }


        [Then(@"I validate status code of Profile service - Person for Delete request")]
        public void ThenIvalidatestatuscodeforDeleterequestforProfileServicePerson()
        {
            APIHelper.validateStatusCodeDelete();
        }


        [Then(@"I validate Sort by ""(.*)"" in Get Request for Profile service - Person")]
        public void ThenIValidateSortByInGetRequestForProfileService_Person(string p0)
        {
            Common.keyword_Param_val = p0;
            BaseModel<Person>.currentServicePage = APIHelper.getRequest<Person>(Common.endpoint, "sort");
            getSort(p0);
        }

        [Then(@"I validate filter by ""(.*)"" in Get Request for Profile service - Person")]
        public void ThenIValidateFilterByInGetRequestForProfileService_Person(string p0, Table data)
        {
            string Param = "filter[" + p0 + "]";
            Common.keyword_Param_val = APIDatahelper.getFeatureData(data, p0);
            BaseModel<Person>.currentServicePage = APIHelper.getRequest<Person>(Common.endpoint, Param);
            getFilter(p0);
        }


        [Then(@"I validate that the response HRN matches with request HRN")]
        public void ThenIValidateThatTheResponseHRNMatchesWithRequestHRN()
        {
            //APIHelper.validateparameter<Person>(Common.endpoint, "hrn", APIHelper.GetJObjectValue("hrn", Common.jsonObj), Common.id, Common.keyword_Bearer);


        }


        [Then(@"I validate that value of ""(.*)"" attribute is ""(.*)"" in response")]
        public void ThenIValidateThatValueOfAttributeIsInResponse(string p0, string p1)
        {
            validateParametersInGetResponse(p0, p1);
        }


    }
}
