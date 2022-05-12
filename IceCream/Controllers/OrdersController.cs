using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IceCream.Models;
using Microsoft.AspNet.Identity;

namespace IceCream.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        // GET: Orders
        public ActionResult Index()
        {
            var orderId = Session["OrderId"];
            if(orderId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var order = db.Orders.Find(orderId);
            if(order.Status == 4)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerId,ShipName,ShipAddress,ShipPhone")] Order order)
        {           
            var cart = new CartModel();          
            if (ModelState.IsValid)
            {
                order.OwnerId = User.Identity.GetUserId();
                order.TotalPrice = cart.GrandTotalMoney();
                order.CreatedAt = DateTime.Now;
                order.UpdatedAt = DateTime.Now;
                order.Status = 1;
                db.Orders.Add(order);
                foreach(var cartItem in cart.GetCartItems())
                {
                    var orderDetails = new OrderDetail()
                    {
                        BookId = cartItem.Id,
                        BookName = cartItem.ProductName,
                        BookThumbnail = cartItem.Thumbnail,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.Price,
                        OrderId = order.Id,
                    };
                    db.OrderDetails.Add(orderDetails);
                }
                db.SaveChanges();
                Session["GrandTotal"] = cart.GrandTotalMoney();
                Session["OrderId"] = order.Id;
                cart.RemoveCartModel();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FullName", order.OwnerId);           
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FullName", order.OwnerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,TotalPrice,ShipName,ShipAddress,ShipPhone,CreatedAt,UpdatedAt,Status")] Order order)
        {            
            if (ModelState.IsValid)
            {         
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FullName", order.OwnerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult PaymentOrder(int id)
        {
            var order = db.Orders.Find(id);
            if(order != null)
            {
                order.Status = 4;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new { 
                message = "Payment successfull",
            });
        }
    }
}
