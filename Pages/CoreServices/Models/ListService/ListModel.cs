using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices
   
{
    public class ListModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public int displayOrder { get; set; }
        public string description { get; set; }
        public Defaultitempermissions defaultItemPermissions { get; set; }
        public bool active { get; set; }
        public object customPropertiesSchema { get; set; }
        public string dateCreated { get; set; }
        public string dateModified { get; set; }
        public string hrn { get; set; }
    }

    public class Defaultitempermissions
    {
        public bool fullAccess { get; set; }
        public object[] editLockedItem { get; set; }
        public bool editUnlockedItem { get; set; }
        public bool createUnlockedItem { get; set; }
        public bool deleteUnlockedItem { get; set; }
    }
}
