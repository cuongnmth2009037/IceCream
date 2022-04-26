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
        
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
        
            return View();
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
            return View();
        }
        public ActionResult Recipe()
        {
            return View();
        }
    }
}