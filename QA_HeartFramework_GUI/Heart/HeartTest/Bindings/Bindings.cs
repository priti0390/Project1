using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HeartTest.Bindings
{
    [Binding]
    public class Bindings
    {
        public ScenarioContext scenarioContext;
        public Bindings(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

    }
}
