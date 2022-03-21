using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices.Models
{
    public class Organization
    {
        public long id { get; set; }
        public object legacyId { get; set; }
        public string name { get; set; }
        public existingUrls[] existingUrls { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string code { get; set; }
        public string cognitoUserPoolId { get; set; }
    }

    public class existingUrls
    {
        public object url { get; set; }
    }
}
