using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices
{
    public class DocumentModel
    {
        public string hrn { get; set; }
        public string sourceHrn { get; set; }
        public string sourceVersion { get; set; }
        public string compareHrn { get; set; }
        public int compareVersion { get; set; }
        public bool acceptExistingChanges { get; set; }
        public int currentVersion { get; set; }
        public bool locked { get; set; }
        public string owningService { get; set; }
        public string owningEntityHrn { get; set; }
        public string category { get; set; }
        public Version[] versions { get; set; }
        public string Url { get; set; }
        public string OwningEntityHrn { get; set; }
            
    }

    public class Version
    {
        public string key { get; set; }
        public string url { get; set; }
        public string fileName { get; set; }
        public string contentType { get; set; }
        public string personHrn { get; set; }
        public int version { get; set; }
        public string versionAction { get; set; }
        public string versionActionDescription { get; set; }
        public DateTime dateCreated { get; set; }
        public object sourceHrn { get; set; }
        public int sourceVersion { get; set; }
        public object sourceAction { get; set; }
    }
}
