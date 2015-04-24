using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.App_Code.Helpers.Alerts
{
    public class AlertFluent : IAlertFluent
    {

        private readonly Alert parent;

        public AlertFluent(Alert parent)
        {
            this.parent = parent;
        }

        public IAlertFluent Dismissible(bool canDismiss = true)
        {
            return parent.Dismissible(canDismiss);
        }

        public string ToHtmlString()
        {
            return parent.ToHtmlString();
        }

    }
}