using System;
using System.ComponentModel.DataAnnotations;


namespace OnlineStoreMVC.Models
{
    public class Experience
    {

        public int ExperienceId { get; set; }

        public String UserName { get; set; }

        [Display(Name = "Nazwa firmy")]
        [MaxLength(100, ErrorMessage = "Nazwa jest za długa")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String CompanyName { get; set; }

        [Display(Name = "Stanowisko")]
        [MaxLength(100, ErrorMessage = "Nazwa jest za długa")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String JobTitle { get; set; }

        [Display(Name = "Rozpoczęcie pracy")]
        public String JobStartTime { get; set; }

        [Display(Name = "Zakończenie pracy")]
        public String JobEndTime { get; set; }

        [Display(Name = "Krótki opis")]
        [MaxLength(2000, ErrorMessage = "Opis jest za długi")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String Description { get; set; }
    }
}