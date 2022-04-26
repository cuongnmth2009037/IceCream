using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class UpgradeAccount
    {
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int AccountId { get; set; }         
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Pack")]
        public int PackId { get; set; }
        public virtual Pack Pack { get; set; }
    }
}