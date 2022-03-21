@Agreements
Feature: TC_001_ValidateAgreementsSmartform
Description: Testing smartform UI - Update 1

Scenario: TC_001_ValidateAgreementsSmartform
     Given I Navigate to Agreements site
    #And I login to Agreements site
   And   I Login as a "Test" role

     And I navigate to Agreements tab
     And I click on Create Agreement link
     And I navigate to Smartform
     Then I validate the Smartform
  
