using TechTalk.SpecFlow;
using HeartFramework.Base;
using HeartFramework.Helpers;
using HRSData.Pages;
using HRSData.Pages.Agreements;
using System;
using System.Collections.Generic;
using System.Threading;
using HRSData.Pages.Portal;
using HeartFramework;

namespace Agreements.Steps
{
    [Binding]
    public class SmartformSteps : BaseStep
    {

        [Given(@"I navigate to store link")]
        public void GivenINavigateToStoreLink()
        {
            NavigateSite();
        }

        [When(@"I Navigate to Agreements Tab")]
        public void WhenINavigateToAgreementsTab()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I Click on Create Agreement")]
        public void WhenIClickOnCreateAgreement()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I Navigate to Agreements site")]
        public void GivenINavigateToAgreementsSite()
        {
            NavigateSite();
        }

        [Given(@"I login to Agreements site")]
        public void GivenILoginToAgreementsSite()
        {
            dataEx = ExcelHelpers.getRowData("Accounts");
            GetInstance<AgreementsCommonReferences>().login(dataEx["Username"], dataEx["Password"]);

            ReportingHelpers.ChildTest.Pass("Logged in");
          //  CurrentPage.As<AgreementsCommonReferences>().login(dataEx["Username"], dataEx["Password"]);
        }

        [Given(@"I Login as a ""(.*)"" role")]
        public void ThenILoginAsARole(string role)
        {
            string PersonName = DataHelper.getCsvData("Person_Name");
            
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().loginPortal(dataEx["Username"], dataEx["Password"]);
            Thread.Sleep(2000);

        }


        [Given(@"I Assign Agreement type")]
        public void GivenIAssignAgreementType()
        {
            AGRConstants.Agreement_Type = DataHelper.getCsvData("Agr_Type");
        }

        [Given(@"I click on Create Agreement link")]
        public void GivenIClickOnCreateAgreementLink()
        {
            GetInstance<AgreementsCommonReferences>().createAgreementLink.Click();
        }

        [Given(@"I navigate to Smartform")]
        public void GivenINavigateToSmartform()
        {
            Console.WriteLine("I validated smartform");
        }

        [Then(@"I validate the Smartform")]
        public void ThenIValidateTheSmartform()
        {
            Console.WriteLine("I validated smartform");
        }

    }
}