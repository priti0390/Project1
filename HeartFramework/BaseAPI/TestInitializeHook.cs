//using AventStack.ExtentReports;
using AventStack.ExtentReports;
using HeartFramework.BaseAPI;
using HeartFramework.Config;
//using HeartFramework.Extensions;
using HeartFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.BaseAPI
{
    public abstract class TestInitializeHook
    {
        /// <summary>
        /// Initialize Settings, Excel TestData, Loggers
        /// </summary>
        public static void InitializeSettings()
        {
            try
            {
                Console.WriteLine("************* Reading Config *************");
                ConfigReader.SetFrameworkSettings();
                Console.WriteLine("************* Loading Test Data *************");
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                string excelFileName = Environment.CurrentDirectory.ToString() + Settings.TestData;
                ExcelHelpers.ExcelToDataTable(excelFileName);
                Console.WriteLine("************* Creating log file *************");
                LogHelpers.CreateLogFile();
                LogHelpers.info("Initialized framework");
            }
            catch (Exception e)
            {
                Console.WriteLine("************* Exception : " + e.Message);
                e.GetBaseException();
                LogHelpers.error(e.Message);
                //ReportingHelpers.ChildTest.Fail(e.InnerException, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromPath(DriverContext.Driver.TakeScreenShot()).Build());

            }

        }

        /// <summary>
        /// Initialize API Base URL and Endpoint
        /// </summary>
        public static void InitializeDriver()
        {
            try
            {
                    LogHelpers.info("Reading AUT Parameter :"+ Settings.AUT);
                    Settings_API.BaseURL = new Uri(Settings.AUT);
                    Settings_API.restclient = new RestClient(Settings.AUT);
                    Settings_API.restclient.BaseUrl = Settings_API.BaseURL;
            }
            catch (Exception e)
            {
                LogHelpers.error(e.Message);
                e.GetBaseException();
            }
        }


    }
}
