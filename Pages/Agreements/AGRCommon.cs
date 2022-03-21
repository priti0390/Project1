using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeartFramework.BaseAPI;
using HeartFramework.Helpers;

namespace HRSData.Pages.Agreements
{
    public static class AGRCommon
    {
        public static string agrHrn;

        public static void agrSetUrl(string endpoint)
        {
            if (endpoint.Contains("{") && endpoint.Contains("}"))
            {
                int start_index = endpoint.IndexOf("{");
                int end_index = endpoint.IndexOf("}");
                string param_val = endpoint.Substring(start_index, end_index - start_index + 1);
                if (param_val.Equals("{id}"))
                    endpoint = endpoint.Replace(param_val, Common.subId);
                if (param_val.Equals("{hrn}"))
                    endpoint = endpoint.Replace(param_val, Common.id);
            }
            Common.endpoint = endpoint;
            APIHelper.SetURL(Common.endpoint);
            ReportingHelpers.ChildTest.Pass("Endpoint: " + Common.endpoint);

        }
    }


}
