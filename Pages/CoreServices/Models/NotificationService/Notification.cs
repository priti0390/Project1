using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSData.Pages.CoreServices
   
{

    public class Notification
    {
        public string notificationId { get; set; }
        public string transactionId { get; set; }
        public string activityId { get; set; }
        public string hrn { get; set; }

        public string createdAt { get; set; }
        public EmailMessage emailMessage { get; set; }
    }

    public class EmailMessage
    {
        public string emailId { get; set; }
        public object[] dataContext { get; set; }
    }
}
