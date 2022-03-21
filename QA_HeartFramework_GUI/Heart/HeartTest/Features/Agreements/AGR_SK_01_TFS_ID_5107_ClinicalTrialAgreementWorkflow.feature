@Agreements @Smoke	
Feature: AGR_SK_01_TFS_ID_5107_ClinicalTrialAgreementWorkflow

Scenario: AGR_SK_01_TFS_ID_5107_ClinicalTrialAgreementWorkflow
	
	#Login as PI
	Given I navigate to store link
	And   I Login as a "Principal Investigator" role
	When  I Navigate to Agreements Tab
	And   I Click on Create Agreement