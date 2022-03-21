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
    public class ListService : APIHelper
    {

        [When(@"I perform Get Request for List Service")]
        public void WhenIPerformGetRequestForListService()
        {
            BaseModel<ListModel>.currentServicePage = APIHelper.getRequest<ListModel>(Common.endpoint, Common.id, Common.keyword_BearerToken, "");
        }


        [When(@"I generate payload of List service")]
        public void WhenIGeneratePayloadOfListService(Table e)
        {
            APIDatahelper.featureToJSON<ListModel>(e);
        }

        [When(@"I Validate Schema of List service using ""(.*)""")]
        public void WhenIValidateSchemaOfListServiceUsing(string schemafile)
        {

            APIHelper.ValidateSchemaAttributes(Common.jsonObj, schemafile);
        }
        [When(@"I perform Post request for List service")]
        public void WhenIPerformPostRequestForListService()
        {
            BaseModel<ListModel>.currentServicePage = APIHelper.postRequest<ListModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }


        [When(@"I perform Put request for List service")]
        public void WhenIPerformPutRequestForListService()
        {
            BaseModel<ListModel>.currentServicePage = APIHelper.putRequest<ListModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [When(@"I retrieve a existing record data using HRN")]
        public void WhenIRetrieveAExistingRecordDataUsingHRN()
        {
            BaseModel<ListModel>.currentServicePage = APIHelper.getRequest<ListModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
        }

        [When(@"I Update Payload for a existing List service")]
        public void WhenIUpdatePayloadForAExistingListService(Table e)
        {
            UpdatePayload(e);
        }







        /*[When(@"I perform Get Request for Profile service - Organization")]
        public void WhenIPerformGetRequestForProfileServiceOrganization()
        {
            BaseModel<Organizations>.currentServicePage = APIHelper.getRequest<Organizations>(Common.endpoint, Common.id, Common.keyword_BearerToken, "");
        }

        [When(@"I perform Post request for Profile service - Organization")]
        public void WhenIPerformPostRequestForProfileServiceOrganization()
        {
            BaseModel<Organizations>.currentServicePage = APIHelper.postRequest<Organizations>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [When(@"I generate payload of Profile service - Organization Service for Post request")]
        public void WhenIgeneratepayloadofProfileServiceOrganization(Table e)
        {
            APIDatahelper.featureToJSON<Organizations>(e);
         }

        [When(@"I update payload of Profile service - Organization Service for put request")]
        public void WhenIUpdatepayloadofProfileServiceOrganizationforPutRequest(Table e)
        {
            UpdatePayload(e);
        }

        [When(@"I provide attributes against Profile service - Organization for patch request")]
        public void WhenIgeneratepayloadofProfileServiceOrganizationforPatchRequest(Table e)
        {
            APIDatahelper.featureToJSON<Organizations>(e);
        }

        [When(@"I Validate Schema of Profile service - Organization Service for request payload having schemafile as ""(.*)""")]
        public void WhenIValidateSchemaOfProfileService_OrganizationServiceForRequestPayloadHavingSchemafileAs(string schemafile)
        {
            APIHelper.ValidateSchemaAttributes(Common.jsonObj, schemafile);
        }


        [When(@"I Validate Schema of Profile service - Organization Service for request payload")]
        public void WhenIvalidateschemaofProfileServiceOrganization(Table e)
        {
            APIHelper.ValidateSchemaAttributes(Common.jsonObj,  APIDatahelper.getFeatureData(e, "schemafile"));
        }

        [When(@"I perform Patch request for Profile service - Organization Service")]
        public void WhenIperformPatchrequestforProfileServiceOrganization()
        {
            BaseModel<Organizations>.currentServicePage = APIHelper.patchRequest<Organizations>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }
        


         [When(@"I retrieve data using ID via Get Request for Profile service - Organization Service")]
        public void WhenIretrieveIDViaforPutRequestProfileOrganization()
        {
            BaseModel<Organizations>.currentServicePage = APIHelper.getRequest<Organizations>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
        }

        [When(@"I retrieve data against parameter value as ""(.*)"" for Profile service - Organization Service")]
        public void WhenIRetrieveDataAgainstParameterValueAsForProfileService_OrganizationService(string p0)
        {
            BaseModel<Organizations>.currentServicePage = APIHelper.getRequest<Organizations>(Common.endpoint, "", Common.keyword_BearerToken, p0);
        }    

        [When(@"I perform Put request for Profile service - Organization Service")]
        public void WhenIPerformPutRequestForProfileserviceOrganization()
        {
            BaseModel<Organizations>.currentServicePage = APIHelper.putRequest<Organizations>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [Then(@"I Validate name parameter for Profile service - Organization")]
        public void ThenIValidateNameParameterforProfileServiceOrganization()
        {
            APIHelper.validateparameter<Organizations>(Common.endpoint, "name", APIHelper.GetJObjectValue("name", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate sourceIdentifier parameter for Profile service - Organization")]
        public void ThenIValidatesourceIdentifierParameterforProfileServiceOrganization()
        {
            APIHelper.validateparameter<Organizations>(Common.endpoint, "sourceIdentifier", APIHelper.GetJObjectValue("sourceIdentifier", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate notes parameter for Profile service - Organization")]
        public void ThenIValidatenotesParameterforProfileServiceOrganization()
        {
            APIHelper.validateparameter<Organizations>(Common.endpoint, "notes", APIHelper.GetJObjectValue("notes", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate city under contactInformation parameter for Profile service - Organization")]
        public void ThenIValidatecityundercontactinformationforProfileServiceOrganization()
        {
            APIHelper.validateparameter<Organizations>(Common.endpoint, "contactInformation/city", APIHelper.GetJObjectValue("contactInformation/city", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate Schema for Profile service - Organization API response having schemafile as ""(.*)""")]
        public void ThenIValidateSchemaForProfileService_OrganizationAPIResponseHavingSchemafileAs(string schemafilename)
        {
            if (Common.id == null)
                APIHelper.ValidateSchemaforAPI<Organizations>(Common.endpoint, schemafilename, Common.keyword_BearerToken, "hrn:hrs:profile:org:1:9");
            else
                APIHelper.ValidateSchemaforAPI<Organizations>(Common.endpoint, schemafilename, Common.keyword_BearerToken, Common.id);
        }


        [Then(@"I Validate Schema for Profile service - Organization API response")]
        public void ThenIValidateSchemaforProfileServiceOrganization(Table e)
        {
            if(Common.id==null)
                APIHelper.ValidateSchemaforAPI<Organizations>(Common.endpoint, APIDatahelper.getFeatureData(e, "schemafile"),Common.keyword_BearerToken, "hrn:hrs:profile:org:1:9");
            else
                APIHelper.ValidateSchemaforAPI<Organizations>(Common.endpoint, APIDatahelper.getFeatureData(e, "schemafile"),Common.keyword_BearerToken, Common.id);
        }

        [When(@"I perform Delete request for Profile service - Organization Service")]
        public void WhenIPerformDeleteRequestForProfileServiceOrganization()
        {
            if (dataEx["id_value"] == "")
                APIHelper.deleteRequest<Organizations>(Common.endpoint, Common.id, Common.keyword_BearerToken);
            else
                APIHelper.deleteRequest<Organizations>(Common.endpoint, dataEx["id_value"], Common.keyword_BearerToken);
        }
        [When(@"I perform Get request for Profile service - Organization with deleted parameter")]
        public void WhenIperformGetrequestwithdeletedparameterProfileServiceOrganization()
        {
            if (dataEx["id_value"] == "")
                APIHelper.getRequest<Organizations>(Common.endpoint, Common.id, Common.keyword_BearerToken);
            else
                APIHelper.getRequest<Organizations>(Common.endpoint, dataEx["id_value"], Common.keyword_BearerToken);
        }


        [Then(@"I validate status code of Profile service - Organization for Delete request")]
        public void ThenIvalidatestatuscodeforDeleterequestforProfileServiceOrganization()
        {
            APIHelper.validateStatusCodeDelete();
        }


        [Then(@"I validate Sort by ""(.*)"" in Get Request for Profile service - Organization")]
        public void ThenIValidateSortByInGetRequestForProfileService_Organization(string p0)
        {
            Common.keyword_Param_val = p0;
            BaseModel<Organizations>.currentServicePage = APIHelper.getRequest<Organizations>(Common.endpoint, "sort");
            getSort(p0);
        }

        [Then(@"I validate filter by ""(.*)"" in Get Request for Profile service - Organization")]
        public void ThenIValidateFilterByInGetRequestForProfileService_Organization(string p0, Table data)
        {
            string Param = "filter[" + p0 + "]";
            Common.keyword_Param_val = APIDatahelper.getFeatureData(data, p0);
            BaseModel<Organizations>.currentServicePage = APIHelper.getRequest<Organizations>(Common.endpoint, Param);
            getFilter(p0);
        }



    }*/
    }
}
