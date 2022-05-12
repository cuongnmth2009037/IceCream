using IceCream.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCream.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var book = db.Books.ToList();

            return View(book);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Product()
        {
            var book = db.Books.ToList();
            return View(book);
        }

        public ActionResult Recipe()
        {
            var recipe = db.Recipes.Where(r => r.Status == 2).OrderByDescending(r => r.CreatedAt).ToList();
            return View(recipe);
        }
        [Authorize]
        public ActionResult RecipeDetail(int id)
        {
            var recipe = db.Recipes.Find(id);
            return View(recipe);
        }       
    }

}
