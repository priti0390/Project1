using System.Configuration;

namespace HeartFramework.Config
{
    class HeartTestConfiguration : ConfigurationSection
    {
        private static HeartTestConfiguration _HeartConfig = (HeartTestConfiguration)ConfigurationManager.GetSection("HeartTestConfiguration");

        public static HeartTestConfiguration HeartSettings { get { return _HeartConfig; } }

        [ConfigurationProperty("testSettings")]
        public HeartElementCollection TestSettings { get { return (HeartElementCollection)base["testSettings"]; } }

    }
}
