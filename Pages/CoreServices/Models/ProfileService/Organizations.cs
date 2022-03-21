using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices.Models
{

    public class Organizations
    {
        public string id { get; set; }
        public string name { get; set; }
        public string[] alias { get; set; }
        public string sourceIdentifier { get; set; }
        public string notes { get; set; }
        public Contactinformation contactInformation { get; set; }
        public object category { get; set; }
        public object functions { get; set; }
        public bool active { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public object customProperties { get; set; }
        public object tags { get; set; }
        public object parent { get; set; }
        public string hrn { get; set; }

    }
    public class Contactinformation
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }

        public string stateProvince { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string hrn { get; set; }

    }




}
