using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string OwnerId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public double TotalPrice { get; set; }
        public string ShipName { get; set; }       
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }        
        public int Status { get; set; }       
    }
}