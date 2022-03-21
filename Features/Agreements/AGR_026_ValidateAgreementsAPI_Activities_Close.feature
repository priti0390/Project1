@Smoke @agreements
Feature: AGR_011_ValidateAgreementsAPI_Activities_Close
Description: Validate different activities api for Agreements

## ******************* POST REQUEST *********************************

Scenario: AGR_011_01_ValidateAgreementsAPI_Activities_Close_CreateAgreement

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
       When I perform Post request for Agreements Activities
       Then I perform Get request and verify the resource created
        And I perform Get Request and Validate value of "activityState" attribute is "PreSubmission" for Agreements Activities

   
Scenario: AGR_011_02_ValidateAgreementsAPI_Activities_Close_PreSubmission

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "PreSubmission" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "PreSubmission" for Agreements Activities
   
Scenario: AGR_011_03_ValidateAgreementsAPI_Activities_Close_Unassigned

        Given I execute "Submit" activity using Post request and activity state is updated to "Unassigned"

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "Unassigned" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_011_04_ValidateAgreementsAPI_Activities_Close_InternalReview

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
         When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "InternalReview" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "InternalReview" for Agreements Activities


Scenario: AGR_011_05_ValidateAgreementsAPI_Activities_Close_ExternalReview

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/MoveToExternalReview"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | 
        | test               | doc.url |    
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "ExternalReview" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ExternalReview" for Agreements Activities


Scenario: AGR_011_06_ValidateAgreementsAPI_Activities_Close_PIConcurrenceRequested

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/RequestPIConcurrence"
        When I generate payload for Post request for Agreements
        | commentsConcurrenceRequest | 
        | test |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "PIConcurrenceRequested" state and validate the error message
               Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "PIConcurrenceRequested" for Agreements Activities


Scenario: AGR_011_07_ValidateAgreementsAPI_Activities_Close_ClarificationRequested

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/RequestClarification"
        When I generate payload for Post request for Agreements
        | commentsClarificationRequest | 
        | Test comments Clarification Request |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "ClarificationRequested" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ClarificationRequested" for Agreements Activities


Scenario: AGR_011_08_ValidateAgreementsAPI_Activities_Close_ReadyForSignature

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/FinalizeTerms"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | 
        | test               | doc.url |    
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "ReadyForSignature" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ReadyForSignature" for Agreements Activities


Scenario: AGR_011_09_ValidateAgreementsAPI_Activities_Close_InternalSignature

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/FinalizeTerms"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | 
        | test               | doc.url |    
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/SendForSignatures"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | signatureType/hrn                                          | signatureTransition/hrn                                         |
        | test                | doc.url            | hrn:hrs:lists:activity-signature-types/institutional-esign | hrn:hrs:lists:activity-signature-transitions/internal-signature |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "InternalSignature" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "InternalSignature" for Agreements Activities


Scenario: AGR_011_10_ValidateAgreementsAPI_Activities_Close_ExternalSignature

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I execute "Submit" activity using Post request and activity state is updated to "Unassigned"

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/FinalizeTerms"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | 
        | test               | doc.url |    
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/SendForSignatures"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | signatureType/hrn                                          | signatureTransition/hrn                                         |
        | test                | doc.url            | hrn:hrs:lists:activity-signature-types/institutional-esign | hrn:hrs:lists:activity-signature-transitions/external-signature |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        Then I verify "Close" activity with request body is not allowed in "ExternalSignature" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ExternalSignature" for Agreements Activities


Scenario: AGR_011_11_ValidateAgreementsAPI_Activities_Close_Active

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/FinalizeTerms"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | 
        | test               | doc.url |    
        When I perform Post request for Agreements Activities

         Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/SendForSignatures"
         When I generate payload for Post request for Agreements
         | agreementDraft/name | agreementDraft/url | signatureType/hrn                                          | signatureTransition/hrn                                         |
         | test                | doc.url            | hrn:hrs:lists:activity-signature-types/institutional-esign | hrn:hrs:lists:activity-signature-transitions/external-signature |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Activate"
        When I generate payload for Post request for Agreements
        | effectiveDate | 
        | 2021-02-25 |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Close"
        When I generate payload for Post request for Agreements
        | isEarlyTermination | 
        | false |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Closed" for Agreements Activities


Scenario: AGR_011_12_ValidateAgreementsAPI_Activities_Close_Discard

         Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments |
        | Test     |
        When I perform Post request for Agreements Activities
  
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        Then I verify "Discard" activity is not allowed in "Discarded" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities
   