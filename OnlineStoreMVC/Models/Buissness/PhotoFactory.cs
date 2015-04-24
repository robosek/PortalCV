using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models.Bussiness
{
    public class PhotoFactory
    {
       public static void Thumbnail(string fileName, string path, int thumWi, int thumHi, bool maintainAspect)
        {
            var originalFile = Path.Combine(path,fileName);

            var source = Image.FromFile(originalFile);

            //We're checking the picture size. If it's smaller then size added as an argument, we're returning current photo as thumbnail
            if (source.Width <= thumWi && source.Height <= thumHi) return;

            Bitmap thumbnail;

            int width = thumWi;

            int height = thumHi;


            //if we should to maintain the ratio of picture, we must check if the widhth or heigh is bigger. Then we can resize picture
            if(maintainAspect)
            {

                if(source.Width > source.Height)
                {
                    width = thumWi;
                    height = (int)(source.Height * ((decimal)thumWi / source.Width));
                }
                else
                {
                    height = thumHi;
                    width = (int)(source.Width * ((decimal)thumHi / source.Height));
                }

            }



          using(thumbnail = new Bitmap(width,height))
          {
              using (Graphics g = Graphics.FromImage(thumbnail))
              {

                  g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                  g.FillRectangle(Brushes.Transparent, 0, 0, width, height);

                  g.DrawImage(source, 0, 0, width, height);



              }


              var thumbnailName = Path.Combine(path, "min_" + fileName);

              thumbnail.Save(thumbnailName);
              
          }

          source.Dispose();

        }



    }
}
           





            


