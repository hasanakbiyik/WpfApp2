using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp2;

namespace WpfApp2
{

    public class Product
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string? detail { get; set; }
        public double? price { get; set; }
        public int stock_quantity { get; set; }
        public int? barcode { get; set; }
        public int? store_id { get; set; }
        public List<Category> categories { get; set; }
        public double entry_price { get; set; }
        public int kdv { get; set; }
        
        
    }

    public class ProductRoot
    {
        public List<Product> data { get; set; }
        public int last_page { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int total { get; set; }
    }
}




