using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IceCream.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }      
        public int Status { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<IceCream.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<IceCream.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<IceCream.Models.Recipe> Recipes { get; set; }
        public System.Data.Entity.DbSet<IceCream.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<IceCream.Models.OrderDetail> OrderDetails { get; set; }
    }
}