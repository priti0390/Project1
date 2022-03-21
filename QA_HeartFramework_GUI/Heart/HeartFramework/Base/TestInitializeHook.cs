using AventStack.ExtentReports;
using HeartFramework.Config;
using HeartFramework.Extensions;
using HeartFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        /// <summary>
        /// Initialize Settings, Excel TestData, Loggers
        /// </summary>
        public static void InitializeSettings()
        {
            try
            {
                Console.WriteLine("************* Reading Config *************");

                //Set all the settings for framework
                ConfigReader.SetFrameworkSettings();
                Console.WriteLine("************* Loading Test Data *************");

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                string fileName = Environment.CurrentDirectory.ToString() + Settings.TestData;
                ExcelHelpers.ExcelToDataTable(fileName);

                Console.WriteLine("************* Creating log file *************");
                //Set Log
                LogHelpers.CreateLogFile();

                //Open Browser
                //OpenBrowser(Settings.PlatformType, Settings.BrowserType);

                LogHelpers.info("Initialized framework");
            }
            catch (Exception e)
            {
                Console.WriteLine("************* Exception : " + e.Message);
                e.GetBaseException();
                LogHelpers.error(e.Message);
                ReportingHelpers.ChildTest.Fail(e.InnerException, AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromPath(DriverContext.Driver.TakeScreenShot()).Build());

            }

        }

        /// <summary>   
        /// Initialize Selenium Driver
        /// </summary>
        public static void InitializeDriver()
        {
            try
            {
                //Open Browser
                OpenBrowser(Settings.PlatformType, Settings.BrowserType);

                LogHelpers.info("Initialized Driver");
            }
            catch (Exception e)
            {
                LogHelpers.error(e.Message);
                ReportingHelpers.ChildTest.Fail(e.InnerException, MediaEntityBuilder.CreateScreenCaptureFromPath(DriverContext.Driver.TakeScreenShot()).Build());
                e.GetBaseException();
            }
        }

        /// <summary>
        /// Choose Driver based on Grid value
        /// </summary>
        public static void OpenBrowser(PlatformType platform = PlatformType.Windows, BrowserType browserType = BrowserType.Firefox)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            if (Settings.GridServer.Equals(""))
            {
                LocalDriver(browserType);
            }
            else
            {
                RemoteDriver(browserType, platform);
            }
        }

        /// <summary>
        /// Initialize Local WebDriver
        /// </summary>
        private static void LocalDriver(BrowserType browserType)
        {
            //Settings.TempPath = Path.GetTempPath() + "\\heart";
            Guid id = Guid.NewGuid();
            Settings.TempPath = Environment.CurrentDirectory.ToString() + "\\Data\\Temp\\" + id;
            if (!Directory.Exists(Settings.TempPath))
                Directory.CreateDirectory(Settings.TempPath);

            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--start-maximized");
                    chromeOptions.AddArguments("--no-sandbox");
                    chromeOptions.AddArguments("--disable-dev-shm-usage");

                    var downloadDirectory = Settings.TempPath;
                    chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

                    DriverContext.Driver = new ChromeDriver(chromeOptions);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Initialize Remote WebDriver
        /// </summary>
        [Obsolete]
        private static void RemoteDriver(BrowserType browserType, PlatformType platform)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            if (platform.Equals(PlatformType.Windows))
            {
                switch (browserType)
                {
                    case BrowserType.InternetExplorer:
                        capabilities.SetCapability("browserName", "internet explorer");
                        break;
                    case BrowserType.Firefox:
                        capabilities.SetCapability("browserName", "firefox");
                        break;
                    case BrowserType.Chrome:
                        capabilities.SetCapability("browserName", "chrome");
                        capabilities.SetCapability(CapabilityType.AcceptInsecureCertificates, true);
                        capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                        break;
                }
            }
            else
            {
                switch (platform)
                {
                    case PlatformType.Mac:
                        capabilities.SetCapability("platformName", "MAC");
                        capabilities.SetCapability("browserName", "safari");
                        break;
                //    case PlatformType.Android:
                //        capabilities = DesiredCapabilities.Android();
                //        capabilities.SetCapability("deviceName", "TA93303A3F");
                //        capabilities.SetCapability("platformName", "Android");
                //        capabilities.SetCapability("platformVersion", "5.1");
                //        capabilities.SetCapability(CapabilityType.BrowserName, "Chrome");
                //        capabilities.SetCapability("skip_first_run_ui", "true");
                //        var url = new Uri("http://10.230.1.94:4723/wd/hub");
                //        break;
                //    case PlatformType.iOS:
                //        capabilities = DesiredCapabilities.IPad();
                //        capabilities.SetCapability("deviceName", "AK iPad");
                //        capabilities.SetCapability("UDID", "d0bb0546e0fe6628fcd0df4bc6b0861234d1a213");
                //        capabilities.SetCapability("platformName", "iOS");
                //        capabilities.SetCapability("automationName", "XCUITest");
                //        capabilities.SetCapability("platform", "iOS");
                //        //capabilities.SetCapability("platformVersion", "10.3.2");
                //        capabilities.SetCapability(CapabilityType.BrowserName, "Safari");
                //        break;
                }
            }

            DriverContext.Driver = new RemoteWebDriver(new Uri(Settings.GridServer), capabilities);
            DriverContext.Browser = new Browser(DriverContext.Driver);
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.info("Opened the browser !!!");
        }
        public virtual void NavigatepSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT2);
            LogHelpers.info("Opened the browser !!!");
        }
        public virtual void NavigateAUT3()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT3);
            LogHelpers.info("Opened the browser !!!");
        }

    }
}
