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
using TechTalk.SpecFlow;

namespace HeartFramework.Helpers
{
    public class ReportingHelpers
    {
        private static readonly ExtentReports _instance = new ExtentReports();
        //private static readonly ExtentReports Instance = null;
        public static ExtentTest Test, ChildTest;
        public static ExtentTest Feature, Scenario;

        static ReportingHelpers()
        {
            //var htmlReporter = new ExtentHtmlReporter(Settings.ReportPath + Settings.ReportFilename);
            var htmlReporter = new ExtentV3HtmlReporter(Settings.ReportPath + Settings.ReportFilename);      
            
            htmlReporter.Config.DocumentTitle = "Heart Report";
            htmlReporter.Config.ReportName = Settings.Environment + " " + Settings.TestType;

            Instance.AttachReporter(htmlReporter);
            Instance.AddSystemInfo("Username", Environment.UserName);
            Instance.AddSystemInfo("Machine", Environment.MachineName);
            Instance.AddSystemInfo("AUT", Settings.AUT);
        }
        private ReportingHelpers() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
        public static ExtentTest CreateTest(string name, string description)
        {
            Test = Instance.CreateTest(name, description);
            return Test;
        }

        // <summary>
        // Creates Child Test, to show Mulitple scenarios
        // </summary>
        public static ExtentTest CreateChildTest(string name)
        {
            ChildTest = Test.CreateNode(name);
            return ChildTest;
        }

        public static void CreateFeature(String name, String description)
        {
            Feature = Instance.CreateTest(name, description);
        }

        public static void CreateScenario(String name)
        {
            Scenario = Feature.CreateNode(name);
        }
    }
}
