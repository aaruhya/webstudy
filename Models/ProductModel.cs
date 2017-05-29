using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1mvc.Models
{
    public class Product
    {
        public String ID { get; set; }
        public double Price { get; set; }
        public string DisplayName { get; set; }

        public Product(string id,string name,double price)
        {
            ID = id;
            DisplayName = name;
            Price = price;
        }
    }
}