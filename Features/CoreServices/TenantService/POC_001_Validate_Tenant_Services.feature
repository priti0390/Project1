@coreservices @TenantService @Smoke 
Feature: POC_001_Validate_Tenant_Services
Description: Testing Tenant Services for Delete request
<br>a) Delete request
<br>b) Token Based Authorization
<br>c) Validating status code for delete request

## ******************** DELETE REQUEST *******************************
#Scenario to handle Delete request for Tenant Service
Scenario: POC_001_001_Validate_Tenant_Services_DeleteRequest
	Given I Set UP URL For APIs with Endpoint as "tenant"
    And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Delete request for tenant service against parameter value as "115"
    And I perform Get request with deleted parameter
	Then I validate status code for Delete request

#
#    #Scenario to handle Get request for Tenant Service 1
#Scenario: POC_001_001_Validate_Tenant_Services_GetRequest
#   Given I Set UP URL For APIs with Endpoint as "tenant"
#	And I Retrieve Token Key for API
#    And I Validate Expiry for API Token
#    When I perform Get requests for tenant service
#	Then I validate status code for Get requests
#    #And I Validate Schema for tenant API response
#     #           | schemafile      |
#     #| tenantServiceDataSchema.json |
#
##Scenario to handle Post request for Tenant Service
#Scenario: POC_001_002_Validate_Tenant_Services_PostRequest
#   Given I Set UP URL For APIs with Endpoint as "tenant"
#    And I Retrieve Token Key for API
#    And I Validate Expiry for API Token
#    When I generate payload of Tenant Service for Post request
#    | name                      | address       | email          | phone | code                        |
#    | NameGeneratedByAutomation | 101spromenade | test1@test.com | 12345 | CodeViaAutomation_DateStamp |
#    #Then I Validate Schema for request payload
#     #       | schemafile      |
#     #| tenantServiceDataSchema.json |
#	When I perform Post request for tenant service
#    Then I Validate new record after post request
#    Then I Validate name parameter
#    And I Validate address parameter
#    And I Validate email parameter
#    And I Validate phone parameter
#    And I Validate code parameter
#   #And I Validate Schema for tenant API response
#     #           | schemafile      |
#     #| tenantServiceDataSchema.json |
#
##Scenario to handle Put request for Tenant Service
#Scenario: POC_001_003_Validate_Tenant_Services_PutRequest
#   Given I Set UP URL For APIs with Endpoint as "tenant"
#    And I Retrieve Token Key for API
#    And I Validate Expiry for API Token
#    When I retrieve data using ID via Get Request
#    And I update payload of Tanant Service for put request
#    | name        | address |
#    | NameGeneratedByAutomation_DateStamp | 101spromenadeEdited                     |
#    Then I Validate Schema for request payload
#            | schemafile      |
#     | tenantServiceDataSchema.json |
#	When I perform Put request for tenant service
#	Then I validate status code for Put requests
#    And I Validate name parameter
#    #And I Validate Schema for tenant API response
#     #           | schemafile      |
#     #| tenantServiceDataSchema.json |
