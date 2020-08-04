using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryApp.View
{
    class Helpers
    {
        public static Bitmap ResizeImage(Image img, int w, int h)
        {
            Rectangle rect = new Rectangle(0, 0, w, h);

            Bitmap newImg = new Bitmap(w, h);

            newImg.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(newImg))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes imgAttr = new ImageAttributes())
                {
                    imgAttr.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttr);
                }
            }

            return newImg;
        }
    }
}
