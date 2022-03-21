@coreservices @ProfileService @Organization @Smoke
Feature: POC_001_Validate_ProfileService_Organization
<b>Description</b>: Testing Profile Service - Organization for below test scenarios
<br>a) Validated four different requests-> Get, Post, Put & Patch
<br>b) Authenticated API via Bearer Based Token
<br>c) Validating status codes for multiple requests
<br>d) Validating schema for payload and responses
<br>e) Validating each parameter values against post and put requests

## ******************** GET REQUEST ***************************************
#Scenario to handle Get request for Profile Service - Organization
Scenario: POC_001_001_Validate_ProfileService_Organization_GetRequest
	Given I Set UP URL For APIs with Endpoint as "api/organizations"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Get Request for Profile service - Organization
	Then I validate status code for Get requests
    And I validate Sort by "id" in Get Request for Profile service - Organization
    And I validate Sort by "dateModified" in Get Request for Profile service - Organization
    Then I validate filter by "id" with value "1009" in Get Request for Profile service - Organization

    #And I validate filter by "id" in Get Request for Profile service - Organization
    #     | id  |
    #     | 1009|      
    And I Validate content type for response as "application/json"

## ******************** POST REQUEST *********************************
 #Scenario to handle Post request for Profile Service - Organization
Scenario: POC_001_002_Validate_ProfileService_Organization_PostRequest
	Given I Set UP URL For APIs with Endpoint as "api/organizations"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I generate payload of Profile service - Organization Service for Post request
    | id              | name              | alias         | sourceIdentifier              | notes              | contactInformation/city | contactInformation/email | contactInformation/phone | contactInformation/country | contactInformation/postalCode | contactInformation/addressLine1 | contactInformation/addressLine2 | contactInformation/stateProvince | category/id                           | category/hrn                          | category/name | category/dateCreated | category/dateModified | functions/0/id                        | functions/0/hrn                       | functions/0/name | functions/0/dateCreated     | functions/0/dateModified    | active | dateCreated                 | dateModified                | customProperties | tags     | parent | hrn                 |
    | QA_id_DateStamp | QA_name_DateStamp | null          | QA_sourceIdentifier_DateStamp | QA_Notes_DateStamp | QA_City_DateStamp       | QA_Email_DateStamp       | DateStamp                | QA_Country_DateStamp       | DateStamp                     | QA_addressLine1_DateStamp       | QA_addressLine2_DateStamp       | OR                               | hrn:hrs:lists:org-categories/Division | hrn:hrs:lists:org-categories/Division | Division      |                      |                       | hrn:hrs:lists:org-functions/function1 | hrn:hrs:lists:org-functions/function1 | Function 1       | 2022-01-20T07:34:20.4869430 | 2022-01-20T07:34:20.4869430 | true   | 2022-01-20T07:34:20.4869430 | 2022-01-20T07:40:13.4006510 | null             | null     | null   | hrn:hrs:orgs:_DateStamp |
	When I perform Post request for Profile service - Organization
    Then I Validate new record after post request
     Then I Validate "notes" attribute for Profile service - Organization
     And I Validate "id" attribute for Profile service - Organization
       And I Validate "name" attribute for Profile service - Organization
       And I Validate "sourceIdentifier" attribute for Profile service - Organization
       And I Validate "contactInformation/city" attribute for Profile service - Organization
       And I Validate "contactInformation/email" attribute for Profile service - Organization
       And I Validate "contactInformation/phone" attribute for Profile service - Organization
    And I Validate "contactInformation/country" attribute for Profile service - Organization
    And I Validate "contactInformation/postalCode" attribute for Profile service - Organization
    And I Validate "contactInformation/addressLine1" attribute for Profile service - Organization
    And I Validate "contactInformation/addressLine2" attribute for Profile service - Organization
    And I Validate "contactInformation/stateProvince" attribute for Profile service - Organization
    And I Validate "category/id" attribute for Profile service - Organization
    And I Validate "category/hrn" attribute for Profile service - Organization
    And I Validate "category/name" attribute for Profile service - Organization
        And I Validate "customProperties" attribute for Profile service - Organization
        And I Validate "tags" attribute for Profile service - Organization
        And I Validate "parent" attribute for Profile service - Organization
     And I Validate content type for response as "application/json"

## ******************** PUT REQUEST *********************************
#Scenario to handle Put request for Profile Service - Organization
Scenario: POC_001_003_Validate_ProfileService_Organization_PutRequest
    Given I Set UP URL For APIs with Endpoint as "api/organizations"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I retrieve data using ID via Get Request for Profile service - Organization Service
    And I update payload of Profile service - Organization Service for put request
    | id              | name             | alias | sourceIdentifier              | notes     | contactInformation/city | contactInformation/email | contactInformation/phone | contactInformation/country | contactInformation/postalCode | contactInformation/addressLine1 | contactInformation/addressLine2 | contactInformation/stateProvince | category/id                           | category/hrn                          | category/name | category/dateCreated | category/dateModified | functions/0/id                        | functions/0/hrn                       | functions/0/name | functions/0/dateCreated     | functions/0/dateModified    | active | dateCreated                 | dateModified                | customProperties | tags | parent | hrn   |
    | QA_id_DateStamp | QA_Test_Name_DateStamp | null  | QA_sourceIdentifier_DateStamp | New Notes | MFP                     | testuser@gmail.com       | DateStamp                | QA_Country_DateStamp       | DateStamp                     | QA_addressLine1_DateStamp       | QA_addressLine2_DateStamp       | OR                               | hrn:hrs:lists:org-categories/Division | hrn:hrs:lists:org-categories/Division | Division      |                      |                       | hrn:hrs:lists:org-functions/function1 | hrn:hrs:lists:org-functions/function1 | Function 1       | 2022-01-20T07:34:20.4869430 | 2022-01-20T07:34:20.4869430 | true   | 2022-01-20T07:34:20.4869430 | 2022-01-20T07:40:13.4006510 | null             | null | null   | hrn:hrs:orgs:_DateStamp |
    And I Update "hrn" in request payload
 	When I perform Put request for Profile service - Organization Service
	Then I validate status code for Put requests
     Then I Validate "notes" attribute for Profile service - Organization
     Then I Validate "name" attribute for Profile service - Organization
    Then I Validate "contactInformation/city" attribute for Profile service - Organization
    Then I Validate "contactInformation/email" attribute for Profile service - Organization



    And I Validate content type for response as "application/json"

## ******************** PATCH REQUEST **********************************
#Scenario to handle Patch request for Profile Service - Organization
Scenario: POC_001_004_Validate_ProfileService_Organization_PatchRequest
    Given I Set UP URL For APIs with Endpoint as "api/organizations"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I retrieve data against parameter value for Profile service - Person Service
    #When I retrieve data against parameter value as "hrn:hrs:orgs:847585" for Profile service - Organization Service
    And I provide attributes against Profile service - Organization for patch request
    | notes        | hrn             |dateModified             |
    | Goodnotes_DateStamp | hrn:hrs:orgs:_DateStamp |2022-12-30             |
     And I Update "hrn" in request payload
    When I perform Patch request for Profile service - Organization Service
	Then I validate status code for Patch requests
    Then I Validate "notes" attribute for Profile service - Organization
