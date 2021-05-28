using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UIHelper
{
    public static class ImageHelper
    {
        public static string ImageConvertToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public static Bitmap LoadBase64(this string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return new Bitmap(image);
        }
    }
}
