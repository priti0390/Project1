using HeartFramework.BaseAPI;
using HeartFramework.Config;
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
    public class DocumentService : APIHelper
    {

        [When(@"I perform Get Request for Document Service")]
        public void WhenIPerformGetRequestForDocumentService()
        {
            BaseModel<DocumentModel>.currentServicePage = APIHelper.getRequest<DocumentModel>(Common.endpoint, Common.id, Common.keyword_BearerToken, "");
        }


        [When(@"I generate payload of Document service")]
        public void WhenIGeneratePayloadOfDocumentService(Table e)
        {
            APIDatahelper.featureToJSON<DocumentModel>(e);
        }

       
        [When(@"I perform Post request for Document service with document as ""(.*)""")]
        public void WhenIPerformPostRequestForDocumentServiceWithDocumentAs(string p0)
        {
            BaseModel<DocumentModel>.currentServicePage = APIHelper.postRequest<DocumentModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken, Environment.CurrentDirectory.ToString() + Settings.jsonfilepath + Common.WordDocPath+p0);
        }

        [When(@"I perform Post request for Document service")]
        public void WhenIPerformPostRequestForDocumentService()
        {
            BaseModel<DocumentModel>.currentServicePage = APIHelper.postRequest<DocumentModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
        }



        [Then(@"I Validate hrn for Document service")]
        public void ThenIValidateHrnForDocumentService()
        {
            APIHelper.validateparameter<DocumentModel>(Common.endpoint, "hrn", APIHelper.GetJObjectValue("hrn", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate filename for Document Service")]
        public void ThenIValidateFilenameForDocumentService()
        {
            APIHelper.validateparameter<DocumentModel>(Common.endpoint, "versions/0/fileName", APIHelper.GetJObjectValue("versions/0/fileName", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate currentVersion for Document Service")]
        public void ThenIValidateCurrentVersionForDocumentService()
        {
            APIHelper.validateparameter<DocumentModel>(Common.endpoint, "currentVersion", APIHelper.GetJObjectValue("currentVersion", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }

        [Then(@"I Validate versionAction for Document")]
        public void ThenIValidateVersionActionForDocument()
        {
            APIHelper.validateparameter<DocumentModel>(Common.endpoint, "versions/0/versionAction", APIHelper.GetJObjectValue("versions/0/versionAction", Common.jsonObj), Common.id, Common.keyword_Bearer);
        }
        [When(@"I retrieve data using ID for Document service")]
        public void WhenIRetrieveDataUsingIDForDocumentService()
        {
            APIHelper.setJsonobject();
        }

        [When(@"I generate payload for Document Service for Post request")]
        public void WhenIGeneratePayloadForDocumentServiceForPostRequest(Table e)
        {
            APIDatahelper.featureToJSON<DocumentModel>(e);
        }

        [Then(@"I Validate ""(.*)"" in generated Document after comparison")]
        public void ThenIValidateInGeneratedDocumentAfterComparison(string p0)
        {
            DocumentServices.validateDocumentParameter(p0);
        }
    }
}
