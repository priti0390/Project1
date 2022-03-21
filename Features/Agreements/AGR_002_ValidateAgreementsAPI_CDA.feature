@Smoke @agreements
Feature: AGR_002_ValidateAgreementsAPI_CDA
Description: Validate GET, POST, PUT and PATCH Requests for Agreements CDA API
1. Basic Positive flow for Post Request
2. Post for validating dependent fields validation


## ******************* POST REQUEST *********************************
Scenario: AGR_002_01_ValidateAgreementsAPI_CDA_PostRequest

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
          And I Retrieve Token Key for API
         And I Validate Expiry for API Token
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
        And I Validate "title" attribute for Agreements
        And I Validate "agreementType/hrn" attribute for Agreements
        And I Validate "agreementTypeData/purposeOfInformationExchange/hrn" attribute for Agreements
        And I Validate "agreementTypeData/purposeOfInformationExchangeOther" attribute for Agreements
        And I Validate "agreementTypeData/directionOfInformationTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/descriptionOfConfidentialInformation" attribute for Agreements


        ## ******************* POST REQUEST *********************************
Scenario: AGR_002_02_ValidateAgreementsAPI_CDA_PostRequest_FieldsDependencyValidation

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
            And I Retrieve Token Key for API
         And I Validate Expiry for API Token

         ## Need to support multi row data passing
    
        #Payload when "purposeOfInformationExchange" is 'facilitate-discussion-counter-party' or 'review-protocol' and hence conditional field "purposeOfInformationExchangeOther" -- Other is not valid 
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn                       | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/facilitate-discussion-counter-party | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements
        Then I Validate the error message for conditional field PurposeOfExchangeOther in post request
        Then I verify the resource is not created

     
        #Payload when "purposeOfInformationExchange" is "other" and hence conditional field "purposeOfInformationExchangeOther" -- Other is valid 
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation | 
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other        | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/outgoing          | test                                             |
    	When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
        And I Validate "agreementTypeData/purposeOfInformationExchange/hrn" attribute for Agreements
        And I Validate "agreementTypeData/purposeOfInformationExchangeOther" attribute for Agreements

        #Payload when "purposeOfInformationExchange" is 'review-protocol' or 'facilitate-discussion-counter-party' and no "purposeOfInformationExchangeOther" field in payload -- No error/valid scenario 
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn                           | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation | 
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/facilitate-discussion-counter-party     | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                             |
    	When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
        And I Validate "agreementTypeData/purposeOfInformationExchange/hrn" attribute for Agreements


        #Payload when "directionOfInformationTransfer" is 'incoming' and and hence conditional field "descriptionOfConfidentialInformation" in payload is not valid -- Error/invalid scenario 
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation | 
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other        | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/incoming          | test                                             |
    	When I perform Post request for Agreements
        Then I Validate the error message for conditional field DescriptionOfConfidentialInformation in post request
        Then I verify the resource is not created

        #Payload when "directionOfInformationTransfer" is 'incoming' and and hence no conditional field "descriptionOfConfidentialInformation" in payload is valid -- No Error/Valid scenario 
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn   | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/review-protocol | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                             |
    	When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
        And I Validate "agreementTypeData/directionOfInformationTransfer/hrn" attribute for Agreements

         #Payload when "directionOfInformationTransfer" is 'mutual' or 'outgoing' and and hence conditional field "descriptionOfConfidentialInformation" in payload is valid -- No Error/valid scenario 
        When I generate payload of Agreements for Post request for CDA API
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other        | Test Other Data with Post        | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                             |
    	When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
        And I Validate "agreementTypeData/directionOfInformationTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/descriptionOfConfidentialInformation" attribute for Agreements
               

## ********************* PUT REQUEST *********************************
Scenario: AGR_002_03_ValidateAgreementsAPI_CDA_PutRequest

     Given I Set UP URL For APIs with Endpoint as "api/agreements"
     Then I retrieve data using unique key received after successful Post Request
     When I update payload of Agreements for put request
      | id                  | title                  | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn   | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
      | Put_QA_id_DateStamp | Put_QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/review-protocol | null                                                | hrn:hrs:lists:agrmt-cda-dir-info-tra/outgoing          | test                                             |
     When I perform Put request for Agreements
	 Then I validate status code for Put requests
     And I Validate "title" attribute for Agreements

       
## ********************* PATCH REQUEST *********************************
Scenario: AGR_002_04_ValidateAgreementsAPI_CDA_PatchRequest

    Given I Set UP URL For APIs with Endpoint as "api/agreements"
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:2132 |
    And I update payload of Agreements for patch request
    | id              | title              | 
    | PATCH_QA_id | PATCH_QA_Title |
   	When I perform Patch request for Agreements
	Then I validate status code for Patch request
     And I Validate "title" attribute for Agreements
    When I create payload for Patch request
    | id              | title              |
    | QA_id_DateStamp | QA_Title_DateStamp |  
   	When I perform Patch request for Agreements by using the new patch payload
    Then I validate status code for Patch request
     And I Validate "title" attribute for Agreements



    ## ******************** GET REQUEST **********************************.

Scenario: AGR_002_05_ValidateAgreementsAPI_CDA_GetRequest
         Given I Set UP URL For APIs with Endpoint as "api/agreements"
         And I Retrieve Token Key for API
         And I Validate Expiry for API Token
         When I perform Get request for Agreements
         Then I validate status code for Get requests
         Then I validate Sort by "id" in Get Request for Agreements
         Then I validate Sort by "dateModified" in Get Request for Agreements
         Then I validate Sort by "title" in Get Request for Agreements
         Then I validate filter by "id" with value "CDA02894" in Get Request
        Then I validate filter by "title" with value "PS Activities Test" in Get Request
         Then I validate pagination by "pageSize" with value "50" in Get Request