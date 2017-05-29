using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1mvc.Models;

namespace WebApplication1mvc.Controllers
{
    // authentication - identifying user
    // authorization - authorized usage/access for an user
    /*[Authorize]  */// authentication vs authorization
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Cart cart;

        public CartsController()
        {
            cart = new Cart();
            for (int i = 1; i < 6; i++)
            {
                cart.AddProduct(new Product("ID" + i, "product" + i, 100 * i));
            }
        }
        // GET: Carts
        public ActionResult Index()
        {
            return View(cart);
        }

        
        [HttpPost]
        public ActionResult Add(string ProductID) // get cartid also from client??
        {
            if (ModelState.IsValid)
            {
                // get
                return RedirectToAction("Index");
            }
            //Session[key];
            //TempData[key]
            else
            {
                TempData["error"] = "cannot add to cart"; // temp data is erased as soon as read unless u call tempdata[key].keep
                return RedirectToAction("Index", "Home");  
            }
        }

        [HttpPost]
        public ActionResult Remove(string ProductID)
        {
            if (ModelState.IsValid)
            {
                cart.RemoveProduct(ProductID);
                // remove from cart
                return RedirectToAction("Index");
            }
            //Session[key];
            //TempData[key]
            else
            {
                TempData["error"] = "cannot add to cart"; // temp data is erased as soon as read unless u call tempdata[key].keep
                return RedirectToAction("Index", "Home");
            }
        }
       
        [HttpGet]
        public ActionResult Payment(string CartID)
        {
            return View(CartID); // send cartid so client can send it back to identify the payment
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
