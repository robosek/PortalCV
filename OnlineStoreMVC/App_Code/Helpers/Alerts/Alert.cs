using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStoreMVC.App_Code.Helpers.Alerts
{
    public class Alert
    {
        private AlertStyle style;
        private bool dismissible;
        private string message;

        public Alert(string message)
        {
            this.message = message;
        }


        public IAlertFluent Danger()
        {
            style = AlertStyle.Danger;
            return new AlertFluent(this);
        }
        public IAlertFluent Info()
        {
            style = AlertStyle.Info;
            return new AlertFluent(this);
        }
        public IAlertFluent Success()
        {
            style = AlertStyle.Success;
            return new AlertFluent(this);
        }
        public IAlertFluent Warning()
        {
            style = AlertStyle.Warning;
            return new AlertFluent(this);
        }

        public IAlertFluent Dismissible(bool canDismiss = true)
        {
            this.dismissible = canDismiss;
            return new AlertFluent(this);
        }


        public string ToHtmlString()
        {
            var alertDiv = new TagBuilder("div");

            alertDiv.AddCssClass("alert");
            alertDiv.AddCssClass("alert-"+style.ToString().ToLower());
            alertDiv.InnerHtml = message;

            if(dismissible)
            {
                alertDiv.AddCssClass("alert-dismissable");
                alertDiv.InnerHtml += AddCloseButton();

            }

            return alertDiv.ToString();
        }


        private static TagBuilder AddCloseButton()
        {
            var closeButton = new TagBuilder("button");

            closeButton.AddCssClass("close");

            closeButton.Attributes.Add("data-dismiss","alert");

            closeButton.InnerHtml = "&times;";

            return closeButton;

        }

      



    }
}