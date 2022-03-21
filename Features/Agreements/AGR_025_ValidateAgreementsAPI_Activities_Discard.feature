@Smoke @agreements
Feature: AGR_007_ValidateAgreementsAPI_Activities_Discard
Description: Validate different activities api for Agreements

## ******************* POST REQUEST *********************************

Scenario: AGR_007_01_ValidateAgreementsAPI_Activities_Discard_CreateAgreement

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
       When I perform Post request for Agreements Activities
       Then I perform Get request and verify the resource created
        And I perform Get Request and Validate value of "activityState" attribute is "PreSubmission" for Agreements Activities

   
Scenario: AGR_007_02_ValidateAgreementsAPI_Activities_Discard_PreSubmission

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments |
        | Test     |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities
   
Scenario: AGR_007_03_ValidateAgreementsAPI_Activities_Discard_Unassigned


        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities


Scenario: AGR_007_04_ValidateAgreementsAPI_Activities_Discard_InternalReview

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload for Post request for Agreements
        | owner/hrn | 
        | hrn:hrs:persons:301 |
        When I perform Post request for Agreements Activities
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities


Scenario: AGR_007_05_ValidateAgreementsAPI_Activities_Discard_ExternalReview

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

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
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities
        


Scenario: AGR_007_06_ValidateAgreementsAPI_Activities_Discard_PIConcurrenceRequested

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/RequestPIConcurrence"
        When I generate payload for Post request for Agreements
        | commentsConcurrenceRequest | 
        | test |
        When I perform Post request for Agreements Activities
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities

   

Scenario: AGR_007_07_ValidateAgreementsAPI_Activities_Discard_ClarificationRequested

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

            Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/RequestClarification"
        When I generate payload for Post request for Agreements
        | commentsClarificationRequest | 
        | Test comments Clarification Request |
        When I perform Post request for Agreements Activities
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities


Scenario: AGR_007_08_ValidateAgreementsAPI_Activities_Discard_ReadyForSignature

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

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
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities


Scenario: AGR_007_09_ValidateAgreementsAPI_Activities_Discard_InternalSignature

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/AssignOwner"
        When I generate payload of Agreements for Post request for CDA API
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
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities



Scenario: AGR_007_10_ValidateAgreementsAPI_Activities_Discard_ExternalSignature

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

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
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        When I generate payload for Post request for Agreements
        | comments | 
        | Test |
        When I perform Post request for Agreements Activities
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Discarded" for Agreements Activities



Scenario: AGR_007_11_ValidateAgreementsAPI_Activities_Discard_Active

        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        When I generate payload for Post request for Agreements
        | id              | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/purposeOfInformationExchange/hrn | agreementTypeData/purposeOfInformationExchangeOther | agreementTypeData/directionOfInformationTransfer/hrn | agreementTypeData/descriptionOfConfidentialInformation |
        | QA_id_DateStamp | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/CDA | hrn:hrs:lists:agrmt-cda-purp-info-ex/other         | Test Other Data with Post                            | hrn:hrs:lists:agrmt-cda-dir-info-tra/mutual          | test                                                   |
        When I perform Post request for Agreements Activities

        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Submit"
        When I perform Post request without request body for Agreements

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
        
        Given I Set UP URL For APIs with Endpoint as "/api/agreements/{hrn}/actions/Discard"
        Then I verify "Discard" activity is not allowed in "Active" state and validate the error message
        Given I Set UP URL For APIs with Endpoint as "api/agreements"
        Then I perform Get Request and Validate value of "activityState" attribute is "Active" for Agreements Activities


Scenario: AGR_007_12_ValidateAgreementsAPI_Activities_Discard_Discarded

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



   