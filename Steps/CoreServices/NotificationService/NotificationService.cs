using HeartFramework.BaseAPI;
using HeartFramework.Helpers;
using HRSData.Pages.CoreServices;
using HRSData.Pages.CoreServices.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace HeartTest.Steps.CoreServices
{
    [Binding]
    public class NotificationService : APIHelper
    {
        [When(@"I perform Get Request for Notification service")]
        public void WhenIPerformGetRequestForNotificationService()
        {
            BaseModel<Notification>.currentServicePage = APIHelper.getRequest<Notification>(Common.endpoint, Common.id, Common.keyword_BearerToken, "");
        }

        [Then(@"I validate Sort by ""(.*)"" in Get Request for Notification service")]
        public void ThenIValidateSortByInGetRequestForNotificationService(string p0)
        {
            Common.keyword_Param_val = p0;
            BaseModel<Notification>.currentServicePage = APIHelper.getRequest<Notification>(Common.endpoint, "sort", Common.keyword_BearerToken);
            getSort(p0);
        }


    }
}
