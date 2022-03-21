@Smoke @agreements
Feature:AGR_003_ValidateAgreementsAPI_MTA-Incoming
	Description: Validate GET, POST, PUT and PATCH Requests for MTA Agreements API 


	   
          ## ******************* POST REQUEST **************************************
Scenario: AGR_003_01_ValidateAgreementsAPI_MTA-Incoming-Internal_PostRequest       
        Given I Set UP URL For APIs with Endpoint as "/api/agreements"
        And I Retrieve Token Key for API
        And I Validate Expiry for API Token
         When I generate payload of Agreements for Post request for MTA-Incoming API
        | title                  | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | agreementType/hrn             | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/sowDocuments/0/name | agreementTypeData/sowFundingProjects  | agreementTypeData/sowFundingProjectOther | agreementTypeData/sowProjectDocuments |
        | Agreement MTA Test 514 | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:orgs:309    | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal | The recipient will trace the site of DNA replication in live cells. | sow agreement1                        | null                                  |     null                                     | null                                     |
         When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
      And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/sowFundSource/hrn" attribute for Agreements
         


              ## ******************* PUT REQUEST *********************************
Scenario:  AGR_003_02_ValidateAgreementsAPI_MTA-Incoming-Internal_PutRequest 
     Given I Set UP URL For APIs with Endpoint as "/api/agreements"
     Then I retrieve data using unique key received after successful Post Request
      When I update payload of Agreements for put request
      | agreementType/hrn            | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                         | agreementTypeData/sowFundSource/hrn               | agreementTypeData/sowDocuments/0/name| agreementTypeData/sowFundSource/hrn                   | agreementTypeData/sowDescription                                    |
      | hrn:hrs:lists:agrmt-types/MTA| hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | The material is a modification of ATCC CCL-247see   | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal  |sow agreement1                        | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal |  The recipient will trace the site of DNA replication in live cells.|
     When I perform Put request for Agreements
	 Then I validate status code for Put requests
      And I Validate "agreementType/hrn" attribute for Agreements
       And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/sowFundSource/hrn" attribute for Agreements


         ## ********************* PATCH REQUEST *********************************
Scenario: AGR_003_03_ValidateAgreementsAPI_MTA-Incoming-Internal_PatchRequest

   Given I Set UP URL For APIs with Endpoint as "/api/agreements"
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:712 |
    And I update payload of Agreements for patch request
      | agreementType/hrn        | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowFundSource/hrn               | agreementTypeData/sowDocuments/0/name| agreementTypeData/sowFundSource/hrn                   | agreementTypeData/sowDescription                                    |
      | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal  |sow agreement1                        | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal |  The recipient will trace the site of DNA replication in live cells.|
   	When I perform Patch request for Agreements
	Then I validate status code for Patch request
       And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/sowFundSource/hrn" attribute for Agreements
        

                  ## ******************* POST REQUEST *********************************
Scenario: AGR_003_04_ValidateAgreementsAPI_MTA-Incoming-External_PostRequest       
Given I Set UP URL For APIs with Endpoint as "/api/agreements"
          And I Retrieve Token Key for API
        And I Validate Expiry for API Token
                 When I generate payload of Agreements for Post request for MTA-Incoming API
        | title                  | principalInvestigator/hrn | primaryContact/hrn  | agreementType/hrn             | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowDocuments/0/name | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/sowFundingProjects/0/id | agreementTypeData/sowFundingProjects/1/id | agreementTypeData/sowFundingProjectOther | agreementTypeData/sowProjectDocuments/0/url                       | 
        | Agreement MTA Test 514 | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:orgs:309    | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | sow agreement1                        | hrn:hrs:lists:agrmt-mta-sow-fund-source/external | The recipient will trace the site of DNA replication in live cells. | MTA00111                                  | MTA00003                                  | National Cancer Institute                | https://agreementdocs.s3.us-east-2.amazonaws.com/angiogenesis.pdf | 
    	When I perform Post request for Agreements
        Then I Validate new record after post request
        Then I perform Get request and verify the resource created
         And I Validate "agreementType/hrn" attribute for Agreements
          And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/sowFundSource/hrn" attribute for Agreements



        
          ## ******************* PUT REQUEST *********************************
Scenario:  AGR_003_05_ValidateAgreementsAPI_MTA-Incoming-External_PutRequest 
     Given I Set UP URL For APIs with Endpoint as "/api/agreements"
   Then I retrieve data using unique key received after successful Post Request
     When I update payload of Agreements for put request
  |agreementType/hrn                | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                         | agreementTypeData/sowDocuments/0/name | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/sowFundingProjects/0/id | agreementTypeData/sowFundingProjects/1/id | agreementTypeData/sowFundingProjectOther | agreementTypeData/sowProjectDocuments/0/url                       |
  |  hrn:hrs:lists:agrmt-types/MTA   |hrn:hrs:lists:agrmt-mta-direction-mt/incoming    | The material is a modification of ATCC CCL-247seekk  | sow agreement1                        | hrn:hrs:lists:agrmt-mta-sow-fund-source/external | The recipient will trace the site of DNA replication in live cells. | MTA00111                                  | MTA00003                                  | National Cancer Institute                     | https://agreementdocs.s3.us-east-2.amazonaws.com/angiogenesis.pdf |
	  When I perform Put request for Agreements
     Then I validate status code for Put requests
      And I Validate "agreementType/hrn" attribute for Agreements
      And I Validate "agreementTypeData/description" attribute for Agreements
       And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/sowFundSource/hrn" attribute for Agreements





     
     ## ********************* PATCH REQUEST *********************************
Scenario: AGR_003_06_ValidateAgreementsAPI_MTA-Incoming-External_PatchRequest

   Given I Set UP URL For APIs with Endpoint as "/api/agreements"
    When I retrieve data using unique key by Get Request for Agreements
    | hrn      |
    | hrn:hrs:agreements:712 |
   When I update payload of Agreements for patch request
 | agreementType/hrn                | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowDocuments/0/name | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/sowFundingProjects/0/id | agreementTypeData/sowFundingProjects/1/id | agreementTypeData/sowFundingProjectOther | agreementTypeData/sowProjectDocuments/0/url                       |
 |  hrn:hrs:lists:agrmt-types/MTA   |hrn:hrs:lists:agrmt-mta-direction-mt/incoming    | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | sow agreement1                        | hrn:hrs:lists:agrmt-mta-sow-fund-source/external | The recipient will trace the site of DNA replication in live cells. | MTA00111                                  | MTA00003                                  | National Cancer Institute                | https://agreementdocs.s3.us-east-2.amazonaws.com/angiogenesis.pdf |
   	When I perform Patch request for Agreements
	Then I validate status code for Patch request
      And I Validate "agreementTypeData/directionMaterialTransfer/hrn" attribute for Agreements
        And I Validate "agreementTypeData/sowFundSource/hrn" attribute for Agreements

        ## ********************* error messages validations *********************************

         #Payload when "sowFundSource" is 'Internal'  and hence conditional field "sowFundingProjects" -- Other is not valid 
        When I generate payload of Agreements for Post request for CDA API
       | title                  | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | agreementType/hrn             | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/sowFundingProjects/0/id | agreementTypeData/sowFundingProjects/1/id |
       | Agreement MTA Test 514 | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:orgs:309    | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal | The recipient will trace the site of DNA replication in live cells. |        MTA0021                                   |           MTA0022                                |
        When I perform Post request for Agreements
        Then I Validate the error message for conditional field sowFundingProjects in post request
        Then I verify the resource is not created

            #Payload when "sowFundSource" is 'Internal'  and origin field  not valid 
        When I generate payload of Agreements for Post request for CDA API
       | title                  | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | agreementType/hrn             | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/origin/hrn |
       | Agreement MTA Test 514 | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:orgs:309    | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal | The recipient will trace the site of DNA replication in live cells. | hrn:hrs:lists:agrmt-mta-origin/other                  |
        When I perform Post request for Agreements
        Then I Validate the error message for conditional field origin  in post request
        Then I verify the resource is not created

          #Payload when "sowFundSource" is 'External'  and origin field  not valid 
        When I generate payload of Agreements for Post request for CDA API
       | title                  | firstDraftTobeGeneratedInternally | principalInvestigator/hrn | primaryContact/hrn  | agreementType/hrn             | responsibleUnit/hrn | counterParties/0/organization/hrn | counterParties/0/person/hrn | agreementTypeData/directionMaterialTransfer/hrn | agreementTypeData/description                                                     | agreementTypeData/sowFundSource/hrn              | agreementTypeData/sowDescription                                    | agreementTypeData/origin/hrn |
       | Agreement MTA Test 514 | true                              | hrn:hrs:persons:801       | hrn:hrs:persons:301 | hrn:hrs:lists:agrmt-types/MTA | hrn:hrs:orgs:309    | hrn:hrs:orgs:3                    | hrn:hrs:persons:301         | hrn:hrs:lists:agrmt-mta-direction-mt/incoming   | Human cell line HCT118RTP-BCNA .The material is a modification of ATCC CCL-247see | hrn:hrs:lists:agrmt-mta-sow-fund-source/internal | The recipient will trace the site of DNA replication in live cells. | hrn:hrs:lists:agrmt-mta-origin/internal-tp                |
        When I perform Post request for Agreements
        Then I Validate the error message for conditional field origin  in post request
        Then I verify the resource is not created