using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStoreMVC.Models.Annotations;
namespace OnlineStoreMVC.Models
{
    public class UserViewModel
    {

        [Key]
        public int UserID { get; set; }

        public String Nickname { get; set; }

        [Display(Name = "Imię")]
        [DataType(DataType.Text, ErrorMessage = "Zły format")]
        [OnlyText(ErrorMessage="Pole nie może zawierać znaków liczbowych")]
        [MaxLength(100,ErrorMessage="Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(2,ErrorMessage="Musisz wprowadzić minimalne 2 znaki")]
        public String Name { get; set; }
        
        [Display(Name = "Drugie imię")]
        [DataType(DataType.Text, ErrorMessage = "Zły format")]
        [OnlyText(ErrorMessage = "Pole nie może zawierać znaków liczbowych")]
        [MaxLength(100,ErrorMessage="Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(2,ErrorMessage="Musisz wprowadzić minimalne 2 znaki")]
        public String Secondname { get; set; }

        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text, ErrorMessage = "Zły format")]
        [OnlyText(ErrorMessage = "Pole nie może zawierać znaków liczbowych")]
        [MaxLength(100,ErrorMessage="Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(2,ErrorMessage="Musisz wprowadzić minimalne 2 znaki")]
        public String Surname { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Zły format")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(5, ErrorMessage = "Musisz wprowadzić minimalne 5 znaków")]
        public String Email { get; set; }

        [Display(Name = "Kraj")]
        [DataType(DataType.Text, ErrorMessage = "Zły format")]
        [OnlyText(ErrorMessage = "Pole nie może zawierać znaków liczbowych")]
        [MaxLength(100, ErrorMessage = "Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(2, ErrorMessage = "Musisz wprowadzić minimalne 2 znaki")]
        public String Country { get; set; }

        [Display(Name = "Miasto")]
        [OnlyText(ErrorMessage = "Pole nie może zawierać znaków liczbowych")]
        [DataType(DataType.Text, ErrorMessage = "Zły format")]
        [MaxLength(100, ErrorMessage = "Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(2, ErrorMessage = "Musisz wprowadzić minimalne 2 znaki")]
        public String City { get; set; }

        [Display(Name = "Kod pocztowy")]
        [DataType(DataType.PostalCode,ErrorMessage="Zły format")]
        [PostalCode(ErrorMessage="Pole zawiera niedopuszczalne znaki. Dopuszczalne to 0-9 i '-'")]
        [MaxLength(10,ErrorMessage="Kod pocztyowy dłuższy niż 10 znaków ?")]
        [MinLength(4, ErrorMessage = "Musisz wprowadzić minimalne 4 znaki")]
        
        public String PostalCode { get; set; }

        [Display(Name = "Zdjęcie")]
        public String ImagePath { get; set; }

        [Display(Name = "Adres")]
        [MaxLength(100, ErrorMessage = "Można wprowadzić maksymalnie 100 znaków")]
        [MinLength(2, ErrorMessage = "Musisz wprowadzić minimalne 2 znaki")]
        public String Address { get; set; }

        [Display(Name="Numer telefonu")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Zły format")]
        [Phone]
        [MaxLength(20, ErrorMessage = "Można wprowadzić maksymalnie 20 cyfr")]
        [MinLength(2, ErrorMessage = "Musisz wprowadzić minimalne 2 znaki")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Numer komórkowy")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Zły format")]
        [Phone]
        [MaxLength(20, ErrorMessage = "Można wprowadzić maksymalnie 20 cyfr")]
        [MinLength(2, ErrorMessage = "Musisz wprowadzić minimalne 2 znaki")]
        public String CellNumber { get; set; }

      


        //Only for admin

        [Display(Name = "Adres IP")]
        public String LastIPAddress { get; set; }
        [Display(Name = "Data")]
        public String LastDateTime { get; set; }

        [Display(Name = "Przeglądarka")]
        public String BrowserType { get; set; }
        [Display(Name = "Ilosć odwiedzin")]
        public int VisitCount { get; set; }

      
        


        
        


    }
}