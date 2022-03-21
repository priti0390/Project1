using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;

namespace HeartTest.Steps.Delta
{
    [Binding]
    public class FollowUpSteps : APIHelper
    {

        [When(@"I generate payload of Agreements for Post request for Follow-up API")]
        public void WhenIGeneratePayloadOfAgreementsForPostRequestForFollow_UpAPI(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }

        [When(@"I perform Put request for follow-up API")]
        public void WhenIPerformPutRequestForFollow_UpAPI()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.putRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }


        [Then(@"I perform Get Request and Validate value of ""(.*)"" attribute is ""(.*)"" for Agreements Follow-up")]
        public void ThenIPerformGetRequestAndValidateValueOfAttributeIsForAgreementsFollow_Up(string p0, string p1)
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, AGRCommon.agrHrn);
            validateParametersInGetResponse(p0, p1);
        }


        [When(@"I perform Post request for follow-up API")]
        public void WhenIPerformPostRequestForFollow_UpAPI()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }


        [When(@"I perform Patch request for follow-up API")]
        public void WhenIPerformPatchRequestForFollow_UpAPI()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.patchRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);

        }

        [When(@"I perform Get request for follow-up API")]
        public void WhenIPerformGetRequestForFollow_UpAPI()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken);
        }

        [Then(@"I Validate the error message for missing required field description in post request")]
        public void ThenIValidateTheErrorMessageForMissingRequiredFieldDescriptionInPostRequest()
        {
            string err = "Description value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for missing required field followUpDate in post request")]
        public void ThenIValidateTheErrorMessageForMissingRequiredFieldFollowUpDateInPostRequest()
        {
            string err = "Follow-Up Date value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [When(@"I perform Delete request for follow-up API")]
        public void WhenIPerformDeleteRequestForFollow_UpAPI()
        {
            APIHelper.deleteRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken);
        }

        [Then(@"I validate status code for Delete requests")]
        public void ThenIValidateStatusCodeForDeleteRequests()
        {
            APIHelper.validateStatusCodeDeleteas204();
        }

        
        [Then(@"I validate Sort by ""(.*)"" in Get Request for follow-up API")]
        public void ThenIValidateSortByInGetRequestForFollow_UpAPI(string p0)
        {
            Common.keyword_Param_val = p0;
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "sort", Common.keyword_BearerToken);
            getSort(p0);
        }




    }
}
