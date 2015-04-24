using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Certificate
    {
        public int CertificateId { get; set; }

        public String UserName { get; set; }

        [Display(Name = "Nazwa certyfikatu")]
        [MaxLength(100, ErrorMessage = "Nazwa jest za długa")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String CertificateName { get; set; }

        [Display(Name = "Jakie umiejętności potwierdza certyfikat?")]
        [MaxLength(500, ErrorMessage = "Opis jest za długi")]
        [MinLength(2, ErrorMessage = "Nazwa jest za krótka")]
        public String CertificateDesc { get; set; }


    }
}