using IceCream.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCream.Controllers
{
    public class RecipeClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        // GET: RecipeClient
        public ActionResult Index()
        {          
            return View();          
        }
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        // POST: Admin/Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,AuthorId,Name,Description,Thumbnail,Materral,DetailStep")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.AuthorId = User.Identity.GetUserId();
                recipe.CreatedAt = DateTime.Now;
                recipe.UpdatedAt = DateTime.Now;
                recipe.Status = 1;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", recipe.AuthorId);
            return View(recipe);
        }
    }
}