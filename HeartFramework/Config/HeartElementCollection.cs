using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Config
{
    [ConfigurationCollection(typeof(HeartElement), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class HeartElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HeartElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as HeartElement).Name;
        }

        public new HeartElement this[string type]
        {
            get
            {
                return (HeartElement)base.BaseGet(type);
            }
        }
    }
}
