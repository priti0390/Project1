using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;

namespace HeartTest.Steps.Delta
{
    [Binding]
    public class CTASteps : APIHelper
    {



        [When(@"I generate payload of Agreements for Post request for CTA API")]
        public void WhenIGeneratePayloadOfAgreementsForPostRequestForCTAAPI(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }

        [Then(@"I Validate the error message for missing required field typeOfTrial in post request")]
        public void ThenIValidateTheErrorMessageForMissingRequiredFieldTypeOfTrialInPostRequest()
        {
            string err = "typeOfTrial is required";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for invalid  field sponsorProtocolNumber when typeOfTrial as hrn associated with radiobutton InitiatedAtOurInstitution")]
        public void ThenIValidateTheErrorMessageForInvalidFieldSponsorProtocolNumberWhenTypeOfTrialAsHrnAssociatedWithRadiobuttonInitiatedAtOurInstitution()
        {
            string err = "SponsorProtocolNumber value is not valid if TypeOfTrial selection value is not Industry Sponsored or Investigator Initiated at another institution";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for invalid  field CRO ,croOther, croContactPrimary ,croContactsOther   when willUseCro field is marked false")]
        public void ThenIValidateTheErrorMessageForInvalidFieldCROCroOtherCroContactPrimaryCroContactsOtherWhenWillUseCroFieldIsMarkedFalse()
        {
            ///* string err = "CRO (Contract research organization) value is not valid if value for WillUseCro is not true ,croOther value is not valid if value for willUseCro is not true*/ , croContactPrimary value is not valid if value for willUseCro is not true croContactsOther value is not valid if value for willUseCro is not true";
            string err = "CRO(Contract research organization) value is not valid if value for WillUseCro is not true croOther value is not valid if value for willUseCro is not true croContactPrimary value is not valid if value for willUseCro is not true croContactsOther value is not valid if value for willUseCro is not true";


            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for invalid  field CRO  when willUseCro field is marked false")]
        public void ThenIValidateTheErrorMessageForInvalidFieldCROWhenWillUseCroFieldIsMarkedFalse()
        {
            string err = "CRO (Contract research organization) value is not valid if value for WillUseCro is not true";


            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }

        [Then(@"I Validate the error message for invalid  field croContactsOther  when willUseCro field is marked false")]
        public void ThenIValidateTheErrorMessageForInvalidFieldCroContactsOtherWhenWillUseCroFieldIsMarkedFalse()
        {
            string err = "croContactsOther value is not valid if value for willUseCro is not true";


            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }

        [Then(@"I Validate the error message for invalid  field croOther  when willUseCro field is marked false")]
        public void ThenIValidateTheErrorMessageForInvalidFieldCroOtherWhenWillUseCroFieldIsMarkedFalse()
        {
            string err = "croOther value is not valid if value for willUseCro is not true";


            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }

        [Then(@"I Validate the error message for invalid field croContactPrimary when willUseCro field is marked false")]
        public void ThenIValidateTheErrorMessageForInvalidFieldCroContactPrimaryWhenWillUseCroFieldIsMarkedFalse()
        {
            string err = "croContactPrimary value is not valid if value for willUseCro is not true";


            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }




    }
}
