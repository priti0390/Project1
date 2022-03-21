using HeartFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Base
{
    public class Base : TechTalk.SpecFlow.Steps
    {
        public static BasePage CurrentPage { get; set; }
        public static string CurrentGenericType { get; set; }

        private IWebDriver _driver { get; set; }

        public static Dictionary<String, String> dataEx { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            CurrentGenericType = typeof(TPage).ToString();
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);
            CurrentPage = pageInstance;
            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage, new()
        {
            string UserLandingGenericType = typeof(TPage).ToString();
            if (!CurrentGenericType.Equals(UserLandingGenericType))
            {
                TPage UserLandingPage = new TPage();
                CurrentPage = UserLandingPage;
            }
            return (TPage)CurrentPage;
        }

    }
}
