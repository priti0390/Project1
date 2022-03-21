@coreservices @DocumentService @Smoke
Feature: CS_002_Validate_DocumentVersioning
<b>Description</b>: Testing Document Versioning
<br>a) Validated Document Versioning
<br>b) Authenticated API via Bearer Based Token
<br>c) Validating status codes for Given request


## ******************** POST REQUEST ***************************************
#Scenario to convert word document to pdf for Document Service with multiple versions
Scenario: CS_002_001_Validate_DocumentService_ConvertWordToPdf_DocumentVersioning_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/v1/Documents"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I perform Post request for Document service with document as "WordDoc1.docx"
    When I retrieve data using ID for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate hrn for Document service
    And I Validate filename for Document Service
    Then I Validate currentVersion for Document Service as "1"
    And I Validate versionAction for Document
    When I perform Post request for Document service with document as "WordDoc1.docx" to increase version
    Then I Validate currentVersion for Document Service as "2"
    
#Comparing same hrns and validating PDF URL but not content

Scenario: CS_002_002_Validate_DocumentService_CompareDocuments_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/DocumentUtils/Words/Compare"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I generate payload for Document Service for Post request
       | sourceHrn                                          | sourceVersion | compareHrn                                         | compareVersion | acceptExistingChanges |
       | hrn:hrs:documents:cf99000e935f4beaa7594b3eaaf39134 | 1             | hrn:hrs:documents:cf99000e935f4beaa7594b3eaaf39134 | 2              | true                  |
    When I perform Post request for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate "url" in generated Document after comparison

#Comparing different hrns and validating PDF URL but not content
Scenario: CS_002_003_Validate_DocumentService_CompareDocuments_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/DocumentUtils/Words/Compare"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I generate payload for Document Service for Post request
       | sourceHrn                                          | sourceVersion | compareHrn                                         | compareVersion | acceptExistingChanges |
       | hrn:hrs:documents:cf99000e935f4beaa7594b3eaaf39134 | 1             | hrn:hrs:documents:57345ac5df454d2987d0987e173c90a4 | 2              | true                  |
    When I perform Post request for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
    And I Validate "url" in generated Document after comparison
    
#Appending document based on URL using Post Request
Scenario: CS_002_004_Validate_DocumentService_AppendingDocuments_PostRequest
	Given I Set UP URL For APIs with Endpoint as "documentservice/api/DocumentUtils/Words/Compare"
	And I Retrieve Token Key for API
    And I Validate Expiry for API Token
    When I generate payload for Document Service for Post request
       | Url                                                                                                | OwningEntityHrn |
       | https://hrsv12-demo.huronclick.com/agreements/agreement/smartform?id=hrn%3Ahrs%3Aagreements%3A3080 | orphan          |
          When I perform Post request for Document service
    Then I Validate new record after post request     
    Then I Validate content type for response as "application/json; charset=utf-8"
   And I Validate "url" in generated Document after comparison
