using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStoreMVC.Models.Annotations;

namespace OnlineStoreMVC.Models
{
    public class Photo
    {


        //[FileSize(6000, ErrorMessage = "Plik ma nieprawidłowe rozmiary")]
        //[FileExtensions(Extensions =".jpg", ErrorMessage = "Zły typ pliku")]
        //[ImageSize(250,250,ErrorMessage = "Zdjęcie jest za małe. Minimalne rozmiary to 250px na 250px")]
        public HttpPostedFileBase File { get; set; }

        

    }
}