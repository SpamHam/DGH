using BLLGateway.DTOModels;
using BLLGateway.Gateway;
using MVC_DGHAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DGHAdmin.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGenericGateway<ProductDTO> _productGateway = new Facade().GetProductGateway();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<ShoppingCartItem> cartItems = (List<ShoppingCartItem>)Session["cart"];
            return View(cartItems);
        }

        public ActionResult Add(int id)
        {
            List<ShoppingCartItem> cartItems = (List<ShoppingCartItem>)Session["cart"];
            ShoppingCartItem cartItem = cartItems.Find(item => item.Id == id);

            if (cartItem == null)
            {
                var product = _productGateway.Get("product", id);
                cartItem = new ShoppingCartItem { Id = product.id, productName = product.name, UnitPrice = product.salesPrice, Quantity = 1 };
                cartItems.Add(cartItem);
            }
            else
                cartItem.Quantity++;

            return RedirectToAction("ClientIndex", "product");
        }

        [ChildActionOnly]
        public ActionResult NoOfItems()
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<ShoppingCartItem>();
            List<ShoppingCartItem> cartItems = (List<ShoppingCartItem>)Session["cart"];
            var noOfItems = cartItems.Sum(item => item.Quantity);
            return Content("[" + noOfItems + "]");
        }
    }
}