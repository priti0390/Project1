using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;

namespace HeartTest.Steps.Delta
{
    [Binding]
    public class CDASteps : APIHelper
    {

       
      
        [When(@"I generate payload of Agreements for Post request for CDA API")]
        public void WhenIGeneratePayloadOfAgreementsForPostRequestForCDAAPI(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }
            

        [Then(@"I Validate the error message for conditional field PurposeOfExchangeOther in post request")]
        public void ThenIValidateTheErrorMessageForConditionalFieldPurposeOfExchangeOtherInPostRequest()
        {
            string err = "purposeOfInformationExchangeOther value is not valid if purposeOfInformationExchange selected item is not Other";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for conditional field DescriptionOfConfidentialInformation in post request")]
        public void ThenIValidateTheErrorMessageForConditionalFieldDescriptionOfConfidentialInformationInPostRequest()
        {
            string err = "DescriptionOfConfidentialInformation value is not valid if DirectionOfTransfer selected item is not Outgoing or Mutual";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

  

    }


}
