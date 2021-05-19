using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Wpf.Client
{
    class ResizeImage
    {
        public static Bitmap ResizeOrigImg(Bitmap image, int nWidth, int nHeight)
        {
            int newWidth, newHeight;
            var coefH = (double)nHeight / (double)image.Height;
            var coefW = (double)nWidth / (double)image.Width;
            if (coefW >= coefH)
            {
                newHeight = (int)(image.Height * coefH);
                newWidth = (int)(image.Width * coefH);
            }
            else
            {
                newHeight = (int)(image.Height * coefW);
                newWidth = (int)(image.Width * coefW);
            }

            using (Bitmap outBmp = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb))
            {

                using (var g = Graphics.FromImage(outBmp))
                {
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                    return new Bitmap(outBmp);

                }
            }

        }
    }
}
