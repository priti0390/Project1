using HeartFramework.Base;
using HeartFramework.Config;
using HeartFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HeartFramework.Extensions
{
    public static class WebDriverExtension
    {
        public static string TakeScreenShot(this IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            var filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
            ss.SaveAsFile(Settings.ReportPath + filename);
            return filename;
        }

        public static void WaitForDocumentLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(drv =>
            {
                string state = drv.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, Settings.Timeout);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        public static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }


        public static void SwitchWindow(this IWebDriver driver)
        {

            String ParentWindowHandle = driver.CurrentWindowHandle;

            List<String> subwindow =  driver.WindowHandles.ToList();

            foreach (String handle in subwindow)
            {
                if(!ParentWindowHandle.Equals(handle))
                {

                    driver.SwitchTo().Window(handle);
                    
                }
                    
            }

        }

        /// <summary>
        /// Verify PageTitle of current page
        /// </summary>
        public static void AssertPageTitle(this IWebDriver driver, string name)
        {

            if (driver.Title.Equals(name))
            {
                ReportingHelpers.ChildTest.Pass(name + " :Page Title is same");
                 
            }
            else
            {
                ReportingHelpers.ChildTest.Fail(name + " :Page Title is not same");

            }      
           //     return pagetitle;


        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeout)
        {
            if (timeout > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        /// <summary>
        /// Verify for a certain text to be present in the url of the current page
        /// </summary>
        public static void AssertUrlContains(this IWebDriver driver, string name)
        {

            if (driver.Url.Contains(name))
            {
                ReportingHelpers.ChildTest.Pass(name + " :The driver URL contains this text");

            }
            else
            {
                ReportingHelpers.ChildTest.Fail(name + " :The driver URL does not contains this text");

            }
            //     return driverUrl;
            

        }

        /// <summary>
        /// To wait for the page to be loaded
        /// </summary>
        public static void WaitForReady(this IWebDriver driver)
        {
            try
            {
                
                    WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(10));
                    wait.Until(Driver =>
                    {
                        bool isAjaxFinished = (bool)((IJavaScriptExecutor)Driver).
                            ExecuteScript("return jQuery.active == 0");
                        bool isLoaderHidden = (bool)((IJavaScriptExecutor)Driver).
                            ExecuteScript("return $('.spinner').is(':visible') == false");
                        return isAjaxFinished & isLoaderHidden;
                    });
                
            }    
            catch (Exception Eee)
            {
                LogHelpers.error(Eee+ " = [Error]");
            }
            
            
        }

    }   
}