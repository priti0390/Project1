using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using HeartFramework.Base;
using HeartFramework.Helpers;
using NUnit.Framework;

namespace HeartFramework.Config
{
    public class ConfigReader
    {        
        public static void SetFrameworkSettings()
        {
            try
            {
                if (TestContext.Parameters["run"]!=null)
                {
                    Settings.Run = TestContext.Parameters["run"];
                }
                else
                {
                    Settings.Run = ConfigurationManager.AppSettings["run"];
                }

                Settings.MongodbHost = ConfigurationManager.AppSettings["mongodbHost"];
                Settings.MongodbPort = int.Parse(ConfigurationManager.AppSettings["mongodbPort"]);

                if (TestContext.Parameters["klovServer"] != null)
                {
                    Settings.KlovServer = TestContext.Parameters["klovServer"];
                }
                else
                {
                    Settings.KlovServer = ConfigurationManager.AppSettings["klovServer"];
                }

                if (TestContext.Parameters["aut"] != null)
                {
                    Settings.AUT = TestContext.Parameters["aut"];
                }
                else
                {
                    Settings.AUT = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].AUT;
                }

                if (TestContext.Parameters["aut2"] != null)
                {
                    Settings.AUT2 = TestContext.Parameters["aut2"];
                }
                else
                {
                    Settings.AUT2 = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].AUT2;
                }

                if (TestContext.Parameters["aut3"] != null)
                {
                    Settings.AUT3 = TestContext.Parameters["aut3"];
                }
                else
                {
                    Settings.AUT3 = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].AUT3;
                }

                Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].Browser);
                Settings.PlatformType = (PlatformType)Enum.Parse(typeof(PlatformType), HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].Platform);
                Settings.TestType = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].TestType;
                Settings.LogPath = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].LogPath;
                Settings.Environment = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].Environment;

                Settings.TimeStampFormat = ConfigurationManager.AppSettings["timeStampFormat"];
                Settings.TimeStamp = DateTime.Now.ToString(Settings.TimeStampFormat);

                if (TestContext.Parameters["report"] != null)
                {
                    Settings.ReportPath = Environment.CurrentDirectory.ToString() + "\\Report\\";
                    Settings.ReportFilename = "HeartReport.html";
                }
                else
                {
                    Settings.ReportPath = Settings.LogPath + "\\Reports\\Run_" + Settings.TimeStamp + "\\";
                    Settings.ReportFilename = "HeartReport_" + Settings.TimeStamp + ".html";
                }
                Console.WriteLine("Setting Report Path : " + Settings.ReportPath + Settings.ReportFilename);

                if (!Directory.Exists(Settings.ReportPath))
                    Directory.CreateDirectory(Settings.ReportPath);
                

                Settings.TestData = HeartTestConfiguration.HeartSettings.TestSettings[Settings.Run].TestData;

                if (TestContext.Parameters["gridUrl"] != null)
                {
                    Settings.GridServer = TestContext.Parameters["gridUrl"];
                }
                else
                {
                    Settings.GridServer = ConfigurationManager.AppSettings["gridUrl"];
                }
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }

    }
}
