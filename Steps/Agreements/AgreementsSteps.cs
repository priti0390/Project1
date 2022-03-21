using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;
using System.Threading;


namespace HeartTest.Steps.Delta
{
    [Binding]
    public class AgreementsSteps : APIHelper
    {

        [When(@"I perform Get request for Agreements")]
        public void WhenIPerformGetRequestForAgreements()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint,"", Common.keyword_BearerToken);
        }

        [When(@"I generate payload for Post request for Agreements")]
        public void WhenIGeneratePayloadForPostRequestForAgreements(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }


        [When(@"I perform Post request for Agreements")]
        public void WhenIPerformPostRequestForAgreements()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
            
        }

        [When(@"I perform Post request without request body for Agreements")]
        public void WhenIPerformPostRequestWithoutRequestBodyForAgreements()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken);
          
        }


        [Then(@"I perform Get request and verify the resource created")]
        public void ThenIPerformGetRequestAndVerifyTheResourceCreated()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
            ReportingHelpers.ChildTest.Pass("Performed Get Request with HRN for created Post Request. HRN : " + Common.id);
        }

        [Then(@"I verify the resource is not created")]
        public void ThenIVerifyTheResourceIsNotCreated()
        {
            if (Common.id == "" || Common.id == null)
            {
                ReportingHelpers.ChildTest.Pass("No resouce created");
            }

          else  BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);

        }


        [Then(@"I retrieve data using unique key received after successful Post Request")]
        public void ThenIRetrieveDataUsingUniqueKeyReceivedAfterSuccessfulPostRequest()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
        }


        [When(@"I retrieve data using unique key by Get Request for Agreements")]
        public void WhenIRetrieveDataUsingUniqueKeyByGetRequestForAgreements(Table featureData)
        {
            Common.id = APIDatahelper.getFeatureData(featureData, "hrn");
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
        }

        [When(@"I update payload of Agreements for patch request")]
        public void WhenIUpdatePayloadOfAgreementsForPatchRequest(Table table)
        {
            UpdatePayload(table);
        }

        [When(@"I update payload of Agreements for put request")]
        public void WhenIUpdatePayloadOfAgreementsForPutRequest(Table table)
        {
            UpdatePayload(table);
        }

        [When(@"I perform Patch request for Agreements")]
        public void WhenIPerformPatchRequestForAgreements()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.patchRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [Then(@"I validate status code for Patch request")]
        public void ThenIValidateStatusCodeForPatchRequest()
        {
            APIHelper.validateStatusCodePatch();
        }

        [When(@"I perform Delete request")]
        public void WhenIPerformDeleteRequest()
        {
           APIHelper.deleteRequest<AgreementsModel>(Common.endpoint, "",Common.keyword_BearerToken);

        }

        [Then(@"I validate status code for post request")]
        public void ThenIValidateStatusCodeForPostRequest()
        {
            APIHelper.validateStatusCodePostas204();
        }

        [When(@"I perform Put request for Agreements")]
        public void WhenIPerformPutRequestForAgreements()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.putRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }


        [When(@"I create payload for Patch request")]
        public void WhenICreatePayloadForPatchRequest(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }

        [When(@"I perform Patch request for Agreements by using the new patch payload")]
        public void WhenIPerformPatchRequestForAgreementsByUsingTheNewPatchPayload()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.patchRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }

        [Then(@"I validate Sort by ""(.*)"" in Get Request for Agreements")]
        public void ThenIValidateSortByInGetRequestForAgreements(string p0)
        {
               Common.keyword_Param_val = p0;
                BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "sort", Common.keyword_BearerToken);
                getSort(p0);
                     
        }

        [Then(@"I validate filter by ""(.*)"" with value ""(.*)"" in Get Request")]
        public void ThenIValidateFilterByWithValueInGetRequest(string p0, string p1)
        {
            string Param = "filter[" + p0 + "]";
            Common.keyword_Param_val = p1;
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, Param, Common.keyword_BearerToken);
            getFilter(p0);
        }

        [Then(@"I validate pagination by ""(.*)"" with value ""(.*)"" in Get Request")]
        public void ThenIValidatePaginationByWithValueInGetRequest(string p0, string p1)
        {
            string Param = "pagination[" + p0 + "]";
            Common.keyword_Param_val = p1;
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, Param, Common.keyword_BearerToken);
            getPagination(p0);
        }

        [Then(@"I Validate ""(.*)"" attribute for Agreements")]
        public void ThenIValidateAttributeForAgreements(string p0)
        {
            APIHelper.validateparameter<AgreementsModel>(Common.endpoint, p0, APIHelper.GetJObjectValue(p0, Common.jsonObj), Common.id, Common.keyword_BearerToken);

        }



        [Then(@"I perform Get Request and Validate value of ""(.*)"" attribute is ""(.*)""")]
        public void ThenIPerformGetRequestAndValidateValueOfAttributeIs(string p0, string p1)
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
            validateParametersInGetResponse(p0, p1);
        }



    }


}
