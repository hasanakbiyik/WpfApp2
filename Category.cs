using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2
{
    // CategoryRoot myDeserializedClass = JsonConvert.DeserializeObject<CategoryRoot>(myJsonResponse);

    public class Category
    {
        public string _id { get; set; }
        public string category_name { get; set; }
        public int sub_category { get; set; }

        
    }

    public class CategoryRoot
    {
        public List<Category> data { get; set; }
        public int last_page { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int total { get; set; }
    }


}
