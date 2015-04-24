using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStoreMVC.App_Code.Helpers.Panels
{
    public static class PanelHelper
    {
        public static Panel Panel(this HtmlHelper html,string title,PanelStyle style)
        {
            return new Panel(html,title,style);
        }

    }
}