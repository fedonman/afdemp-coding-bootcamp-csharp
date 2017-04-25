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
    [RoutePrefix("AttributeValues")]
    [Route("{action}")]
    public class AttributeValuesController : Controller
    {
        private SkroutzContext db = new SkroutzContext();

        // GET: AttributeValues
        [Route("")]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            var attributes = db.Attributes.Include(a => a.AttributeKey).Include(a => a.Product);
            return View(await attributes.ToListAsync());
        }

        // GET: AttributeValues/Details/5/10
        [Route("Details/{productId}/{attributeKeyId}")]
        public async Task<ActionResult> Details(int? productId, int? attributeKeyId)
        {
            if (productId == null || attributeKeyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeValue attributeValue = await db.Attributes.FindAsync(productId, attributeKeyId);
            if (attributeValue == null)
            {
                return HttpNotFound();
            }
            return View(attributeValue);
        }

        // GET: AttributeValues/Create
        public ActionResult Create()
        {
            ViewBag.AttributeKeyId = new SelectList(db.AttributeKeys, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: AttributeValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,AttributeKeyId,Value")] AttributeValue attributeValue)
        {
            if (ModelState.IsValid)
            {
                db.Attributes.Add(attributeValue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AttributeKeyId = new SelectList(db.AttributeKeys, "Id", "Name", attributeValue.AttributeKeyId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", attributeValue.ProductId);
            return View(attributeValue);
        }

        // GET: AttributeValues/Edit/5
        [Route("Edit/{productId}/{attributeKeyId}")]
        public async Task<ActionResult> Edit(int? productId, int? attributeKeyId)
        {
            if (productId == null || attributeKeyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeValue attributeValue = await db.Attributes.FindAsync(productId, attributeKeyId);
            if (attributeValue == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttributeKeyId = new SelectList(db.AttributeKeys, "Id", "Name", attributeValue.AttributeKeyId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", attributeValue.ProductId);
            return View(attributeValue);
        }

        // POST: AttributeValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,AttributeKeyId,Value")] AttributeValue attributeValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attributeValue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AttributeKeyId = new SelectList(db.AttributeKeys, "Id", "Name", attributeValue.AttributeKeyId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", attributeValue.ProductId);
            return View(attributeValue);
        }

        // GET: AttributeValues/Delete/5
        [Route("Delete/{productId}/{attributeKeyId}")]
        public async Task<ActionResult> Delete(int? productId, int? attributeKeyId)
        {
            if (productId == null || attributeKeyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeValue attributeValue = await db.Attributes.FindAsync(productId, attributeKeyId);
            if (attributeValue == null)
            {
                return HttpNotFound();
            }
            return View(attributeValue);
        }

        // POST: AttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{productId}/{attributeKeyId}")]
        public async Task<ActionResult> DeleteConfirmed(int productId, int attributeKeyId)
        {
            AttributeValue attributeValue = await db.Attributes.FindAsync(productId, attributeKeyId);
            db.Attributes.Remove(attributeValue);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public JsonResult GetAttributeKeysOfProduct(int productId)
        {
            int categoryId = db.Products.Find(productId).CategoryId;
            List<AttributeKey> attributes = db.AttributeKeys.Select(x => x).Where(x => x.CategoryId == categoryId).ToList();
            return Json(new SelectList(attributes, "Id", "Name"));
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
