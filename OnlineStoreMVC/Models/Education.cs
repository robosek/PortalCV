using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Education
    {
        public int EducationId { get; set; }

        public String UserName { get; set; }

        [Display(Name = "Nazwa szkoły")]
        [MaxLength(100, ErrorMessage = "Nazwa jest za długa")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String SchollName { get; set; }

        [Display(Name = "Typ szkoły")]
        [MaxLength(100, ErrorMessage = "Nazwa jest za długa")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String TypeOfSchool { get; set; }

        [Display(Name = "Rozpoczęcie nauki")]
        public String StartDate { get; set; }

        [Display(Name = "Zakończenie nauki")]
        public String EndDate { get; set; }

       

    }
}