using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}