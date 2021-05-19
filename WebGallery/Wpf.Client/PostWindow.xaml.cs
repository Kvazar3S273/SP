using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.Client
{
    /// <summary>
    /// Логика взаимодействия для PostWindow.xaml
    /// </summary>
    public partial class PostWindow : Window
    {
        private string file_selected = string.Empty;
        public string file_name { get; set; }
        public PostWindow()
        {
            InitializeComponent();
        }
        //Кнопка для вибору фото
        private void btn_select_photo(object sender, RoutedEventArgs e)
        {
            Bitmap image;
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;" +
                "*.PNG|All files (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    image = new Bitmap(dlg.FileName);
                    file_selected = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show("Неможливо відкрити!");
                }
            }
        }

        //Кнопка зберігання
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            _ = PostRequest();
        }

        public async Task<bool> PostRequest()
        {
            if (!string.IsNullOrEmpty(file_selected))
            {

                var extension = System.IO.Path.GetExtension(file_selected);
                var imageName = System.IO.Path.GetFileNameWithoutExtension(file_selected) + extension;
                var dir = Directory.GetCurrentDirectory();
                var saveDir = System.IO.Path.Combine(dir, "uploads");
                var fileSave = System.IO.Path.Combine(saveDir, imageName);
                var bmp = ResizeImage.ResizeOrigImg(
                    new Bitmap(System.Drawing.Image.FromFile(file_selected)), 75, 75);
                bmp.Save(fileSave, ImageFormat.Jpeg);
                file_name = fileSave;
            }

            WebRequest request = WebRequest.Create("http://localhost:5000/api/Cars/add");
            {
                request.Method = "POST";
                request.ContentType = "application/json";
            };
            string json = JsonConvert.SerializeObject(new
            {
                Mark = tbmark.Text.ToString(),
                Model = tbmodel.Text.ToString(),
                Year = int.Parse(tbyear.Text),
                Fuel = tbfuel.Text.ToString(),
                Capacity = float.Parse(tbcapacity.Text),
                Image = file_name
            });
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            using (Stream stream = await request.GetRequestStreamAsync())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                await request.GetResponseAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
    }
}
