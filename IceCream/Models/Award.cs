using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class Award
    {
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}