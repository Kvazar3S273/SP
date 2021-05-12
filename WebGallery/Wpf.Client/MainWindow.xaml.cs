﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebGallery.Entities.Data;
using WebGallery.Models;

namespace Wpf.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<GirlVM> girls = new ObservableCollection<GirlVM>();
        public MainWindow()
        {
            /// // Create a request using a URL that can receive a post.
            ///WebRequest request = WebRequest.Create("http://localhost:5000/api/cars/add");
            /// // Set the Method property of the request to POST.
            ///request.Method = "POST";
            /// // Create POST data and convert it to a byte array.
            ///string postData = JsonConvert.SerializeObject(new
            ///{
            ///    Mark = "Dacia",
            ///    Model = "Logan MCV",
            ///    Year = 2007,
            ///    Fuel = "Бензин",
            ///    Сapacity = 1.6F,
            ///    Image = "Logan.jpg"
            ///});
            ///byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            /// // Set the ContentType property of the WebRequest.
            ///request.ContentType = "application/json";
            /// // Set the ContentLength property of the WebRequest.
            ///request.ContentLength = byteArray.Length;
            /// // Get the request stream.
            ///Stream dataStream = request.GetRequestStream();
            /// // Write the data to the request stream.
            ///dataStream.Write(byteArray, 0, byteArray.Length);
            /// // Close the Stream object.
            ///dataStream.Close();
            ///try
            ///{
            ///    // Get the response.
            ///    WebResponse response = request.GetResponse();
            ///    // Display the status.
            ///    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            ///    // Get the stream containing content returned by the server.
            ///    // The using block ensures the stream is automatically closed.
            ///    using (dataStream = response.GetResponseStream())
            ///    {
            ///        // Open the stream using a StreamReader for easy access.
            ///        StreamReader reader = new StreamReader(dataStream);
            ///        // Read the content.
            ///        string responseFromServer = reader.ReadToEnd();
            ///        // Display the content.
            ///        Console.WriteLine(responseFromServer);
            ///    }
            ///    // Close the response.
            ///    response.Close();
            ///}
            ///catch (Exception ex)
            ///{
            ///    MessageBox.Show(ex.Message);
            ///}

            InitializeComponent();
            Car _car = new Car
            {
                Mark = "Zaz",
                Model = "Vida",
                Year = 2018,
                Fuel = "Бензин",
                Capacity = 1.1F,
                Image = "Zaz.jpg"
            };
            RequestForPost(_car);

            //using (WebClient webClient = new WebClient())
            //{
            //    webClient.DownloadDataCompleted += AsyncDownloadDataCompleted;
            //    Uri uri = new Uri("https://ba2h.ga/api/Girls/search");
            //    webClient.DownloadDataAsync(uri);
            //}
        }
        public void AsyncDownloadDataCompleted(Object sender, DownloadDataCompletedEventArgs e)
        {
            string result = Encoding.Default.GetString(e.Result);
            var girls = JsonConvert.DeserializeObject<List<GirlVM>>(result);
            dgGirls.ItemsSource = girls;
        }

        public void RequestForPost (Car car)
        {
            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("http://localhost:5000/api/cars/add");
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = JsonConvert.SerializeObject(new
            {
                Mark = car.Mark,
                Model = car.Model,
                Year = car.Year,
                Fuel = car.Fuel,
                Сapacity = car.Capacity,
                Image = car.Image
            });
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            try
            {
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);
                }

                // Close the response.
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
