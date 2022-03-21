using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HeartFramework.BaseAPI
{
    /// <summary>
    /// Setting up all the necessary variables before tests 
    /// </summary>
    public class Settings_API
    {
        public static Uri BaseURL { get; set; }
        public static IRestResponse response1 { get; set; }
        public static dynamic[] responseMultiple { get; set; }
        public static IRestRequest restRequest { get; set; }
        public static dynamic[] restRequestMultiple { get; set; }
        public static RestClient restclient { get; set; } = new RestClient();
        public static string Endpoint { get; set; }
        public static Dictionary<String, String> dataEx { get; set; }      
    }

}
