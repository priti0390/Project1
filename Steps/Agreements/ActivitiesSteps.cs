using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using TechTalk.SpecFlow;
using HRSData.Pages.Agreements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeartFramework.Helpers;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;

using OpenQA.Selenium;
using System.Threading;

using OpenQA.Selenium.Support.UI;


namespace HeartTest.Steps.Delta
{
    [Binding]
    public class ActivitiesSteps : APIHelper
    {

        [When(@"I perform Post request for Agreements Activities")]
        public void WhenIPerformPostRequestForAgreementsActivities()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
            if (!(Common.id == "" || Common.id == null))
                AGRCommon.agrHrn = Common.id;
        }


        [When(@"I perform Post request without request body for Agreements Activities")]
        public void WhenIPerformPostRequestWithoutRequestBodyForAgreementsActivities()
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken);
            if (!(Common.id == "" || Common.id == null))
                AGRCommon.agrHrn = Common.id;
        }


        [Then(@"I Validate the error message that activity ""(.*)"" is not allowed in ""(.*)"" state in Agreements")]
        public void ThenIValidateTheErrorMessageThatActivityIsNotAllowedInStateInAgreements(string p0, string p1)
        {
           string err = "Cannot execute "+p0 + " action in state " + p1;

            APIHelper.ValidateExpectedError(Common.id, 400, err);
        }

        [Then(@"I verify ""(.*)"" activity is not allowed in ""(.*)"" state and validate the error message")]
        public void ThenIVerifyActivityIsNotAllowedInStateAndValidateTheErrorMessage(string p0, string p1)
        {
             BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken);
            if (!(Common.id == "" || Common.id == null))
              AGRCommon.agrHrn = Common.id;

            string err = "Cannot execute " + p0 + " action in state " + p1;
            APIHelper.ValidateExpectedError(Common.id, 400, err);

            if (Common.id == "" || Common.id == null)
            {
                ReportingHelpers.ChildTest.Pass("No resouce created");
            }

            else BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);

        }

        [Then(@"I verify ""(.*)"" activity with request body is not allowed in ""(.*)"" state and validate the error message")]
        public void ThenIVerifyActivityWithRequestBodyIsNotAllowedInStateAndValidateTheErrorMessage(string p0, string p1)
        {
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, Common.jsonObj, Common.keyword_BearerToken);
            if (!(Common.id == "" || Common.id == null))
                AGRCommon.agrHrn = Common.id;

            string err = "Cannot execute " + p0 + " action in state " + p1;
            APIHelper.ValidateExpectedError(Common.id, 400, err);

            if (Common.id == "" || Common.id == null)
            {
                ReportingHelpers.ChildTest.Pass("No resouce created");
            }

            else BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, Common.id);
        }


        [Then(@"I perform Get Request and Validate value of ""(.*)"" attribute is ""(.*)"" for Agreements Activities")]
        public void ThenIPerformGetRequestAndValidateValueOfAttributeIsForAgreementsActivities(string p0, string p1)
        {
        BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, AGRCommon.agrHrn);
            validateParametersInGetResponse(p0, p1);
        }

        [Given(@"I execute ""(.*)"" activity using Post request and activity state is updated to ""(.*)""")]
        public void GivenIExecuteActivityUsingPostRequestAndActivityStateIsUpdatedTo(string p0, string p1)
        {
            AGRCommon.agrSetUrl("/api/agreements/{hrn}/actions/"+p0);
            BaseModel<AgreementsModel>.currentServicePage = APIHelper.postRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken);
            if (!(Common.id == "" || Common.id == null))
                AGRCommon.agrHrn = Common.id;

            AGRCommon.agrSetUrl("api/agreements");

            BaseModel<AgreementsModel>.currentServicePage = APIHelper.getRequest<AgreementsModel>(Common.endpoint, "", Common.keyword_BearerToken, AGRCommon.agrHrn);
            validateParametersInGetResponse("activityState", p1);

        }



    }


}
