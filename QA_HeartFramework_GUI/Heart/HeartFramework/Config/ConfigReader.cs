using HeartFramework.Base;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;


namespace HeartFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();
            Config config = configurationRoot.GetSection("Config").Get<Config>();

            try
            {
                if (TestContext.Parameters["run"] != null)
                {
                    Settings.Run = TestContext.Parameters["run"];
                }
                else
                {
                    Settings.Run = config.AppSettings.run;
                }


                if (TestContext.Parameters["gridUrl"] != null)
                {
                    Settings.GridServer = TestContext.Parameters["gridUrl"];
                }
                else
                {
                    Settings.GridServer = config.AppSettings.gridUrl;
                }

                Settings.TimeStampFormat = config.AppSettings.timeStampFormat;
                Settings.TimeStamp = DateTime.Now.ToString(Settings.TimeStampFormat);

                //TestSettings index
                int index = getValueIndex(config);

                if (TestContext.Parameters["aut"] != null)
                {
                    Settings.AUT = TestContext.Parameters["aut"];
                }
                else
                {
                    Settings.AUT = config.TestSettings[index].aut;
                }

                if (TestContext.Parameters["aut2"] != null)
                {
                    Settings.AUT2 = TestContext.Parameters["aut2"];
                }
                else
                {
                    Settings.AUT2 = config.TestSettings[index].aut2;
                }

                if (TestContext.Parameters["aut3"] != null)
                {
                    Settings.AUT3 = TestContext.Parameters["aut3"];
                }
                else
                {
                    Settings.AUT3 = config.TestSettings[index].aut3;
                }

                Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), config.TestSettings[index].browser);
                Settings.PlatformType = (PlatformType)Enum.Parse(typeof(PlatformType), config.TestSettings[index].platform);
                Settings.TestType = config.TestSettings[index].testType;
                Settings.LogPath = config.TestSettings[index].logPath;
                Settings.Environment = config.TestSettings[index].environment;
                Settings.TestData = config.TestSettings[index].testData;
               // Settings.TimeStampFormat = ConfigurationManager.AppSettings["timeStampFormat"];
               // Settings.TimeStamp = DateTime.Now.ToString(Settings.TimeStampFormat);

                if (TestContext.Parameters["report"] != null)
                {
                    Settings.ReportPath = Environment.CurrentDirectory.ToString() + "\\Report\\";
                    Settings.ReportFilename = "HeartReport.html";
                }
                else
                {
                    Settings.ReportPath = Settings.LogPath + "Reports\\Run_" + Settings.TimeStamp + "\\";
                    Settings.ReportFilename = "HeartReport_" + Settings.TimeStamp + ".html";
                }
                Console.WriteLine("Setting Report Path : " + Settings.ReportPath + Settings.ReportFilename);

                if (!Directory.Exists(Settings.ReportPath))
                    Directory.CreateDirectory(Settings.ReportPath);

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

        }

        public static int getValueIndex(Config config)
        {
            for (int i = 0; i < config.TestSettings.Count; i++)
            {
                if (config.TestSettings[i].name.Equals(Settings.Run))
                    return i;
            }
            return -1;
        }
    }
}
