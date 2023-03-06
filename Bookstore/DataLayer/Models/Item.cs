using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataLayer.Models
{
    public class Item
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public DateTime insert_date { get; set; }
        public string category { get; set; }
    }
}
