using Dynamitey.DynamicObjects;
using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using HRSData.Pages.CoreServices.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices
{
    public static class DocumentServices
    {
        public static void validateDocumentParameter(string p0)
        {

            string g = APIHelper.GetJObjectValue(p0, Settings_API.response1.Content.ToString());
            if (g.Contains("https"))
                ReportingHelpers.ChildTest.Pass("Validated URL:"+g+ " successfully");
            else
                ReportingHelpers.ChildTest.Fail("Failed to validate URL: "+g);
        }       
    }
}
