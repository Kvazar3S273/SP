using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WebGallery.Entities;
using WebGallery.Entities.Data;

namespace Wpf.Client
{
    /// <summary>
    /// Логика взаимодействия для DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        private EFDataContext _context;
        public long _Id { get; set; }
        public DeleteWindow(long Id, EFDataContext context)
        {
            InitializeComponent();
            _Id = Id;
            _context = context;
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Car car = _context.Cars.FirstOrDefault(y => y.Id == _Id);
            tbox_model.Text = car.Model.ToString();
            tbox_mark.Text = car.Mark.ToString();
            tbox_year.Text = car.Year.ToString();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _ = DeleteRequest();
        }
        public async Task<bool> DeleteRequest()
        {
            WebRequest request = WebRequest.Create($"http://localhost:5000/api/Cars/{_Id}");
            {
                request.Method = "DELETE";

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

            };
        }
    }
}
