using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreMVC.Models
{
    public class PostalCode : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value == null) { return true; }

            foreach(var c in value.ToString())
            {
                if(!Char.IsDigit(c)&&c != '-')
                {
                    return false;
                }

            }
            

            return true;
        }

    }
}