using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreMVC.Models.Annotations
{
    public class FileSize : ValidationAttribute
    {
        

        private readonly int _maxFileSize;

        public FileSize(int maxFileSize)
        {

            _maxFileSize = maxFileSize;
        }


        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            return file.ContentLength != 0 || file.ContentLength < _maxFileSize ? 
             true : false;



        }


    }
}
           
                

