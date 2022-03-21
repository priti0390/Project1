using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HeartFramework.Config
{
    public class AppSettings
    {
        [JsonProperty("run")]
        public String run { get; set; }

        [JsonProperty("timeStampFormat")]
        public String timeStampFormat { get; set; }
    }


    public class TestSetting
    {
        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("aut")]
        public String aut { get; set; }

        [JsonProperty("aut2")]
        public String aut2 { get; set; }

        [JsonProperty("aut3")]
        public String aut3 { get; set; }

        [JsonProperty("jsonfilepath")]
        public String jsonfilepath { get; set; }

        [JsonProperty("platform")]
        public String platform { get; set; }

        [JsonProperty("testType")]
        public String testType { get; set; }

        [JsonProperty("environment")]
        public String environment { get; set; }

        [JsonProperty("logPath")]
        public String logPath { get; set; }

        [JsonProperty("testData")]
        public String testData { get; set; }
    }

    public class Config
    {
        [JsonProperty("appSettings")]
        public AppSettings AppSettings { get; set; }

        [JsonProperty("testSettings")]
        public List<TestSetting> TestSettings { get; set; }
    }

    public class Root
    {
        [JsonProperty("Config")]
        public Config Config { get; set; }
    }
    class HeartTestConfiguration : ConfigurationSection
    {
        private static HeartTestConfiguration _HeartConfig = (HeartTestConfiguration)ConfigurationManager.GetSection("HeartTestConfiguration");

        public static HeartTestConfiguration HeartSettings { get { return _HeartConfig; } }

        [ConfigurationProperty("testSettings")]
        public HeartElementCollection TestSettings { get { return (HeartElementCollection)base["testSettings"]; } }

    }
}
