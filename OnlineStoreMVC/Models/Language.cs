using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public String UserName { get; set; }
        [Display(Name = "Język")]
        public String LanguageName { get; set; }
        [Display(Name = "Poziom zaawansowania")]
        public String LanguageSpeakLevel { get; set; }
    }  
}