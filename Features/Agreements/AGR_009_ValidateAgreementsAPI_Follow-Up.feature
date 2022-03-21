@Smoke @agreements
Feature: AGR_009_ValidateAgreementsAPI_Follow-Up
Description: Automate and validate different Follow-up API

## ******************* POST REQUEST *********************************

Scenario: AGR_009_01_ValidateAgreementsAPI_Create_Follow-up_Postrequest

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload of Agreements for Post request for Follow-up API
        | description     | followUpDate          | isPrivate | notes  | attachments/0/name | attachments/0/url            | 
        | QA_description | 8909-01-22             | true      | string | attachmentsname    | www.hcg.com                  |
       When I perform Post request for follow-up API
        Given I Set UP URL For APIs with Endpoint as "api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
        Then I perform Get Request and Validate value of "description" attribute is "QA_description" for Agreements Follow-up
        Then I perform Get Request and Validate value of "isPrivate" attribute is "true" for Agreements Follow-up
        Then I perform Get Request and Validate value of "notes" attribute is "string" for Agreements Follow-up
        Then I perform Get Request and Validate value of "attachments/0/url" attribute is "www.hcg.com" for Agreements Follow-up



       
 Scenario: AGR_009_02_ValidateAgreementsAPI_Update_Follow-up_Putrequest

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
       When I update payload of Agreements for put request
        | description     | followUpDate          | isPrivate | notes  | attachments/0/name | attachments/0/url            | 
        | QA_description | 8909-01-22             | true      | string | attachmentsname    | www.hcg.com                  |
       When I perform Put request for follow-up API
       Then I validate status code for Put requests
        Given I Set UP URL For APIs with Endpoint as "api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
        Then I perform Get Request and Validate value of "description" attribute is "QA_description" for Agreements Follow-up
        Then I perform Get Request and Validate value of "notes" attribute is "string" for Agreements Follow-up
        Then I perform Get Request and Validate value of "attachments/0/url" attribute is "www.hcg.com" for Agreements Follow-up


       
 Scenario: AGR_009_03_ValidateAgreementsAPI_Update_Follow-up_Patchrequest

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
        When I update payload of Agreements for patch request
        | description     | followUpDate          | isPrivate | notes  | attachments/0/name | attachments/0/url            | 
        | QA_description | 2022-01-20             |false     | newstring | attachmentsname    | www.hcg.com                  |
       When I perform Patch request for follow-up API
	   Then I validate status code for Patch request
        Given I Set UP URL For APIs with Endpoint as "api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
        Then I perform Get Request and Validate value of "description" attribute is "QA_description" for Agreements Follow-up
        Then I perform Get Request and Validate value of "notes" attribute is "string" for Agreements Follow-up
        Then I perform Get Request and Validate value of "attachments/0/url" attribute is "www.hcg.com" for Agreements Follow-up


          
 Scenario: AGR_009_04_ValidateAgreementsAPI_Complete_Follow-up_Postrequest

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups/{id}/complete"
        When I update payload of Agreements for put request
        | description     | followUpDate          | isPrivate | notes  | attachments/0/name | attachments/0/url            | 
        | QA_description | 8909-01-2022             |false     | newstring | attachmentsname    | www.hcg.com                  |
       When I perform Post request for follow-up API 
	   Then I validate status code for post request
        Given I Set UP URL For APIs with Endpoint as "api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
        Then I perform Get Request and Validate value of "description" attribute is "QA_description" for Agreements Follow-up
        Then I perform Get Request and Validate value of "notes" attribute is "string" for Agreements Follow-up
        Then I perform Get Request and Validate value of "attachments/0/url" attribute is "www.hcg.com" for Agreements Follow-up
        Then I perform Get Request and Validate value of "status" attribute is "Complete" for Agreements Follow-up
       

            
Scenario: AGR_009_05_ValidateAgreementsAPI_Delete_Follow-up_Deleterequest

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups/{id}"
        When I perform Delete request for follow-up API
        Then I validate status code for Delete requests
    

  Scenario: AGR_009_06_ValidateAgreementsAPI_GetAll_Follow-up_Getrequest
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups"
        When I perform Get request for follow-up API
        Then I validate status code for Get requests
        Then I validate Sort by "followUpDate" in Get Request for follow-up API
         Then I validate Sort by "completedDate" in Get Request for follow-up API
         Then I validate Sort by "createdBy" in Get Request for follow-up API
         Then I validate Sort by "description" in Get Request for follow-up API
         Then I validate Sort by "status" in Get Request for Agreements
         Then I validate filter by "status" with value "Not Complete" in Get Request
         Then I validate filter by "status" with value "Complete" in Get Request
         Then I validate filter by "description" with value "QA_description" in Get Request
         Then I validate filter by "createdBy" with value "System Administrator" in Get Request
         Then I validate filter by "completedDate" with value "2022-03-04T06:31:55.7682000" in Get Request
         Then I validate filter by "followUpDate" with value "8909-01-22T00:00:00.0000000" in Get Request
         Then I validate pagination by "pageSize" with value "65" in Get Request
         Then I validate pagination by "offset" with value "6" in Get Request

        
  Scenario: AGR_009_07_ErrorMessageValidation_Follow-upAPI
   #Payload when  required field "description" is missing in follow-up API
      Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups"
      When I generate payload of Agreements for Post request for Follow-up API
         | followUpDate          | isPrivate | notes  | attachments/0/name | attachments/0/url            | 
         | 8909-01-22             | true      | string | attachmentsname    | www.hcg.com                  |
      When I perform Post request for follow-up API
      Then I Validate the error message for missing required field description in post request
      Then I verify the resource is not created
      
       #Payload when  required field "followUpDate" is missing in follow-up API
      Given I Set UP URL For APIs with Endpoint as "/api/agreements/hrn:hrs:agreements:642/follow-ups"
      When I generate payload of Agreements for Post request for Follow-up API
         | description          | isPrivate | notes  | attachments/0/name | attachments/0/url            | 
         | QA_description       | true      | string | attachmentsname    | www.hcg.com                  |
      When I perform Post request for follow-up API
      Then I Validate the error message for missing required field followUpDate in post request
      Then I verify the resource is not created