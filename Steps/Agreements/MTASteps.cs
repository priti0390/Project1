using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;

namespace HeartTest.Steps.Delta
{
    [Binding]
    public class MTASteps : APIHelper
    {

        [When(@"I generate payload of Agreements for Post request for MTA-Outgoing API")]
        public void WhenIGeneratePayloadOfAgreementsForPostRequestForMTA_OutgoingAPI(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);
        }

        [When(@"I generate payload of Agreements for Post request for MTA-Incoming API")]
        public void WhenIGeneratePayloadOfAgreementsForPostRequestForMTA_IncomingAPI(Table table)
        {
            APIDatahelper.featureToJSON<AgreementsModel>(table);

        }


        [Then(@"I Validate the error message for conditional field sowFundingProjects in post request")]
        public void ThenIValidateTheErrorMessageForConditionalFieldSowFundingProjectsInPostRequest()
        {
            string err = "SowFundingProjects value is not valid if SowFundSource value is not External Source";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }


        [Then(@"I Validate the error message for conditional field origin  in post request")]
        public void ThenIValidateTheErrorMessageForConditionalFieldOriginInPostRequest()
        {
            string err = "Origin value is not valid if DirectionMaterialTransfer value is not Outgoing";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }


        [Then(@"I Validate the error message for invalid  field exportingCountries when isExportingOutsideUsa field is marked false if directionMaterialTransfer is Outgoing  in post request")]
        public void ThenIValidateTheErrorMessageForInvalidFieldExportingCountriesWhenIsExportingOutsideUsaFieldIsMarkedFalseIfDirectionMaterialTransferIsOutgoingInPostRequest()
        {
            string err = "ExportingCountries value is not valid if IsExportingOutsideUsa is not True";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }


        [Then(@"I Validate the error message for invalid  field reimbursementAmount when isReimbursable field is marked false if directionMaterialTransfer is Outgoing  in post request")]
        public void ThenIValidateTheErrorMessageForInvalidFieldReimbursementAmountWhenIsReimbursableFieldIsMarkedFalseIfDirectionMaterialTransferIsOutgoingInPostRequest()
        {
            string err = "ReimbursementAmount value is not valid if IsReimbursable is not True";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I Validate the error message for invalid  field pocTechTransfer when isSubjectToPatent field is marked false if directionMaterialTransfer is Outgoing  in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFieldPocTechTransferWhenIsSubjectToPatentFieldIsMarkedFalseIfDirectionMaterialTransferIsOutgoingInPostRequest()
        {
            string err = "PocTechTransfer is not valid, if value to IsSubjectToPatent is not True";

            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }


        [Then(@"I Validate the error message for invalid  field originOther  when origin field   contains hrn corresponding to  Purchasedorprovidedbythirdparty radio button if directionMaterialTransfer is Outgoing  in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFieldWhenOriginFieldContainsHrnCorrespondingToPurchasedorprovidedbythirdpartyRadioButtonForIfDirectionMaterialTransferIsOutgoingInPostRequestForMTAAPI()
        {
            string err = "OriginOther value is not valid if Origin value is not Other";

            APIHelper.ValidateExpectedError(Common.id, 400, err);

        }



        [Then(@"I Validate the error message for invalid field originOther when origin field contains hrn corresponding to  Purchasedorprovidedbythirdparty radio button  if directionMaterialTransfer is Outgoing  in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFieldOriginOtherWhenOriginFieldContainsHrnCorrespondingToPurchasedorprovidedbythirdpartyRadioButtonIfDirectionMaterialTransferIsOutgoingInPostRequestForMTAAPI()
        {
            string err = "OriginOther value is not valid if Origin value is not Other";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }



        [Then(@"I Validate the error message for invalid  field originOther when origin field contains hrn corresponding to GeneratedInternallybythirdparty radio button if directionMaterialTransfer is Outgoing in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFieldOriginOtherWhenOriginFieldContainsHrnCorrespondingToGeneratedInternallybythirdpartyRadioButtonIfDirectionMaterialTransferIsOutgoingInPostRequestForMTAAPI()
        {
            string err = "OriginOther value is not valid if Origin value is not Other";

            APIHelper.ValidateExpectedError(Common.id, 400, err);


        }



        [Then(@"I Validate the error message for invalid  field originOther  when origin field contains hrn corresponding to GeneratedInternally radio button if directionMaterialTransfer is Outgoing  in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFieldOriginOtherWhenOriginFieldContainsHrnCorrespondingToGeneratedInternallyRadioButtonIfDirectionMaterialTransferIsOutgoingInPostRequestForMTAAPI()
        {
            string err = "OriginOther value is not valid if Origin value is not Other";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }



        [Then(@"I Validate the error message for invalid fundingProjects field when origin field contains hrn corresponding to GeneratedInternally radio button if directionMaterialTransfer is Outgoing  in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFundingProjectsFieldWhenOriginFieldContainsHrnCorrespondingToGeneratedInternallyRadioButtonIfDirectionMaterialTransferIsOutgoingInPostRequestForMTAAPI()
        {
            string err = "FundingProjects value is not valid, if value for Origin is not either Generated internally with third-party materials or Provided by or purchased from a third party";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }



        [Then(@"I Validate the error message for invalid fundingProjects field when origin field contains hrn corresponding to Other radio button if directionMaterialTransfer is Outgoing  in post request for MTA API")]
        public void ThenIValidateTheErrorMessageForInvalidFundingProjectsFieldWhenOriginFieldContainsHrnCorrespondingToOtherRadioButtonIfDirectionMaterialTransferIsOutgoingInPostRequestForMTAAPI()
        {
            string err = "FundingProjects value is not valid, if value for Origin is not either Generated internally with third-party materials or Provided by or purchased from a third party";

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }



    }
}
