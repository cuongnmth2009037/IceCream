using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Thumbnail { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double GetTotalPrice()
        {
            return Price * Quantity;
        }            
    }
}