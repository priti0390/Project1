using HeartFramework.Base;
using AventStack.ExtentReports;
using HeartFramework.Extensions;
using HeartFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System;
using System.Threading;

namespace HRSData.Pages
{
   public class AgreementsCommonReferences : BasePage
    {
        [FindsBy(How = How.Name, Using = "UserName")]
        IWebElement inpUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        IWebElement inpPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#submitButton")]
        IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='topbar-tab-Agreements']")]
        public IWebElement agreementsTabEle { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create Agreement')]")]
        public IWebElement createAgreementLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.container > div > div.modal-content.background-customizable.modal-content-mobile.visible-xs.visible-sm > div.modal-body > div:nth-child(2) > div:nth-child(1) > div > div > form > div > input")]
        public IWebElement SSOLoginLink { get; set; }


        public string AgreementType;

        public void login(String username, String password)
        {
            inpUserName.Clear();
            inpUserName.SendKeys(username);
            inpPassword.Clear();
            inpPassword.SendKeys(password);
            btnLogin.Click();
        }

        public void navigateToAgreementsTab()
        {
            agreementsTabEle.ClickEx();
        }
    }
}

