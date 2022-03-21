using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.Agreements
{

    public class AgreementsModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string hrn { get; set; }
        public string id { get; set; }
        public Principalinvestigator principalInvestigator { get; set; }
        public Primarycontact primaryContact { get; set; }
        public Responsibleunit responsibleUnit { get; set; }
        public Agreementtype agreementType { get; set; }
        public string title { get; set; }
        public bool firstDraftTobeGeneratedInternally { get; set; }
        public string generalInformationComments { get; set; }
        public string otherComments { get; set; }
        public Agreementdraftdocument[] agreementDraftDocument { get; set; }
        public Supportingdocument[] supportingDocuments { get; set; }
        public Otherpersonnel[] otherPersonnel { get; set; }
        public Counterparty[] counterParties { get; set; }
        public Agreementtypedata agreementTypeData { get; set; }
        public Activitystate activityState { get; set; }
        public Workflowstatus workflowStatus { get; set; }
        public bool active { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }

        public string description { get; set; }
       public string followUpDate { get; set; }
        public bool isPrivate { get; set; }
        public string notes { get; set; }

        public Attachment[] attachments { get; set; }

       

    }

    public class Principalinvestigator
    {
        public string hrn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Contactinformation contactInformation { get; set; }
    }

    public class AgreementDraftDocument
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Contactinformation
    {
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class Primarycontact
    {
        public string hrn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Contactinformation1 contactInformation { get; set; }
    }

    public class Contactinformation1
    {
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class Responsibleunit
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Agreementtype
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Agreementdraftdocument
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Agreementtypedata
    {
        public Origin origin { get; set; }
        public string description { get; set; }
        public Sowdocument[] sowDocuments { get; set; }
        public bool isReimbursable { get; set; }
        public string sowDescription { get; set; }
        public Fundingproject[] fundingProjects { get; set; }
        public Poctechtransfer pocTechTransfer { get; set; }
        public bool isSubjectToPatent { get; set; }
        public Exportingcountry[] exportingCountries { get; set; }
        public float reimbursementAmount { get; set; }
        public Sowprojectdocument[] sowProjectDocuments { get; set; }
        public bool isExportingOutsideUsa { get; set; }
        public Fundingprojectdocument[] fundingProjectDocuments { get; set; }
        public Directionmaterialtransfer directionMaterialTransfer { get; set; }

        public SowFundSource sowFundSource { get; set; }

        public SowFundingProject[] sowFundingProjects { get; set; }

        public string sowFundingProjectOther { get; set; }

        public TypeOfTrial[] TypeOfTrial { get; set; }

        public PhaseOfStudy[] PhaseOfStudy { get; set; }

        public ProtocolDocument[] ProtocolDocument { get; set; }

        public ConsentFormsDocument[] ConsentFormsDocument { get; set; }

        public Cro[] Cro { get; set; }

        public CroContactsOther[] CroContactsOther { get; set; }

        public bool isReimbursementTobeProvided { get; set; }

        public bool willUseCro { get; set; }

        public string protocolTitle { get; set; }

        public ProtocolDocument[] protocolDocument { get; set; }

        public string sponsorProtocolNumber { get; set; }

        public string croOther { get; set; }

        public bool isStudyPartOfCooperativeGroup { get; set; }
        public bool doesThisInvolveSubrecipients { get; set; }

        public CtaMaterialsOther[] ctaMaterialsOther { get; set; }

        public bool doesThisInvolveOtherMaterials { get; set; }

        public SubrecipientsOrganizations[] subrecipientsOrganizations { get; set; }

        public CtaMaterial[] ctaMaterials { get; set; }

        public CroContactPrimary[] croContactPrimary { get; set; }

    }

    public class Origin
    {
        public string hrn { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }


    public class Poctechtransfer
    {
        public string hrn { get; set; }
    }

    public class Directionmaterialtransfer
    {
        public string hrn { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class SowFundSource
    {
        public string hrn { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class SowFundingProject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string projectType { get; set; }
    }

    public class TypeOfTrial
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class PhaseOfStudy
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class ProtocolDocument
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MaterialType
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class CtaMaterialsOther
    {
        public MaterialType materialType { get; set; }
        public string provider { get; set; }
        public string materialDescription { get; set; }
    }

    public class SubrecipientsOrganizations
    {
        public Organization organization { get; set; }
        public string organizationName { get; set; }
    }

    public class CroContactPrimary
    {
        public Person person { get; set; }
        public string contactName { get; set; }
        public string contactPhone { get; set; }
        public string contactEmail { get; set; }
    }



    public class UseInTrial
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }
    public class CtaMaterial
    {
        public MaterialType materialType { get; set; }
        public UseInTrial useInTrial { get; set; }
        public string provider { get; set; }
        public string materialDescription { get; set; }
    }


    public class ConsentFormsDocument
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Cro
    {
        public string hrn { get; set; }
    }

    public class CroContactsOther
    {
        public Person person { get; set; }
        public string contactName { get; set; }
        public string contactPhone { get; set; }
        public string contactEmail { get; set; }
    }


    public class Sowdocument
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Attachment
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Fundingproject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string projectType { get; set; }
    }

    public class Exportingcountry
    {
        public string hrn { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Sowprojectdocument
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Fundingprojectdocument
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Activitystate
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class Workflowstatus
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Supportingdocument
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Otherpersonnel
    {
        public string hrn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Contactinformation2 contactInformation { get; set; }
    }

    public class Contactinformation2
    {
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class Counterparty
    {
        public Person person { get; set; }
        public Organization organization { get; set; }
        public string contactPersonName { get; set; }
        public string counterPartyName { get; set; }
        public Contactinformation4 contactInformation { get; set; }
    }

    public class Person
    {
        public string hrn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Contactinformation3 contactInformation { get; set; }
    }

    public class Contactinformation3
    {
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class Organization
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Contactinformation4
    {
        public string city { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string stateProvince { get; set; }
    }


}
