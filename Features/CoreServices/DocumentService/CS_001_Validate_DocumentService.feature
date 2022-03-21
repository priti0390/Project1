@coreservices @DocumentService @Smoke
Feature: CS_001_Validate_DocumentService
<b>Description</b>: Testing Document Service
<br>a) Validated Document Versioning
<br>b) Authenticated API via Bearer Based Token
<br>c) Validating status codes for Given request


## ******************** POST REQUEST ***************************************
#Scenario to convert word document to pdf for Document Service
Scenario: CS_001_001_Validate_DocumentService_ConvertWordToPdf_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/v1/Documents"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Post request for Document service with document as "WordDoc1.docx"
    When I retrieve data using ID for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate hrn for Document service
    And I Validate filename for Document Service
    And I Validate currentVersion for Document Service
    And I Validate versionAction for Document

#Scenario to convert image document to pdf for Document Service
Scenario: CS_001_002_Validate_DocumentService_ConvertImageToPdf_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/v1/Documents"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Post request for Document service with document as "ImageDocument.jpg"
    When I retrieve data using ID for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate hrn for Document service
    And I Validate filename for Document Service
    And I Validate currentVersion for Document Service
    And I Validate versionAction for Document

#Scenario to convert html document to pdf for Document Service
Scenario: CS_001_003_Validate_DocumentService_ConvertHtmlToPdf_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/v1/Documents"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Post request for Document service with document as "HeartReport_API_202202172326397798.html"
    When I retrieve data using ID for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate hrn for Document service
    And I Validate filename for Document Service
    And I Validate currentVersion for Document Service
    And I Validate versionAction for Document

#Scenario to convert password protected document to pdf for Document Service
Scenario: CS_001_004_Validate_DocumentService_ConvertPasswordProtectedDocumentToPdf_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/v1/Documents"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Post request for Document service with document as "Sample_PasswordProtected_Doc.docx"
    When I retrieve data using ID for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate hrn for Document service
    And I Validate filename for Document Service
    And I Validate currentVersion for Document Service
    And I Validate versionAction for Document
   