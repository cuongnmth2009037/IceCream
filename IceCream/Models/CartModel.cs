using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class CartModel
    {
        private List<CartItem> cartModel = HttpContext.Current.Session["cartModel"] as List<CartItem>;

        public bool AddItem(CartItem cartItem)
        {
            if (cartModel != null)
            {
                bool checkExist = false;
                foreach(var item in cartModel)
                {
                    if(item.Id == cartItem.Id)
                    {
                        item.Quantity += cartItem.Quantity;
                        checkExist = true;
                    }
                }
                if(! checkExist)
                {
                    cartModel.Add(cartItem);
                }
                HttpContext.Current.Session["cartModel"] = cartModel;
                return true;
            }
            List<CartItem> newCart = new List<CartItem>();
            newCart.Add(cartItem);
            HttpContext.Current.Session["cartModel"] = newCart;
            return true;
        }

        public bool UpdateItem(int id, int quantity)
        {
            if(cartModel == null)
            {
                return false;
            }
            foreach(var item in cartModel)
            {
                if(item.Id == id)
                {
                    item.Quantity = quantity;
                }
            }
            return true;
        }

        public bool RemoveItem(int id)
        {
           if(cartModel == null)
            {
                return false;
            }
           foreach(var item in cartModel)
            {
                if(item.Id == id)
                {
                    cartModel.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public double CalcTotalMoney()
        {
            double total = 0;
            if(cartModel != null)
            {
                foreach (var item in cartModel)
                {
                    total += item.Price * item.Quantity;
                }
            }
            return total;
        }

        public double TaxMoney()
        {
            double total = 0;
            if (cartModel != null)
            {
                foreach (var item in cartModel)
                {
                    total += (item.Price * item.Quantity);
                }
            }
            return total * 0.05;
        }

        public double GrandTotalMoney()
        {
            double total = 0;
            if (cartModel != null)
            {
                foreach (var item in cartModel)
                {
                    total += (item.Price * item.Quantity);
                }
            }
            return total + total * 0.05;
        }

        public List<CartItem> GetCartItems()
        {
            return cartModel;
        }

        public void RemoveCartModel()
        {
            HttpContext.Current.Session["cartModel"] = null;
        }
    }
}