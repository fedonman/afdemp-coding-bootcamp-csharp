using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Skroutz.DAL;
using Skroutz.Models;

namespace Skroutz.Controllers
{
    public class InventoriesController : Controller
    {
        private SkroutzContext db = new SkroutzContext();

        // GET: Inventories
        public async Task<ActionResult> Index()
        {
            var inventories = db.Inventories.Include(i => i.Product).Include(i => i.Store);
            return View(await inventories.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<ActionResult> Details(int? productId, int? storeId)
        {
            if (productId == null || storeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(productId, storeId);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products.Include(x => x.Category).ToList(), "Id", "Name", "Category.Name", 0);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,StoreId,Price")] Inventory inventory)
        {
            var inv = db.Inventories.Find(inventory.ProductId, inventory.StoreId);
            if (ModelState.IsValid && inv == null)
            {
                db.Inventories.Add(inventory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products.OrderBy(x => x.Name), "Id", "Name", "Category.Name", inventory.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", inventory.StoreId);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<ActionResult> Edit(int? productId, int? storeId)
        {
            if (productId == null || storeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(productId, storeId);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products.OrderBy(x => x.Name), "Id", "Name", "Category.Name", inventory.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", inventory.StoreId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,StoreId,Price")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products.OrderBy(x => x.Name), "Id", "Name", "Category.Name", inventory.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", inventory.StoreId);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<ActionResult> Delete(int? productId, int? storeId)
        {
            if (productId == null || storeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(productId, storeId);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int productId, int storeId)
        {
            Inventory inventory = await db.Inventories.FindAsync(productId, storeId);
            db.Inventories.Remove(inventory);
            await db.SaveChangesAsync();
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
    }
}
