using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices.Models
{
    //public class Person
    //{
    //    public Data data { get; set; }
    //    public Links links { get; set; }
    //}

    public class Person
    {
        public string id { get; set; }
        public string honorific { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string title { get; set; }
        public object userId { get; set; }
        public object ORCID { get; set; }
        public Employer employer { get; set; }
        public Department department { get; set; }
        public Division division { get; set; }
        public string sourceIdentifier { get; set; }
        public Contactinformation1 contactInformation { get; set; }
        public bool active { get; set; }
        public string dateCreated { get; set; }
        public string dateModified { get; set; }
        public object earnedDegrees { get; set; }
        public object employeeId { get; set; }
        public object custom_properties { get; set; }
        public object tags { get; set; }
        public object roles { get; set; }
        public object hrn { get; set; }
    }

    public class Employer
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Department
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Division
    {
        public string hrn { get; set; }
        public string name { get; set; }
    }

    public class Contactinformation1
    {
        public string city { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string phoneNumber { get; set; }
        public string addressLine1 { get; set; }
        public string emailAddress { get; set; }
    }
    //public class Links
    //{
    //}
}
