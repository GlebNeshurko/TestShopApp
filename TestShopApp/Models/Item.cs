using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestShopApp.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public string material { get; set; }
    }
}