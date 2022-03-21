using HeartFramework.Base;
using HeartFramework.Config;
using HeartFramework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HRSData.Steps.Hooks
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        [BeforeTestRun]
        public static void TestStart()
        {
            InitializeSettings();
        }

        [BeforeFeature]
        public static void FeatureStart(FeatureContext featureContext)
        {
            InitializeDriver();

            if (!featureContext.FeatureInfo.Tags.Contains(Settings.Run, StringComparer.OrdinalIgnoreCase))
            {
                throw new Exception("Test Config does not match with Tests Run Tags...");
            }

            ReportingHelpers.CreateTest(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            ReportingHelpers.Test.AssignCategory(featureContext.FeatureInfo.Tags);
            try
            {
                if (featureContext.FeatureInfo.Title != null)
                {
                    LogHelpers.info(featureContext.FeatureInfo.Title);
                }
            }
            catch (Exception e) { }

        }

        [BeforeScenario]
        public static void ScenarioStart(ScenarioContext scenarioContext)
        {
            ReportingHelpers.CreateChildTest(scenarioContext.ScenarioInfo.Title);
            //Add the logic to add into log
            LogHelpers.info("******************************************************************************************************************");
            LogHelpers.info("******************************************************************************************************************");
            LogHelpers.info(scenarioContext.ScenarioInfo.Title);
            LogHelpers.info("******************************************************************************************************************");
            LogHelpers.info("******************************************************************************************************************");
        }
        [AfterStep]
        public static void StepStop(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(scenarioContext, null);

            if (scenarioContext.TestError == null)
            {
                ReportingHelpers.ChildTest.Pass(stepType + " - " + ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                ReportingHelpers.ChildTest.Fail(stepType + " - '" + scenarioContext.StepContext.StepInfo.Text + "' - " + scenarioContext.TestError.Message);
            }
            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                ReportingHelpers.ChildTest.Skip(stepType + " - " + ScenarioStepContext.Current.StepInfo.Text);

            }
            //Commenting to debug reporting helper on priority
            typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus").SetValue(scenarioContext, ScenarioExecutionStatus.OK);


        }

        //[AfterScenario]
        //public static void AfterScenario(ScenarioContext scenarioContext)
        //{
        //    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
        //    var current = scenarioContext;
        //    if (current.TestError != null)
        //    {
        //        LogHelpers.error(stepType + " - '" + scenarioContext.StepContext.StepInfo.Text + "' - " + scenarioContext.TestError.Message);
        //        //TODO;
        //    }
        //}

        [AfterFeature]
        public static void FeatureStop()
        {
           
                DriverContext.Driver.Quit();
            
            ReportingHelpers.Instance.Flush();
        }

        [AfterTestRun]
        public static void TestStop()
        {
            
                DriverContext.Driver.Quit();
            
        }
        [TearDown]
        public static void TestTearDown()
        {
            TestContext.AddTestAttachment("C:\\HeartLogs\\Reports\\Run_202110061339235242\\Log_202110061339235242.txt");
        }
    }
}
/*Action allCollect = () =>
               {
                   GC.Collect();
                   GC.WaitForPendingFinalizers();
                   GC.Collect();
               };*/
