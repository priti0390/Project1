using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;

namespace HeartTest.Steps.Delta
{
    [Binding]
    public class GeneralInformationSteps : APIHelper
    {

        [When(@"I generate payload for Agreements for Post request for GeneralInformation API")]
        public void WhenIGeneratePayloadOfAgreementsForPostRequestForGeneralInformationAPI(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }

        [Then(@"I Validate the error message for missing required field principalInvestigator in post request")]
        public void ThenIValidateTheErrorMessageForRequiredFieldPrincipalInvestigatorInPostRequest()
        {
            string err = "Principal Investigator value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

       

        [Then(@"I Validate the error message for  missing required field primaryContact  in post request")]
        public void ThenIValidateTheErrorMessageForMissingRequiredFieldPrimaryContactInPostRequest()
        {
            string err = "Primary Contact value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }



        [Then(@"I Validate the error message for missing required field agreementType  in post request")]
        public void ThenIValidateTheErrorMessageForRequiredFieldAgreementTypeInPostRequest()
        {
            string err = "Agreement type value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }

        [Then(@"I Validate the error message for missing required field responsibleUnit  in post request")]
        public void ThenIValidateTheErrorMessageForMissingRequiredFieldResponsibleUnitInPostRequest()
        {
            string err = "Responsible Unit value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for missing required field counterParties  in post request")]
        public void ThenIValidateTheErrorMessageForMissingRequiredFieldCounterPartiesInPostRequest()
        {

            string err = "At least one Counter Party value is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }







    }


}
