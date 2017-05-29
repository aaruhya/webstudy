using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1mvc.Models;

namespace WebApplication1mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            for(int i=1;i<=10;i++)
            {
                products.Add(new Product("ID" + i, "Product" + i, i * 100));
            }
            ViewBag.Products = products;
            return View(products);
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
    }
}