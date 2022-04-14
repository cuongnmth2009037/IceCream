using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string BookName { get; set; }
        public string BookThumbnail { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}