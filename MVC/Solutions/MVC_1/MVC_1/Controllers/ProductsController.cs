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

        // GET /Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

      
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}