using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Skill
    {
        public int SkillId { get; set; }

        public String UserName { get; set; }

        [Display(Name = "Umiejętność")]
        [MaxLength(100, ErrorMessage = "Nazwa jest za długa")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String SkillName { get; set; }

        [Display(Name = "Opis umiejętności")]
        [MaxLength(500, ErrorMessage = "Opis jest za długi")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String SkillDescription { get; set; }
    }
}