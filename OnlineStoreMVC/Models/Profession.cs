using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }

        public String UserName { get; set; }

        [Display(Name="Zawód")]
        public String ProfessionName { get; set; }


    }
}