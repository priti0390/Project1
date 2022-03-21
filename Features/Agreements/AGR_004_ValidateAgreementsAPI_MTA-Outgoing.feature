@Smoke @agreements
Feature:AGR_004_ValidateAgreementsAPI_MTA-Outgoing
	Description: Validate GET, POST, PUT and PATCH Requests for MTA Agreements API 

      
               ## ******************* POST REQUEST *********************************
Scenario: AGR_004_01_ValidateAgreementsAPI_MTA-Outgoing_Origin_Purchasedorprovidedbythirdparty_PostRequest
  Given I Set UP URL For APIs with Endpoint as "/api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |agreementTypeData/originOther  |
         | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/third-party | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |null  |
         When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created



                    ## ******************* PUT REQUEST *********************************
Scenario:  AGR_004_02_ValidateAgreementsAPI_MTA-Outgoing_Origin_Purchasedorprovidedbythirdparty_PutRequest
     Given I Set UP URL For APIs with Endpoint as "/api/agreements"
     Then I retrieve data using unique key received after successful Post Request
      When I update payload of Agreements for put request
       | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
       | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/third-party | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |
     When I perform Put request for Agreements
	 Then I validate status code for Put requests
      And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/fundingProjects/0/id" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements


           ## ********************* PATCH REQUEST *********************************
Scenario: AGR_004_03_ValidateAgreementsAPI_MTA-Outgoing_Origin_Purchasedorprovidedbythirdparty_PatchRequest

   Given I Set UP URL For APIs with Endpoint as "/api/agreements"
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:742 |
    And I update payload of Agreements for patch request
      | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
      | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/third-party | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |
   	When I perform Patch request for Agreements
	Then I validate status code for Patch request
       And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/fundingProjects/0/id" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements

                    ## ******************* POST REQUEST *********************************
Scenario: AGR_004_04_ValidateAgreementsAPI_MTA-Outgoing_Origin_GeneratedInternallybythirdparty_PostRequest
  Given I Set UP URL For APIs with Endpoint as "/api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |agreementTypeData/originOther   |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal-tp | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |  null|
         When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created



        ## ******************* PUT REQUEST *********************************
Scenario: AGR_004_05_ValidateAgreementsAPI_MTA-Outgoing_Origin_GeneratedInternallybythirdparty_PutRequest
  Given  I Set UP URL For APIs with Endpoint as "/api/agreements"
     Then I retrieve data using unique key received after successful Post Request
      When I update payload of Agreements for put request
     | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn   | agreementTypeData/isReimbursable           | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
     | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal-tp | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia              | true                                       | 0.099                                 | true                                | hrn:hrs:persons:301                   |
     When I perform Put request for Agreements
	 Then I validate status code for Put requests
      And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/fundingProjects/0/id" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements


      
           ## ********************* PATCH REQUEST *********************************
Scenario: AGR_004_06_ValidateAgreementsAPI_MTA-Outgoing_Origin_GeneratedInternallybythirdparty_PatchRequest

   Given I Set UP URL For APIs with Endpoint as "/api/agreements"
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:742 |
    And I update payload of Agreements for patch request
     | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn   | agreementTypeData/isReimbursable           | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
     | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal-tp | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia              | true                                       | 0.099                                 | true                                | hrn:hrs:persons:301                   |
		When I perform Patch request for Agreements
    Then I validate status code for Patch request
       And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/fundingProjects/0/id" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements


        ## ******************* POST REQUEST *********************************
Scenario: AGR_004_07_ValidateAgreementsAPI_MTA-Outgoing_Origin_GeneratedInternally_PostRequest
  Given I Set UP URL For APIs with Endpoint as "/api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/originOther | agreementTypeData/fundingProjects |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   | null                          |        null                           |
         When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created




        ## ******************* PUT REQUEST *********************************
Scenario: AGR_004_08_ValidateAgreementsAPI_MTA-Outgoing_Origin_GeneratedInternally_PutRequest
  Given  I Set UP URL For APIs with Endpoint as "/api/agreements"
     Then I retrieve data using unique key received after successful Post Request
      When I update payload of Agreements for put request
    | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                  | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
     | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf |The recipient will trace the site of DNA replication in live cells.| true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                              | 0.099                                 | true                                | hrn:hrs:persons:301                   |
	When I perform Put request for Agreements 
    Then I validate status code for Put requests
      And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements

           ## ********************* PATCH REQUEST *********************************
Scenario: AGR_004_09_ValidateAgreementsAPI_MTA-Outgoing_Origin_GeneratedInternally_PatchRequest

   Given I Set UP URL For APIs with Endpoint as "/api/agreements"
   And I Retrieve Token Key for API
        And I Validate Expiry for API Token
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:742 |
    And I update payload of Agreements for patch request
    | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/fundingProjects |
    | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   | null                              |         
		When I perform Patch request for Agreements
    Then I validate status code for Patch request
       And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements     


        ## ******************* POST REQUEST *********************************
Scenario: AGR_004_10_ValidateAgreementsAPI_MTA-Outgoing_Origin_Other_PostRequest
  Given I Set UP URL For APIs with Endpoint as "/api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
        When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn         | agreementTypeData/originOther                                            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/fundingProjects |  
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/other | This is a modification of HCT116 cell line which was purchased from ATCC | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   | null                              |  
         When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created


        ## ******************* PUT REQUEST *********************************
Scenario: AGR_004_11_ValidateAgreementsAPI_MTA-Outgoing_Origin_Other_PutRequest
  Given  I Set UP URL For APIs with Endpoint as "/api/agreements"
     Then I retrieve data using unique key received after successful Post Request
      When I update payload of Agreements for put request
 | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn         |agreementTypeData/originOther                                             |  agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                  | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable           | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
    | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/other | This is a modification of HCT116 cell line which was purchased from ATCC |  https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf |The recipient will trace the site of DNA replication in live cells.| true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                                       | 0.099                                 | true                                | hrn:hrs:persons:301                   |
	When I perform Put request for Agreements 
    Then I validate status code for Put requests
      And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements

           ## ********************* PATCH REQUEST *********************************
Scenario: AGR_004_12_ValidateAgreementsAPI_MTA-Outgoing_Origin_Other_PatchRequest

   Given I Set UP URL For APIs with Endpoint as "/api/agreements"
   And I Retrieve Token Key for API
        And I Validate Expiry for API Token
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:742 |
   When I create payload for Patch request
    | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn         |agreementTypeData/originOther                                             |  agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                  | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable           | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |
    | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/other | This is a modification of HCT116 cell line which was purchased from ATCC |  https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf |The recipient will trace the site of DNA replication in live cells.| true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                                       | 0.099                                 | true                                | hrn:hrs:persons:301                   |
    When I perform Patch request for Agreements by using the new patch payload
    Then I validate status code for Patch request
       And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
      And I Validate "agreementTypeData/origin/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isExportingOutsideUsa" attribute for Agreements
      And I Validate "agreementTypeData/exportingCountries/1/hrn" attribute for Agreements
      And I Validate "agreementTypeData/isReimbursable" attribute for Agreements
      And I Validate "agreementTypeData/isSubjectToPatent" attribute for Agreements 


        ## ********************* error messages validations *********************************
Scenario: AGR_004_13_ErrorMessageValidation_MTA-Outgoing-API
         #Payload when field "isExportingOutsideUsa" is marked false then exportingCountries fields are not valid for MTA API if directionMaterialTransfer is Outgoing 
         Given I Set UP URL For APIs with Endpoint as "/api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |agreementTypeData/originOther  |
         | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/third-party | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | false                                   | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |null  |
        When I perform Post request for Agreements
        Then I Validate the error message for invalid  field exportingCountries when isExportingOutsideUsa field is marked false if directionMaterialTransfer is Outgoing  in post request
        Then I verify the resource is not created

        #Payload when field "isReimbursable" is marked false then reimbursementAmount field is not valid for MTA API if directionMaterialTransfer is Outgoing 
        When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |agreementTypeData/originOther   |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal-tp | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | false                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |  null|
        When I perform Post request for Agreements
        Then  I Validate the error message for invalid  field reimbursementAmount when isReimbursable field is marked false if directionMaterialTransfer is Outgoing  in post request
        Then I verify the resource is not created

         #Payload when field "isSubjectToPatent" is marked false then pocTechTransfer field is not valid for MTA API if directionMaterialTransfer is Outgoing 
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/originOther | agreementTypeData/fundingProjects |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | false                               | hrn:hrs:persons:301                   | null                          |        null                           |
         When I perform Post request for Agreements
       Then  I Validate the error message for invalid  field pocTechTransfer when isSubjectToPatent field is marked false if directionMaterialTransfer is Outgoing  in post request for MTA API
        Then I verify the resource is not created

         #Payload when field "originOther" is not valid when origin field  is contains hrn corresponding to  Purchasedorprovidedbythirdparty radio button  for MTA API if directionMaterialTransfer is Outgoing 
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/originOther |  
         | QA_Title_DateStamp | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/third-party | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   | This is a modification of HCT116 cell line which was purchased from ATCC                 |  
         When I perform Post request for Agreements
       Then  I Validate the error message for invalid field originOther when origin field contains hrn corresponding to  Purchasedorprovidedbythirdparty radio button  if directionMaterialTransfer is Outgoing  in post request for MTA API
        Then I verify the resource is not created

         #Payload when field "originOther" is not valid when origin field  is contains hrn corresponding to  GeneratedInternallybythirdparty radio button  for MTA API if directionMaterialTransfer is Outgoing 
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn               | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn |agreementTypeData/originOther   |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal-tp | MTA00001                               | MTA00021                               | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |   This is a modification of HCT116 cell line which was purchased from ATCC      |
         When I perform Post request for Agreements
       Then  I Validate the error message for invalid  field originOther when origin field contains hrn corresponding to GeneratedInternallybythirdparty radio button if directionMaterialTransfer is Outgoing in post request for MTA API
        Then I verify the resource is not created

        #Payload when field "originOther" is not valid when origin field  is contains hrn corresponding to  GeneratedInternally radio button  for MTA API if directionMaterialTransfer is Outgoing 
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/originOther | agreementTypeData/fundingProjects |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   |    This is a modification of HCT116 cell line which was purchased from ATCC                     |        null                           |
         When I perform Post request for Agreements
       Then  I Validate the error message for invalid  field originOther  when origin field contains hrn corresponding to GeneratedInternally radio button if directionMaterialTransfer is Outgoing  in post request for MTA API
        Then I verify the resource is not created

          #Payload when field "fundingProjects" is not valid when origin field  is contains hrn corresponding to  GeneratedInternally radio button  for MTA API if directionMaterialTransfer is Outgoing 
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/originOther                                            | agreementTypeData/fundingProjects/0/id |agreementTypeData/fundingProjects/1/id  |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/internal | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   | This is a modification of HCT116 cell line which was purchased from ATCC | MTA00234                               |MTA0023422    |
         When I perform Post request for Agreements
         Then  I Validate the error message for invalid fundingProjects field when origin field contains hrn corresponding to GeneratedInternally radio button if directionMaterialTransfer is Outgoing  in post request for MTA API
        Then I verify the resource is not created


        #Payload when field "fundingProjects" is not valid when origin field  is contains hrn corresponding to  Other radio button  for MTA API if directionMaterialTransfer is Outgoing 
         When I generate payload of Agreements for Post request for MTA-Outgoing API
         | title              | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | responsibleUnit/hrn | otherPersonnel/0/hrn | otherPersonnel/1/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementType/hrn             | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/origin/hrn         | agreementTypeData/originOther                                            | agreementTypeData/fundingProjectDocuments/0/url                  | agreementTypeData/sowDocuments/0/url                               | agreementTypeData/sowDescription                                    | agreementTypeData/isExportingOutsideUsa | agreementTypeData/exportingCountries/0/hrn | agreementTypeData/exportingCountries/1/hrn | agreementTypeData/isReimbursable | agreementTypeData/reimbursementAmount | agreementTypeData/isSubjectToPatent | agreementTypeData/pocTechTransfer/hrn | agreementTypeData/fundingProjects/0/id | agreementTypeData/fundingProjects/1/id |
         | QA_Title_DateStamp | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:orgs:3      | hrn:hrs:persons:801  | hrn:hrs:persons:301  | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/outgoing   | hrn:hrs:lists:agrmt-mta-origin/other | This is a modification of HCT116 cell line which was purchased from ATCC | https://agreementdocs.s3.us-east-2.amazonaws.com/cis-aerdcrt.pdf | https://agreementdocs.s3.us-east-2.amazonaws.com/sowagreement1.pdf | The recipient will trace the site of DNA replication in live cells. | true                                    | hrn:hrs:lists:countries/italy              | hrn:hrs:lists:countries/croatia            | true                             | 0.099                                 | true                                | hrn:hrs:persons:301                   | MTA00234                               |      MTA0023422                        |
         Then  I Validate the error message for invalid fundingProjects field when origin field contains hrn corresponding to Other radio button if directionMaterialTransfer is Outgoing  in post request for MTA API
         Then I verify the resource is not created