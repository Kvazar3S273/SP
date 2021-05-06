using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            InitializeComponent();

            string URI = "https://ba2h.ga/api/Girls/search";
            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(URI);
            txb.Text = "Дані отримано!";
            
            List<GirlVM> getgirls = JsonConvert.DeserializeObject<List<GirlVM>>(json);
            //GirlVM g1 = getgirls[2];
            //txb.Text = g1.Name;

            girls = new ObservableCollection<GirlVM>(getgirls);

            dgGirls.ItemsSource = girls;

        }
        private void BtnGetGirls_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
