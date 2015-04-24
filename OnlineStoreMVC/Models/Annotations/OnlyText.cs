using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreMVC.Models.Annotations
{
    public class OnlyText : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value == null) { return true; }

            foreach (char c in value.ToString())
            {

                if(Char.IsDigit(c))
                {
                    return false;

                }

               
            }

            return true;

        }

    }
}