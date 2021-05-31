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
            using Image image = Image.FromFile(path);
            using MemoryStream m = new MemoryStream();
            image.Save(m, image.RawFormat);
            byte[] imageBytes = m.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
        public static Bitmap LoadBase64(this string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(bytes, 0, bytes.Length);
            Image image = Image.FromStream(ms, true);
            return new Bitmap(image);
        }
    }
}
