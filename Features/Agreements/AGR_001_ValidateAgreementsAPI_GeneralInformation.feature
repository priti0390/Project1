@Smoke @agreements
Feature: AGR_001_ValidateAgreementsAPI_GeneralInformation
Description: Validate GET, POST, PUT and PATCH Requests for Agreements 1


## ******************** GET REQUEST **********************************.
Scenario: AGR_001_01_ValidateAgreementsAPI_GeneralInformation_GetRequest
         Given I Set UP URL For APIs with Endpoint as "api/agreements"
         And I Retrieve Token Key for API
         And I Validate Expiry for API Token
         When I perform Get request for Agreements
         Then I validate status code for Get requests
         Then I validate Sort by "id" in Get Request for Agreements
         Then I validate Sort by "dateModified" in Get Request for Agreements
         Then I validate filter by "id" with value "CTA00481" in Get Request
         Then I validate filter by "title" with value "PUT_QA_Title" in Get Request
         Then I validate pagination by "pageSize" with value "50" in Get Request
         


## ******************* POST REQUEST *********************************
Scenario: AGR_001_02_ValidateAgreementsAPI_GeneralInformation_PostRequest

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Agreements for Post request for GeneralInformation API
        | id              | firstDraftTobeGeneratedInternally | title              | principalInvestigator/hrn | primaryContact/hrn | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn                     | otherPersonnel/1/hrn                    | agreementType/hrn             | agreementDraftDocument/hrn        | agreementDraftDocument/name |
        | QA_id_DateStamp | false                             | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         |     hrn:hrs:persons:801                 |        hrn:hrs:persons:301              | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:documents:123             |   sample.pdf    |
    	When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created

## ********************* PUT REQUEST *********************************
Scenario: AGR_001_03_ValidateAgreementsAPI_GeneralInformation_PutRequest

     Given I Set UP URL For APIs with Endpoint as "api/agreements"
     Then I retrieve data using unique key received after successful Post Request
     When I update payload of Agreements for put request
        | id              | firstDraftTobeGeneratedInternally | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | agreementType/hrn             | agreementDraftDocument/hrn        | agreementDraftDocument/name |
        | QA_id_DateStamp | false                             | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:documents:123             |   sample.pdf    |
     When I perform Put request for Agreements
	 Then I validate status code for Put requests
     And I Validate "title" attribute for Agreements
     And I Validate "principalInvestigator/hrn" attribute for Agreements
     And I Validate "primaryContact/hrn" attribute for Agreements
     And I Validate "responsibleUnit/hrn" attribute for Agreements
       And I Validate "counterParties/0/organization/hrn" attribute for Agreements
       And I Validate "counterParties/0/person/hrn" attribute for Agreements
       And I Validate "agreementType/hrn" attribute for Agreements

       
## ********************* PATCH REQUEST *********************************
Scenario: AGR_001_04_ValidateAgreementsAPI_GeneralInformation_PatchRequest

    Given I Set UP URL For APIs with Endpoint as "api/agreements"
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:765 |
    And I update payload of Agreements for patch request
    | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | agreementType/hrn | agreementDraftDocument/hrn        | agreementDraftDocument/name |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         |     hrn:hrs:persons:801                 |        hrn:hrs:persons:301              | hrn:hrs:lists:agrmt-types/CDA |hrn:hrs:documents:123 |   sample.pdf    |
   	When I perform Patch request for Agreements
	Then I validate status code for Patch request
      And I Validate "principalInvestigator/hrn" attribute for Agreements
     And I Validate "primaryContact/hrn" attribute for Agreements
     And I Validate "responsibleUnit/hrn" attribute for Agreements
       And I Validate "counterParties/0/organization/hrn" attribute for Agreements
       And I Validate "counterParties/0/person/hrn" attribute for Agreements
       And I Validate "agreementType/hrn" attribute for Agreements


          ## ********************* error messages validations *********************************

          Scenario: AGR_001_05_ErrorMessageValidationforGeneralInformationAPI

         #Payload when  required field "principalInvestigator" is missing in General Information API
         When I generate payload for Agreements for Post request for GeneralInformation API
                | id              | title               | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | agreementType/hrn |
        | QA_id_DateStamp | QA_Title_DateStamp   | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         |     hrn:hrs:persons:801                 |        hrn:hrs:persons:301              | hrn:hrs:lists:agrmt-types/CDA |
        When I perform Post request for Agreements
        Then I Validate the error message for missing required field principalInvestigator in post request
        Then I verify the resource is not created

        #Payload when  required field "primaryContact" is missing in General Information API
         When I generate payload for Agreements for Post request for GeneralInformation API
                | id              | title               |  principalInvestigator/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | agreementType/hrn |
        | QA_id_DateStamp | QA_Title_DateStamp   | hrn:hrs:persons:801 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         |     hrn:hrs:persons:801                 |        hrn:hrs:persons:301              | hrn:hrs:lists:agrmt-types/CDA |
        When I perform Post request for Agreements
        Then I Validate the error message for  missing required field primaryContact  in post request
        Then I verify the resource is not created

        #Payload when  required field "agreementType" is missing in General Information API
         When I generate payload for Agreements for Post request for GeneralInformation API
                | id              | title              | principalInvestigator/hrn | primaryContact/hrn | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn |
                | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301| hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         |     hrn:hrs:persons:801                 |        hrn:hrs:persons:301              | 
        When I perform Post request for Agreements
        Then I Validate the error message for missing required field agreementType  in post request
        Then I verify the resource is not created

        #Payload when  required field "responsibleUnit" is missing in General Information API
         When I generate payload for Agreements for Post request for GeneralInformation API
                | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | counterParties/0/organization/hrn | counterParties/0/person/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | agreementType/hrn |
                | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:persons:801  | hrn:hrs:persons:301  |   hrn:hrs:lists:agrmt-types/CDA                |
        When I perform Post request for Agreements
        Then I Validate the error message for missing required field responsibleUnit  in post request
        Then I verify the resource is not created

        #Payload when  required field "counterParties" is missing in General Information API
         When I generate payload for Agreements for Post request for GeneralInformation API
                | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | agreementType/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn |
                | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3  |  hrn:hrs:lists:agrmt-types/CDA     |     hrn:hrs:persons:801                 |        hrn:hrs:persons:301              | 
        When I perform Post request for Agreements
        Then I Validate the error message for missing required field counterParties  in post request
        Then I verify the resource is not created