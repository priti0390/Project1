@Smoke @agreements
Feature: AGR_016_ValidateAgreementsAPI_Activities_AssignOwner
Description: Validate different activities api for Agreements

## ******************* POST REQUEST *********************************

Scenario: AGR_016_01_ValidateAgreementsActivitiesAPI_AssignOwner_CreateAgreement

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
       When I perform Post request for Agreements Activities
       Then I perform Get request and verify the resource created
        And I perform Get Request and Validate value of "activityState" attribute is "PreSubmission" for Agreements Activities

   
Scenario: AGR_016_02_ValidateAgreementsActivitiesAPI_AssignOwner_PreSubmission

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        Then I verify "AssignOwner" activity is not allowed in "PreSubmission" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "PreSubmission" for Agreements Activities
   
Scenario: AGR_016_03_ValidateAgreementsActivitiesAPI_AssignOwner_Unassigned

        Given I execute "Submit" activity using Post request and activity state is updated to "Unassigned"

        ## Assign Owner without Owner details in Request body
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities

        ## Assign Owner with Owner details in Request body

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
         When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "InternalReview" for Agreements Activities


Scenario: AGR_016_04_ValidateAgreementsActivitiesAPI_AssignOwner_InternalReview

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
    
         ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_05_ValidateAgreementsActivitiesAPI_AssignOwner_ExternalReview

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |     
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/MoveToExternalReview"
        When I generate payload for Post request for Agreements
        | agreementDraft/name | agreementDraft/url | 
        | test               | doc.url |    
       When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |     
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ExternalReview" for Agreements Activities


          ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_06_ValidateAgreementsActivitiesAPI_AssignOwner_PIConcurrenceRequested


        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/RequestPIConcurrence"
        When I generate payload for Post request for Agreements
        | commentsConcurrenceRequest | 
        | test |
        When I perform Post request for Agreements Activities

        ## Assign Owner with Owner details in Request body - No State Transition

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "PIConcurrenceRequested" for Agreements Activities

         ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_07_ValidateAgreementsActivitiesAPI_AssignOwner_ClarificationRequested

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/RequestClarification"
        When I generate payload for Post request for Agreements
        | commentsClarificationRequest | 
        | Test comments Clarification Request |
        When I perform Post request for Agreements Activities

         ## Assign Owner with Owner details in Request body - No State Transition

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ClarificationRequested" for Agreements Activities

         ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_08_ValidateAgreementsActivitiesAPI_AssignOwner_ReadyForSignature

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

        ## Assign Owner with Owner details in Request body - No State Transition

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ReadyForSignature" for Agreements Activities

         ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_09_ValidateAgreementsActivitiesAPI_AssignOwner_InternalSignature

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

         ## Assign Owner with Owner details in Request body - No State Transition

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "InternalSignature" for Agreements Activities

        ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_10_ValidateAgreementsActivitiesAPI_AssignOwner_ExternalSignature

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

        ## Assign Owner with Owner details in Request body - No State Transition

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "ExternalSignature" for Agreements Activities

         ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_11_ValidateAgreementsActivitiesAPI_AssignOwner_Active

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

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Activate"
        When I generate payload for Post request for Agreements
        | effectiveDate | 
        | 2021-02-25 |
        When I perform Post request for Agreements Activities

        ## Assign Owner with Owner details in Request body - No State Transition

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Active" for Agreements Activities


         ## Assign Owner without Owner details in Request body - State changes to Unassigned
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I perform Post request without request body for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Unassigned" for Agreements Activities


Scenario: AGR_016_12_ValidateAgreementsActivitiesAPI_AssignOwner_Discarded

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        Then I verify "AssignOwner" activity is not allowed in "Discarded" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities





   