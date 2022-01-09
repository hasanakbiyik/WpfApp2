using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }

        private void btnEkle_Click(object sender, RoutedEventArgs e)
        {
            

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.1.8:3001/api/products");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                string productName = name.Text;
                int qty = Convert.ToInt32(stock_quantity.Text);

                Category cat = (Category)categoryGrid.SelectedItem;



                Product product = new Product();

                product.name = productName;
              
                product.stock_quantity = qty;

               

                product.categories = cat;

               
                string json = JsonConvert.SerializeObject(product);
                
                
                streamWriter.Write(json);

                //foreach (var control in this.Controls)
                //{
                //    if (control is TextBox)
                //    {
                //        var txt = (TextBox)control;
                //        txt.Clear();
                //    }
                //}

            };

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }

        private async void categoryGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://192.168.1.8:3001/");

            HttpResponseMessage response = await client.GetAsync("api/categories");

            string result = await response.Content.ReadAsStringAsync();


            //Category json = JsonConvert.DeserializeObject<Category>(result);
            CategoryRoot json = JsonConvert.DeserializeObject<CategoryRoot>(result);


            categoryGrid.ItemsSource = json.data;
        }

        
    }
}
