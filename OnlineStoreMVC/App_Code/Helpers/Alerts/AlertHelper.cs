using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineStoreMVC.App_Code.Helpers.Alerts
{
    public static class AlertHelper
    {
        public static Alert Alert(this HtmlHelper html,string message)
        {
            return new Alert(message);


        }

    }
}