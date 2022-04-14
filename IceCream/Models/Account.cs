using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
    }
}