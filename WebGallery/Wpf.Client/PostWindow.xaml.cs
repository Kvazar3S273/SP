using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UIHelper;
using Wpf.Client.Validation;

namespace Wpf.Client
{
    /// <summary>
    /// Логика взаимодействия для PostWindow.xaml
    /// </summary>
    public partial class PostWindow : Window
    {
        //private string file_selected = string.Empty;
        public string file_name { get; set; }
        public static string New_FileName { get; set; }
        public PostWindow()
        {
            InitializeComponent();
        }
        //Кнопка для вибору фото
        private void btn_select_photo_Click(object sender, RoutedEventArgs e)
        {
            //Bitmap image;
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    //image = new Bitmap(dlg.FileName);
                    New_FileName = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show("Неможливо відкрити!");
                }
                //New_FileName = dlg.FileName;
            }
        }

        //Кнопка зберігання
        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            _ = PostRequest();
            //await Task.Run(() => PostRequest());
            //Close();
        }
        //private async void btn_save_Click(object sender, RoutedEventArgs e)
        //{
        //    await Task.Run(() => PostRequest());
        //    Close();
        //}


        public async Task<bool> PostRequest()
        {
            //if (!string.IsNullOrEmpty(file_selected))
            //{

            //    var extension = System.IO.Path.GetExtension(file_selected);
            //    var imageName = System.IO.Path.GetFileNameWithoutExtension(file_selected) + extension;
            //    var dir = Directory.GetCurrentDirectory();
            //    var saveDir = System.IO.Path.Combine(dir, "uploads");
            //    var fileSave = System.IO.Path.Combine(saveDir, imageName);
            //    var bmp = ResizeImage.ResizeOrigImg(
            //        new Bitmap(System.Drawing.Image.FromFile(file_selected)), 75, 75);
            //    bmp.Save(fileSave, ImageFormat.Jpeg);
            //    file_name = fileSave;
            //}

            string base64 = ImageHelper.ImageConvertToBase64(New_FileName);
            var app = Application.Current as IGetConfiguration;
            var serverUrl = app.Configuration.GetSection("ServerUrl").Value;

            WebRequest request = WebRequest.Create($"{serverUrl}api/Cars/add");
            {
                request.Method = "POST";
                request.ContentType = "application/json";
            };
            int.TryParse(tbyear.Text, out int yearParse);
            float.TryParse(tbcapacity.Text, out float capacityParse);
            string json = JsonConvert.SerializeObject(new
            {
                Mark = tbmark.Text.ToString(),
                Model = tbmodel.Text.ToString(),
                Year = yearParse,
                Fuel = tbfuel.Text.ToString(),
                Capacity = capacityParse,
                Image = base64
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
            catch (WebException e)
            {
                //using (WebResponse response = e.Response)
                //{
                //    HttpWebResponse httpResponse = (HttpWebResponse)response;
                //    MessageBox.Show("Error code: " + httpResponse.StatusCode);
                //    using (Stream data = response.GetResponseStream())
                //    using (var reader = new StreamReader(data))
                //    {
                //        string text = reader.ReadToEnd();
                //        var errors = JsonConvert.DeserializeObject<AddCarValidation>(text);
                //        MessageBox.Show(text);
                //        MessageBox.Show(errors.Errors.Mark[0]);
                //        MessageBox.Show(errors.Errors.Model[0]);
                //        MessageBox.Show(errors.Errors.Year[0]);
                //        MessageBox.Show(errors.Errors.Fuel[0]);
                //        return false;
                //    }
                //}

                using (WebResponse response = e.Response)
                {

                    HttpWebResponse web = (HttpWebResponse)response;

                    MessageBox.Show("Error-->>>" + web.StatusCode);
                    using var stream = e.Response.GetResponseStream();
                    using var reader = new StreamReader(stream);
                    var responces = reader.ReadToEnd();
                    var errors = JsonConvert.DeserializeObject<AddCarValidation>(responces);


                    List<ErrorsList> eror_list = new List<ErrorsList>();
                    eror_list = errors.Errors.ErrorRes().Select(item => new ErrorsList
                    {
                        Errorlist = item
                    }).ToList();

                    dg_errors.ItemsSource = eror_list;
                }
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
    }
}
