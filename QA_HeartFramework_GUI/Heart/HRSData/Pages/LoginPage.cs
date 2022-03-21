using HeartFramework.Base;
using HeartFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRSData.Pages.Portal
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "username")]
        IWebElement inpUserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement inpPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Login')]")]
        IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='GlobalNavigation']/div[1]/div/a[6]")]
        IWebElement SiteAdminlink { get; set; }

        public void loginPortal(String username, String password)
        {
            inpUserName.Clear();
            inpUserName.SendKeys(username);
            inpPassword.Clear();
            inpPassword.SendKeys(password);
            btnLogin.Click();
        }

        public void loginCPIPPortal(string user, string pass)
        {
            if (DriverContext.Driver.Title.Contains(GenericValidationElements.CPIP_CtrlBusTitle))
            {
                ReportingHelpers.ChildTest.Pass("Login Session for control bus already exists");
            }
            else
            {
                Thread.Sleep(2000);
                SendKeys.SendWait(user);
                Thread.Sleep(500);
                SendKeys.SendWait(@"{Tab}");
                Thread.Sleep(500);
                SendKeys.SendWait(pass);
                Thread.Sleep(500);
                SendKeys.SendWait(@"{Tab}");
                Thread.Sleep(500);
                SendKeys.SendWait(@"{Enter}");
            }


        }
    }
}