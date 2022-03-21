﻿// ------------------------------------------------------------------------------
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
namespace HeartTest.Features.Agreements
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AGR_003_ValidateAgreementsAPI_MTA-Incoming")]
    [NUnit.Framework.CategoryAttribute("Smoke")]
    [NUnit.Framework.CategoryAttribute("agreements")]
    public partial class AGR_003_ValidateAgreementsAPI_MTA_IncomingFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "Smoke",
                "agreements"};
        
#line 1 "AGR_003_ValidateAgreementsAPI_MTA-Incoming.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Agreements", "AGR_003_ValidateAgreementsAPI_MTA-Incoming", "\tDescription: Validate GET, POST, PUT and PATCH Requests for MTA Agreements API ", ProgrammingLanguage.CSharp, new string[] {
                        "Smoke",
                        "agreements"});
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
        [NUnit.Framework.DescriptionAttribute("AGR_003_01_ValidateAgreementsAPI_MTA-Incoming-Internal_PostRequest")]
        public virtual void AGR_003_01_ValidateAgreementsAPI_MTA_Incoming_Internal_PostRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AGR_003_01_ValidateAgreementsAPI_MTA-Incoming-Internal_PostRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 8
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
#line 9
        testRunner.Given("I Set UP URL For APIs with Endpoint as \"/api/agreements\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
        testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
        testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "title",
                            "firstDraftTobeGeneratedInternally",
                            "principalInvestigator/hrn",
                            "primaryContact/hrn",
                            "agreementType/hrn",
                            "responsibleUnit/hrn",
                            "counterParties/0/organization/hrn",
                            "counterParties/0/person/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/sowDocuments/0/name",
                            "agreementTypeData/sowFundingProjects",
                            "agreementTypeData/sowFundingProjectOther",
                            "agreementTypeData/sowProjectDocuments"});
                table21.AddRow(new string[] {
                            "Agreement MTA Test 514",
                            "true",
                            "hrn:hrs:persons:801",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:orgs:309",
                            "hrn:hrs:orgs:3",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "sow agreement1",
                            "null",
                            "null",
                            "null"});
#line 12
         testRunner.When("I generate payload of Agreements for Post request for MTA-Incoming API", ((string)(null)), table21, "When ");
#line hidden
#line 15
         testRunner.When("I perform Post request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
        testRunner.Then("I Validate new record after post request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
        testRunner.Then("I perform Get request and verify the resource created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
      testRunner.And("I Validate \"agreementType/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
      testRunner.And("I Validate \"agreementTypeData/directionMaterialTransfer/hrn\" attribute for Agreem" +
                        "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
        testRunner.And("I Validate \"agreementTypeData/sowFundSource/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AGR_003_02_ValidateAgreementsAPI_MTA-Incoming-Internal_PutRequest")]
        public virtual void AGR_003_02_ValidateAgreementsAPI_MTA_Incoming_Internal_PutRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AGR_003_02_ValidateAgreementsAPI_MTA-Incoming-Internal_PutRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 25
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
#line 26
     testRunner.Given("I Set UP URL For APIs with Endpoint as \"/api/agreements\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 27
     testRunner.Then("I retrieve data using unique key received after successful Post Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "agreementType/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDocuments/0/name",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription"});
                table22.AddRow(new string[] {
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "The material is a modification of ATCC CCL-247see",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "sow agreement1",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "The recipient will trace the site of DNA replication in live cells."});
#line 28
      testRunner.When("I update payload of Agreements for put request", ((string)(null)), table22, "When ");
#line hidden
#line 31
     testRunner.When("I perform Put request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 32
  testRunner.Then("I validate status code for Put requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
      testRunner.And("I Validate \"agreementType/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
       testRunner.And("I Validate \"agreementTypeData/directionMaterialTransfer/hrn\" attribute for Agreem" +
                        "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
        testRunner.And("I Validate \"agreementTypeData/sowFundSource/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AGR_003_03_ValidateAgreementsAPI_MTA-Incoming-Internal_PatchRequest")]
        public virtual void AGR_003_03_ValidateAgreementsAPI_MTA_Incoming_Internal_PatchRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AGR_003_03_ValidateAgreementsAPI_MTA-Incoming-Internal_PatchRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 39
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
#line 41
   testRunner.Given("I Set UP URL For APIs with Endpoint as \"/api/agreements\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "hrn"});
                table23.AddRow(new string[] {
                            "hrn:hrs:agreements:712"});
#line 42
    testRunner.When("I retrieve data using unique key by Get Request for Agreements", ((string)(null)), table23, "When ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "agreementType/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDocuments/0/name",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription"});
                table24.AddRow(new string[] {
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "sow agreement1",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "The recipient will trace the site of DNA replication in live cells."});
#line 45
    testRunner.And("I update payload of Agreements for patch request", ((string)(null)), table24, "And ");
#line hidden
#line 48
    testRunner.When("I perform Patch request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
 testRunner.Then("I validate status code for Patch request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
       testRunner.And("I Validate \"agreementTypeData/directionMaterialTransfer/hrn\" attribute for Agreem" +
                        "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 51
        testRunner.And("I Validate \"agreementTypeData/sowFundSource/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AGR_003_04_ValidateAgreementsAPI_MTA-Incoming-External_PostRequest")]
        public virtual void AGR_003_04_ValidateAgreementsAPI_MTA_Incoming_External_PostRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AGR_003_04_ValidateAgreementsAPI_MTA-Incoming-External_PostRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 55
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
#line 56
testRunner.Given("I Set UP URL For APIs with Endpoint as \"/api/agreements\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 57
          testRunner.And("I Retrieve Token Key for API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 58
        testRunner.And("I Validate Expiry for API Token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "title",
                            "principalInvestigator/hrn",
                            "primaryContact/hrn",
                            "agreementType/hrn",
                            "responsibleUnit/hrn",
                            "counterParties/0/organization/hrn",
                            "counterParties/0/person/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowDocuments/0/name",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/sowFundingProjects/0/id",
                            "agreementTypeData/sowFundingProjects/1/id",
                            "agreementTypeData/sowFundingProjectOther",
                            "agreementTypeData/sowProjectDocuments/0/url"});
                table25.AddRow(new string[] {
                            "Agreement MTA Test 514",
                            "hrn:hrs:persons:801",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:orgs:309",
                            "hrn:hrs:orgs:3",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "sow agreement1",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/external",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "MTA00111",
                            "MTA00003",
                            "National Cancer Institute",
                            "https://agreementdocs.s3.us-east-2.amazonaws.com/angiogenesis.pdf"});
#line 59
                 testRunner.When("I generate payload of Agreements for Post request for MTA-Incoming API", ((string)(null)), table25, "When ");
#line hidden
#line 62
     testRunner.When("I perform Post request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
        testRunner.Then("I Validate new record after post request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
        testRunner.Then("I perform Get request and verify the resource created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
         testRunner.And("I Validate \"agreementType/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
          testRunner.And("I Validate \"agreementTypeData/directionMaterialTransfer/hrn\" attribute for Agreem" +
                        "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
        testRunner.And("I Validate \"agreementTypeData/sowFundSource/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AGR_003_05_ValidateAgreementsAPI_MTA-Incoming-External_PutRequest")]
        public virtual void AGR_003_05_ValidateAgreementsAPI_MTA_Incoming_External_PutRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AGR_003_05_ValidateAgreementsAPI_MTA-Incoming-External_PutRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 73
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
#line 74
     testRunner.Given("I Set UP URL For APIs with Endpoint as \"/api/agreements\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 75
   testRunner.Then("I retrieve data using unique key received after successful Post Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "agreementType/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowDocuments/0/name",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/sowFundingProjects/0/id",
                            "agreementTypeData/sowFundingProjects/1/id",
                            "agreementTypeData/sowFundingProjectOther",
                            "agreementTypeData/sowProjectDocuments/0/url"});
                table26.AddRow(new string[] {
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "The material is a modification of ATCC CCL-247seekk",
                            "sow agreement1",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/external",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "MTA00111",
                            "MTA00003",
                            "National Cancer Institute",
                            "https://agreementdocs.s3.us-east-2.amazonaws.com/angiogenesis.pdf"});
#line 76
     testRunner.When("I update payload of Agreements for put request", ((string)(null)), table26, "When ");
#line hidden
#line 79
   testRunner.When("I perform Put request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
     testRunner.Then("I validate status code for Put requests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
      testRunner.And("I Validate \"agreementType/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
      testRunner.And("I Validate \"agreementTypeData/description\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
       testRunner.And("I Validate \"agreementTypeData/directionMaterialTransfer/hrn\" attribute for Agreem" +
                        "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
        testRunner.And("I Validate \"agreementTypeData/sowFundSource/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AGR_003_06_ValidateAgreementsAPI_MTA-Incoming-External_PatchRequest")]
        public virtual void AGR_003_06_ValidateAgreementsAPI_MTA_Incoming_External_PatchRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AGR_003_06_ValidateAgreementsAPI_MTA-Incoming-External_PatchRequest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 92
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
#line 94
   testRunner.Given("I Set UP URL For APIs with Endpoint as \"/api/agreements\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "hrn"});
                table27.AddRow(new string[] {
                            "hrn:hrs:agreements:712"});
#line 95
    testRunner.When("I retrieve data using unique key by Get Request for Agreements", ((string)(null)), table27, "When ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "agreementType/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowDocuments/0/name",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/sowFundingProjects/0/id",
                            "agreementTypeData/sowFundingProjects/1/id",
                            "agreementTypeData/sowFundingProjectOther",
                            "agreementTypeData/sowProjectDocuments/0/url"});
                table28.AddRow(new string[] {
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "sow agreement1",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/external",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "MTA00111",
                            "MTA00003",
                            "National Cancer Institute",
                            "https://agreementdocs.s3.us-east-2.amazonaws.com/angiogenesis.pdf"});
#line 98
   testRunner.When("I update payload of Agreements for patch request", ((string)(null)), table28, "When ");
#line hidden
#line 101
    testRunner.When("I perform Patch request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 102
 testRunner.Then("I validate status code for Patch request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 103
      testRunner.And("I Validate \"agreementTypeData/directionMaterialTransfer/hrn\" attribute for Agreem" +
                        "ents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
        testRunner.And("I Validate \"agreementTypeData/sowFundSource/hrn\" attribute for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "title",
                            "firstDraftTobeGeneratedInternally",
                            "principalInvestigator/hrn",
                            "primaryContact/hrn",
                            "agreementType/hrn",
                            "responsibleUnit/hrn",
                            "counterParties/0/organization/hrn",
                            "counterParties/0/person/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/sowFundingProjects/0/id",
                            "agreementTypeData/sowFundingProjects/1/id"});
                table29.AddRow(new string[] {
                            "Agreement MTA Test 514",
                            "true",
                            "hrn:hrs:persons:801",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:orgs:309",
                            "hrn:hrs:orgs:3",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "MTA0021",
                            "MTA0022"});
#line 109
        testRunner.When("I generate payload of Agreements for Post request for CDA API", ((string)(null)), table29, "When ");
#line hidden
#line 112
        testRunner.When("I perform Post request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 113
        testRunner.Then("I Validate the error message for conditional field sowFundingProjects in post req" +
                        "uest", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 114
        testRunner.Then("I verify the resource is not created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "title",
                            "firstDraftTobeGeneratedInternally",
                            "principalInvestigator/hrn",
                            "primaryContact/hrn",
                            "agreementType/hrn",
                            "responsibleUnit/hrn",
                            "counterParties/0/organization/hrn",
                            "counterParties/0/person/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/origin/hrn"});
                table30.AddRow(new string[] {
                            "Agreement MTA Test 514",
                            "true",
                            "hrn:hrs:persons:801",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:orgs:309",
                            "hrn:hrs:orgs:3",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "hrn:hrs:lists:agrmt-mta-origin/other"});
#line 117
        testRunner.When("I generate payload of Agreements for Post request for CDA API", ((string)(null)), table30, "When ");
#line hidden
#line 120
        testRunner.When("I perform Post request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 121
        testRunner.Then("I Validate the error message for conditional field origin  in post request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 122
        testRunner.Then("I verify the resource is not created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "title",
                            "firstDraftTobeGeneratedInternally",
                            "principalInvestigator/hrn",
                            "primaryContact/hrn",
                            "agreementType/hrn",
                            "responsibleUnit/hrn",
                            "counterParties/0/organization/hrn",
                            "counterParties/0/person/hrn",
                            "agreementTypeData/directionMaterialTransfer/hrn",
                            "agreementTypeData/description",
                            "agreementTypeData/sowFundSource/hrn",
                            "agreementTypeData/sowDescription",
                            "agreementTypeData/origin/hrn"});
                table31.AddRow(new string[] {
                            "Agreement MTA Test 514",
                            "true",
                            "hrn:hrs:persons:801",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-types/MTA",
                            "hrn:hrs:orgs:309",
                            "hrn:hrs:orgs:3",
                            "hrn:hrs:persons:301",
                            "hrn:hrs:lists:agrmt-mta-direction-mt/incoming",
                            "Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see" +
                                "",
                            "hrn:hrs:lists:agrmt-mta-sow-fund-source/internal",
                            "The recipient will trace the site of DNA replication in live cells.",
                            "hrn:hrs:lists:agrmt-mta-origin/internal-tp"});
#line 125
        testRunner.When("I generate payload of Agreements for Post request for CDA API", ((string)(null)), table31, "When ");
#line hidden
#line 128
        testRunner.When("I perform Post request for Agreements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 129
        testRunner.Then("I Validate the error message for conditional field origin  in post request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 130
        testRunner.Then("I verify the resource is not created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion