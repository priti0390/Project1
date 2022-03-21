using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Config
{
    public class HeartElement : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name { get { return (string)base["name"]; } }

        [ConfigurationProperty("aut", IsRequired = true)]
        public string AUT { get { return (string)base["aut"]; } }

        [ConfigurationProperty("aut2", IsRequired = true)]
        public string AUT2 { get { return (string)base["aut2"]; } }

        [ConfigurationProperty("aut3", IsRequired = true)]
        public string AUT3 { get { return (string)base["aut3"]; } }

        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser { get { return (string)base["browser"]; } }

        [ConfigurationProperty("testType", IsRequired = true)]
        public string TestType { get { return (string)base["testType"]; } }

        [ConfigurationProperty("isLog", IsRequired = false)]
        public string IsLog { get { return (string)base["isLog"]; } }

        [ConfigurationProperty("logPath", IsRequired = true)]
        public string LogPath { get { return (string)base["logPath"]; } }

        [ConfigurationProperty("environment", IsRequired = true)]
        public string Environment { get { return (string)base["environment"]; } }

        [ConfigurationProperty("platform", IsRequired = true)]
        public string Platform { get { return (string)base["platform"]; } }

        [ConfigurationProperty("testData", IsRequired = true)]
        public string TestData { get { return (string)base["testData"]; } }
    }
}
