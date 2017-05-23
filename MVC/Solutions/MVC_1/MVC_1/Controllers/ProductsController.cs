using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class ProductsController : Controller
    {
        private MyModel db = new MyModel();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Detail(int id)
        {
            var product = db.Products.Single(x => x.Id == id);
            return View(product);
        }
    }
}