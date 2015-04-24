using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OnlineStoreMVC.Models.Annotations
{
    public class ImageSize : ValidationAttribute
    {
        private readonly int _minHeight;
        private readonly int _minWidth;

        public ImageSize(int minHeight, int minWidth)
        {
            _minHeight = minHeight;
            _minWidth = minWidth;


        }


        public override bool IsValid(object value)
        {

            HttpPostedFileBase file = value as HttpPostedFileBase;

            try
            {
                var image = Image.FromFile(file.FileName);


                return (image.Width < _minWidth || image.Height < _minHeight) ? false : true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
           

            
           

          


