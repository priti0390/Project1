@coreservices @ListService @Smoke
Feature: POC_001_Validate_ListService
<b>Description</b>: Testing List Service
<br>a) Validated four different requests-> Get
<br>b) Authenticated API via Bearer Based Token
<br>c) Validating status codes for Given request


## ******************** GET REQUEST ***************************************
#Scenario to handle Get request for List Service
Scenario: POC_001_001_Validate_ListService_GetRequest
	Given I Set UP URL For APIs with Endpoint as "api/lists"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Get Request for List Service
	Then I validate status code for Get requests
    And I Validate content type for response as "application/json"



## ******************** POST REQUEST *********************************
 #Scenario to handle Post request for List Service 
Scenario: POC_001_002_Validate_ListService_PostRequest
	Given I Set UP URL For APIs with Endpoint as "api/lists"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I generate payload of List service
    | id    | name |  description | defaultItemPermissions/fullAccess |
    |QA_id_DateStamp | QA_Listaut01_DateStamp | List by QA  |true|
   # And I Validate Schema of List service using "ListService_Schema.json"
	When I perform Post request for List service
    Then I Validate new record after post request



   ## ******************** PUT REQUEST *********************************
 #Scenario to handle Put request for List Service 
Scenario: POC_001_003_Validate_ListService_PutRequest
	Given I Set UP URL For APIs with Endpoint as "api/lists"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I retrieve a existing record data using HRN
    #When I retrieve data using ID via Get Request for Profile service - Organization Service
    And I Update Payload for a existing List service
    #When I generate payload of List service
    | id              | name                   | description        | defaultItemPermissions/fullAccess | hrn |
    | QA_id_DateStamp | QA_Listaut01_DateStamp | List by QA updated | true                              | hrn:hrs:lists:_DateStamp    |
    And I Update "hrn" in request payload
    When I perform Put request for List service
	Then I validate status code for Put requests


   