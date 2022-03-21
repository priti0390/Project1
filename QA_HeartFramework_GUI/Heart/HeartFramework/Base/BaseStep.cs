using HeartFramework.Config;
using HeartFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.info("Opened the browser !!!");
        }

        public virtual void NavigatepSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT2);
            LogHelpers.info("Opened the browser !!!");
        }

        public virtual void NavigateAUT3()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT3);
            LogHelpers.info("Opened the browser !!!");
        }
    }
}
