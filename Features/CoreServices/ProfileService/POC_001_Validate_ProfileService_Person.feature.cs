// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace HeartTest.Features.CoreServices.ProfileService
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("POC_001_Validate_ProfileService_Person")]
    [NUnit.Framework.CategoryAttribute("coreservices")]
    [NUnit.Framework.CategoryAttribute("ProfileService")]
    [NUnit.Framework.CategoryAttribute("Person")]
    [NUnit.Framework.CategoryAttribute("Smoke")]
    public partial class POC_001_Validate_ProfileService_PersonFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "coreservices",
                "ProfileService",
                "Person",
                "Smoke"};
        
#line 1 "POC_001_Validate_ProfileService_Person.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/CoreServices/ProfileService", "POC_001_Validate_ProfileService_Person", @"<b>Description</b>: Testing Profile Service - Person for below test scenarios
<br>a) Validated four different requests-> Get, Post, Put & Patch
<br>b) Authenticated API via Bearer Based Token
<br>c) Validating status codes for multiple requests
<br>d) Validating schema for payload and responses
<br>e) Validating each parameter values against post and put requests
<br>f) Validating above scenarios for mutliple rows of test data for Post & Put request", ProgrammingLanguage.CSharp, new string[] {
                        "coreservices",
                        "ProfileService",
                        "Person",
                        "Smoke"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("POC_001_001_Validate_ProfileService_Person_GetRequest")]
        public virtual void POC_001_001_Validate_ProfileService_Person_GetRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("POC_001_001_Validate_ProfileService_Person_GetRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 15
 testRunner.Given("I Set UP URL For APIs with Endpoint as \"api/persons\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
    testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
    testRunner.When("I perform Get Request for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
 testRunner.Then("I validate status code for Get requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
    testRunner.And("I Validate content type for response as \"application/json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("POC_001_002_Validate_ProfileService_Person_PostRequest")]
        public virtual void POC_001_002_Validate_ProfileService_Person_PostRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("POC_001_002_Validate_ProfileService_Person_PostRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 28
 testRunner.Given("I Set UP URL For APIs with Endpoint as \"api/persons\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 29
    testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
    testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table372 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "firstName",
                            "lastName",
                            "contactInformation/city"});
                table372.AddRow(new string[] {
                            "QA_id_DateStamp",
                            "firstName_DateStamp",
                            "lastName_DateStamp",
                            "SPJ"});
                table372.AddRow(new string[] {
                            "QA_id_DateStamp",
                            "firstName_DateStamp",
                            "lastName_DateStamp",
                            "SPJ"});
                table372.AddRow(new string[] {
                            "QA_id_DateStamp",
                            "firstName_DateStamp",
                            "lastName_DateStamp",
                            "SPJ"});
#line 31
    testRunner.When("I generate payload of Profile service - Person Service for Post request", ((string)(null)), table372, "When ");
#line hidden
#line 36
    testRunner.And("I Validate Schema of Profile service - Person Service for request payload having " +
                        "schemafile as \"ProfileService_Person_Schema.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.When("I perform Post request for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
    testRunner.Then("I Validate all new records after post request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
     testRunner.Then("I Validate firstName parameter for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 40
     testRunner.And("I Validate lastName parameter for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 41
     testRunner.And("I Validate content type for all response as \"application/json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("POC_001_003_Validate_ProfileService_Person_PutRequest")]
        public virtual void POC_001_003_Validate_ProfileService_Person_PutRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("POC_001_003_Validate_ProfileService_Person_PutRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
    testRunner.Given("I Set UP URL For APIs with Endpoint as \"api/persons\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 48
    testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
    testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
    testRunner.When("I retrieve data using ID via Get Request for Profile service - Person Service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table373 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "firstName",
                            "lastName",
                            "contactInformation/city",
                            "hrn"});
                table373.AddRow(new string[] {
                            "QA_id_DateStamp",
                            "firstName_DateStamp",
                            "lastName_DateStamp",
                            "SPJ_Native_DateStamp",
                            "hrn:hrs:persons:_DateStamp"});
                table373.AddRow(new string[] {
                            "QA_id_DateStamp",
                            "firstName_DateStamp",
                            "lastName_DateStamp",
                            "SPJ_Native_DateStamp",
                            "hrn:hrs:persons:_DateStamp"});
                table373.AddRow(new string[] {
                            "QA_id_DateStamp",
                            "firstName_DateStamp",
                            "lastName_DateStamp",
                            "SPJ_Native_DateStamp",
                            "hrn:hrs:persons:_DateStamp"});
#line 51
    testRunner.And("I update payload of Profile service - Person Service for put request", ((string)(null)), table373, "And ");
#line hidden
#line 56
    testRunner.And("I Update \"hrn\" in all request payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.When("I perform Put request for Profile service - Person Service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.Then("I validate status code for all Put requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
    testRunner.And("I Validate city under contactInformation parameter for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
    testRunner.And("I Validate content type for all response as \"application/json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("POC_001_004_Validate_ProfileService_Person_PatchRequest")]
        public virtual void POC_001_004_Validate_ProfileService_Person_PatchRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("POC_001_004_Validate_ProfileService_Person_PatchRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 67
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 68
    testRunner.Given("I Set UP URL For APIs with Endpoint as \"api/persons\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 69
    testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 70
    testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
    testRunner.When("I retrieve data against mutliple parameter value for Profile service - Person Ser" +
                        "vice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table374 = new TechTalk.SpecFlow.Table(new string[] {
                            "lastName",
                            "hrn",
                            "dateModified"});
                table374.AddRow(new string[] {
                            "lastName_Patch_DateStamp",
                            "hrn:hrs:persons:_DateStamp",
                            "2022-12-30"});
                table374.AddRow(new string[] {
                            "lastName_Patch_DateStamp",
                            "hrn:hrs:persons:_DateStamp",
                            "2022-12-30"});
                table374.AddRow(new string[] {
                            "lastName_Patch_DateStamp",
                            "hrn:hrs:persons:_DateStamp",
                            "2022-12-30"});
#line 73
    testRunner.And("I provide attributes against Profile service - Person for patch request", ((string)(null)), table374, "And ");
#line hidden
#line 78
    testRunner.And("I Update \"hrn\" in all request payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
    testRunner.When("I perform Patch request for Profile service - Person Service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
 testRunner.Then("I validate status code for all Patch requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
    testRunner.And("I Validate lastName parameter for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("POC_001_005_Validate_ProfileService_Person_GetpersonbyHRN")]
        public virtual void POC_001_005_Validate_ProfileService_Person_GetpersonbyHRN()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("POC_001_005_Validate_ProfileService_Person_GetpersonbyHRN", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 87
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 88
 testRunner.Given("I Set UP URL For APIs with Endpoint as \"api/persons/hrn:hrs:persons:6746\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 89
 testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
    testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 91
    testRunner.When("I perform Get Request for Profile service - Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 92
 testRunner.Then("I validate status code for Get requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 93
    testRunner.And("I Validate content type for response as \"application/json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 94
    testRunner.And("I validate that value of \"hrn\" attribute is \"hrn:hrs:persons:6746\" in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
