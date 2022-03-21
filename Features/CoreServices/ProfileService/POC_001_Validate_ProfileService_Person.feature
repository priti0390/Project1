@coreservices @ProfileService @Person @Smoke
Feature: POC_001_Validate_ProfileService_Person
<b>Description</b>: Testing Profile Service - Person for below test scenarios
<br>a) Validated four different requests-> Get, Post, Put & Patch
<br>b) Authenticated API via Bearer Based Token
<br>c) Validating status codes for multiple requests
<br>d) Validating schema for payload and responses
<br>e) Validating each parameter values against post and put requests
<br>f) Validating above scenarios for mutliple rows of test data for Post & Put request


## ******************** GET REQUEST *********************************
#Scenario to handle Get request for Profile Service - Person
Scenario: POC_001_001_Validate_ProfileService_Person_GetRequest
	Given I Set UP URL For APIs with Endpoint as "api/persons"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Get Request for Profile service - Person
	Then I validate status code for Get requests
    #And I validate Sort by "id" in Get Request for Profile service - Person
    #And I validate Sort by "dateModified" in Get Request for Profile service - Person
    And I Validate content type for response as "application/json"


## ******************** POST REQUEST *********************************
 #Scenario to handle Post request for Profile Service - Person
Scenario: POC_001_002_Validate_ProfileService_Person_PostRequest
	Given I Set UP URL For APIs with Endpoint as "api/persons"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I generate payload of Profile service - Person Service for Post request
    | id        | firstName | lastName | contactInformation/city |
    |QA_id_DateStamp | firstName_DateStamp | lastName_DateStamp  | SPJ|
    |QA_id_DateStamp | firstName_DateStamp | lastName_DateStamp  | SPJ|
    |QA_id_DateStamp | firstName_DateStamp | lastName_DateStamp  | SPJ|
    And I Validate Schema of Profile service - Person Service for request payload having schemafile as "ProfileService_Person_Schema.json"
	When I perform Post request for Profile service - Person
    Then I Validate all new records after post request
     Then I Validate firstName parameter for Profile service - Person
     And I Validate lastName parameter for Profile service - Person
     And I Validate content type for all response as "application/json"
     #And I Validate Schema for Profile service - Person API response having schemafile as "ProfileService_Person_Schema.json"

## ******************** PUT REQUEST *********************************
#Scenario to handle Put request for Profile Service - Person
Scenario: POC_001_003_Validate_ProfileService_Person_PutRequest
    Given I Set UP URL For APIs with Endpoint as "api/persons"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I retrieve data using ID via Get Request for Profile service - Person Service
    And I update payload of Profile service - Person Service for put request
    | id              | firstName           | lastName           | contactInformation/city           | hrn                     |
    | QA_id_DateStamp | firstName_DateStamp | lastName_DateStamp | SPJ_Native_DateStamp                     | hrn:hrs:persons:_DateStamp |
    | QA_id_DateStamp | firstName_DateStamp | lastName_DateStamp | SPJ_Native_DateStamp                     | hrn:hrs:persons:_DateStamp |
    | QA_id_DateStamp | firstName_DateStamp | lastName_DateStamp | SPJ_Native_DateStamp                     | hrn:hrs:persons:_DateStamp |
    And I Update "hrn" in all request payload 
	When I perform Put request for Profile service - Person Service
	Then I validate status code for all Put requests
    And I Validate city under contactInformation parameter for Profile service - Person
    And I Validate content type for all response as "application/json"




## ******************** PATCH REQUEST *********************************
#Scenario to handle Patch request for Profile Service - Person
Scenario: POC_001_004_Validate_ProfileService_Person_PatchRequest
    Given I Set UP URL For APIs with Endpoint as "api/persons"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I retrieve data against mutliple parameter value for Profile service - Person Service
    #When I retrieve data against parameter value as "hrn:hrs:persons:992" for Profile service - Person Service
    And I provide attributes against Profile service - Person for patch request
    | lastName        | hrn             | dateModified             |
    | lastName_Patch_DateStamp | hrn:hrs:persons:_DateStamp | 2022-12-30             |
    | lastName_Patch_DateStamp | hrn:hrs:persons:_DateStamp | 2022-12-30             |
    | lastName_Patch_DateStamp | hrn:hrs:persons:_DateStamp | 2022-12-30             |
    And I Update "hrn" in all request payload 
    When I perform Patch request for Profile service - Person Service
	Then I validate status code for all Patch requests
    And I Validate lastName parameter for Profile service - Person



    ## ******************** GET REQUEST *********************************
#Scenario to handle Get request for Profile Service - Person
Scenario: POC_001_005_Validate_ProfileService_Person_GetpersonbyHRN
	Given I Set UP URL For APIs with Endpoint as "api/persons/hrn:hrs:persons:6746"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Get Request for Profile service - Person
	Then I validate status code for Get requests
    And I Validate content type for response as "application/json"
    And I validate that value of "hrn" attribute is "hrn:hrs:persons:6746" in response
    
    
    