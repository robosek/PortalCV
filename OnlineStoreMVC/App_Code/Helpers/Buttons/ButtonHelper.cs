using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStoreMVC.App_Code.Helpers.Buttons
{
    public class ButtonHelper
    {

        public static MvcHtmlString Button(string caption,ButtonStyle style,ButtonSize size)
        {


            if (size != ButtonSize.Normal)
            {
                return new MvcHtmlString(string.Format("<button type=\"button\" class=\"btn btn-{0} btn-{1}\">{2}</button>", style.ToString().ToLower(), ToBootstrapSize(size), caption));
            }


            return new MvcHtmlString(string.Format("<button type=\"button\" class=\"btn btn-{0}\">{1}</button>", style.ToString().ToLower(), caption));



        }

        private static string ToBootstrapSize(ButtonSize size)
        {
            string bootstrapSize = string.Empty;

            switch (size)
            {
                case ButtonSize.Large:
                    bootstrapSize = "lg";
                    break;
                case ButtonSize.Small:
                    bootstrapSize = "sm";
                    break;
                case ButtonSize.ExtraSmall:
                    bootstrapSize = "xs";
                    break;
            }
            return bootstrapSize;
            
        }


    }
}