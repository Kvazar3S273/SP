using Newtonsoft.Json;
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
using WebGallery.Entities;
using WebGallery.Entities.Data;
using WebGallery.Models;

namespace Wpf.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<GirlVM> girls = new ObservableCollection<GirlVM>();
        private EFDataContext _context = new EFDataContext();
        public long _id { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGetData_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadDataCompleted += AsyncDownloadDataCompleted;
                Uri uri = new Uri("https://ba2h.ga/api/Cars/search");
                webClient.DownloadDataAsync(uri);
            }
        }

        public void AsyncDownloadDataCompleted(Object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                string result = Encoding.Default.GetString(e.Result);
                var cars = JsonConvert.DeserializeObject<List<CarVM>>(result);
                dgCars.ItemsSource = cars;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            new PostWindow().ShowDialog();
        }

        private void btnPut_Click(object sender, RoutedEventArgs e)
        {
            if (dgCars.SelectedItem != null)
            {
                if (dgCars.SelectedItem is Car)
                {
                    var carView = dgCars.SelectedItem as Car;
                    long id = carView.Id;
                    _id = id;
                    MessageBox.Show(_id.ToString());
                }
            }

            PutWindow edit = new PutWindow(_id, _context);
            edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCars.SelectedItem != null)
            {
                if (dgCars.SelectedItem is Car)
                {
                    var carView = dgCars.SelectedItem as Car;
                    long id = carView.Id;
                    _id = id;
                    MessageBox.Show(_id.ToString());
                }
            }

            DeleteWindow delete = new DeleteWindow(_id, _context);
            delete.ShowDialog();
        }
    }
}
