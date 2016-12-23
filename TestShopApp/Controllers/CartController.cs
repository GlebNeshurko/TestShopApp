using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestShopApp.Models;

namespace TestShopApp.Controllers
{
    public class CartController : Controller
    {

        private _dbContext repository = new _dbContext();

        // GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddInToCart(int productId, string returnUrl)
        {
            Item item = repository.ItemsContext
            .FirstOrDefault(p => p.id == productId); 
            if (item != null)
            {
                GetCart().AddToCart(1, item);
            }
            return RedirectToAction("Index", new { returnUrl } );
        }

        public RedirectToRouteResult RemoveFromCart(int itemId, string returnUrl)
        {
            Item item = repository.ItemsContext
            .FirstOrDefault(p => p.id == itemId);
            if (item != null)
            {
                GetCart().RemoveLine(item);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}