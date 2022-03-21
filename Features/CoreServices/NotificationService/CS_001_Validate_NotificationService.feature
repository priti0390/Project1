@Smoke @coreservices @Notification
Feature: CS_001_Validate_NotificationServices
Description: Validate GET Request for Notification Service

## ******************** GET REQUEST **********************************.
Scenario: CS_001_01_ValidateNotificationService_GetRequest
         Given I Set UP URL For APIs with Endpoint as "/notifications"
         And I Retrieve Token Key for API
         And I Validate Expiry for API Token
         When I perform Get Request for Notification service
         Then I validate status code for Get requests
         Then I validate Sort by "notificationId" in Get Request for Notification service
         #Then I validate filter by "notificationId" with value "not_000000CJAZd5CUBeftmEIYR2JXe2y" in Get Request
         Then I Validate content type for response as "application/json; charset=utf-8"
         #Then I validate pagination by "pageSize" with value "1" in Get Request
        