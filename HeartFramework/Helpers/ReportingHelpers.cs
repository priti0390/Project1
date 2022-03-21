using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using HeartFramework.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Helpers
{
    public class ReportingHelpers
    {
        private static readonly ExtentReports _instance = new ExtentReports();
        public static ExtentTest Test, ChildTest;
        public static ExtentTest Feature, Scenario;

        static ReportingHelpers()
        {
            var dir = Settings.ReportPath;            

            //var fileName = "HeartReport_" + Settings.TimeStamp + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + Settings.ReportFilename);

            htmlReporter.Configuration().ChartLocation = ChartLocation.Bottom;
            htmlReporter.Configuration().ChartVisibilityOnOpen = false;
            htmlReporter.Configuration().DocumentTitle = "Heart Report";
            htmlReporter.Configuration().ReportName = Settings.Environment + " " + Settings.TestType;
            

            if (!Settings.KlovServer.Equals(""))
            {
                var klovReporter = new KlovReporter();
                klovReporter.InitMongoDbConnection(Settings.MongodbHost, Settings.MongodbPort);
                klovReporter.ProjectName = Settings.Run.ToUpper();
                klovReporter.ReportName = "Build " + DateTime.Now.ToString();
                klovReporter.KlovUrl = Settings.KlovServer;
                Instance.AttachReporter(htmlReporter, klovReporter);
            }
            else
            {
                Instance.AttachReporter(htmlReporter);
            }            

            Instance.AddSystemInfo("Username", Environment.UserName);
            Instance.AddSystemInfo("Machine", Environment.MachineName);
            Instance.AddSystemInfo("OS", Settings.PlatformType.ToString());
            Instance.AddSystemInfo("Browser", Settings.BrowserType.ToString());
            Instance.AddSystemInfo("AUT", Settings.AUT);
            if (!Settings.AUT2.Equals(""))
                Instance.AddSystemInfo("AUT2", Settings.AUT2);
            if (!Settings.AUT3.Equals(""))
                Instance.AddSystemInfo("AUT3", Settings.AUT3);
        }

        private ReportingHelpers() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Creates Parent Test
        /// </summary>
        public static ExtentTest CreateTest(string name, string description)
        {
            Test = Instance.CreateTest(name, description);
            return Test;
        }

        /// <summary>
        /// Creates Child Test, to show Mulitple scenarios
        /// </summary>
        public static ExtentTest CreateChildTest(string name)
        {
            ChildTest = Test.CreateNode(name);
            return ChildTest;
        }

        public static void CreateFeature(String name, String description)
        {
            Feature = Instance.CreateTest<Feature>(name, description);
        }

        public static void CreateScenario(String name)
        {
            Scenario = Feature.CreateNode<Scenario>(name);
        }
    }
}
