using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://192.168.1.8:3001/");

            HttpResponseMessage response = await client.GetAsync("api/products");

            string result = await response.Content.ReadAsStringAsync();


            ProductRoot json = JsonConvert.DeserializeObject<ProductRoot>(result);



            dataGrid.ItemsSource = json.data;
        }

        private void btnYeniEkle_Click(object sender, RoutedEventArgs e)
        {
            //TODO: bakılacak
            Window win2 = new Window1();
            win2.Show();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://192.168.1.8:3001/");

            HttpResponseMessage response = await client.GetAsync("api/products");

            string result = await response.Content.ReadAsStringAsync();


            ProductRoot json = JsonConvert.DeserializeObject<ProductRoot>(result);



            dataGrid.ItemsSource = json.data;
        }
    }
}
