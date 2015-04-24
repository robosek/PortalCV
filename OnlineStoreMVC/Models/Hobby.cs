using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Hobby
    {

        public int HobbyId { get; set; }

        public String UserName { get; set; }

        [Display(Name = "Napisz o swoich zainteresowaniach")]
        public String HobbyDesc { get; set; }
      
    }
}