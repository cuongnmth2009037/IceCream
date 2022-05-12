using IceCream.Models;
using IceCream.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCream.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        /*[Authorize]*/
        public ActionResult Index()
        {
            List<CartItem> cartItems = new List<CartItem>();
            var cartModel = new CartModel();
            if(cartModel.GetCartItems() != null)
            {
                cartItems = cartModel.GetCartItems();
            }
            ViewBag.Tax = cartModel.TaxMoney();
            ViewBag.GrandTotal = cartModel.GrandTotalMoney();
            ViewBag.SubTotal = cartModel.CalcTotalMoney();
            return View(cartItems);
        }
        [Authorize]
        public ActionResult AddToCart(int id)
        {
            var product = db.Books.Find(id);
            var cartModel = new CartModel();
            if(product == null)
            {
                return RedirectToAction("Product", "Home");
            }
            var cartItem = new CartItem()
            {
                Id = product.Id,
                ProductName = product.Title,
                Price = product.Price,
                Quantity = 1,
                Thumbnail = product.Thumbnail
            };
            cartModel.AddItem(cartItem);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCartItem(int id)
        {
            var cartModel = new CartModel();
            cartModel.RemoveItem(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult UpdateCart(UpdateCartItem updateCartItem)
        {
            var cartModel = new CartModel();
            cartModel.UpdateItem(updateCartItem.Id, updateCartItem.Quantity);
            var tax = cartModel.TaxMoney();
            var grandTotal = cartModel.GrandTotalMoney();
            var subTotal = cartModel.CalcTotalMoney();
            return Json(new
            {
                subTotal = subTotal,
                tax = tax,
                grandTotal = grandTotal
            });
        }      
        
        public ActionResult Payment()
        {
            List<CartItem> cartItems = new List<CartItem>();
            var cartModel = new CartModel();
            if (cartModel.GetCartItems() != null)
            {
                cartItems = cartModel.GetCartItems();
            }
            ViewBag.Tax = cartModel.TaxMoney();
            ViewBag.GrandTotal = cartModel.GrandTotalMoney();
            ViewBag.SubTotal = cartModel.CalcTotalMoney();
            return View(cartItems);
        }
    }
}