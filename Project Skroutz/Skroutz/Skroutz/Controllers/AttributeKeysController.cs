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
    public class AttributeKeysController : Controller
    {
        private SkroutzContext db = new SkroutzContext();

        // GET: AttributeKeys
        public async Task<ActionResult> Index()
        {
            var attributeKeys = db.AttributeKeys.Include(a => a.Category);
            return View(await attributeKeys.ToListAsync());
        }

        // GET: AttributeKeys/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeKey attributeKey = await db.AttributeKeys.FindAsync(id);
            if (attributeKey == null)
            {
                return HttpNotFound();
            }
            return View(attributeKey);
        }

        // GET: AttributeKeys/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: AttributeKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,MeasurementUnit,DataType,CategoryId")] AttributeKey attributeKey)
        {
            if (ModelState.IsValid)
            {
                db.AttributeKeys.Add(attributeKey);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", attributeKey.CategoryId);
            return View(attributeKey);
        }

        // GET: AttributeKeys/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeKey attributeKey = await db.AttributeKeys.FindAsync(id);
            if (attributeKey == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", attributeKey.CategoryId);
            return View(attributeKey);
        }

        // POST: AttributeKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,MeasurementUnit,DataType,CategoryId")] AttributeKey attributeKey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attributeKey).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", attributeKey.CategoryId);
            return View(attributeKey);
        }

        // GET: AttributeKeys/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeKey attributeKey = await db.AttributeKeys.FindAsync(id);
            if (attributeKey == null)
            {
                return HttpNotFound();
            }
            return View(attributeKey);
        }

        // POST: AttributeKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AttributeKey attributeKey = await db.AttributeKeys.FindAsync(id);
            db.AttributeKeys.Remove(attributeKey);
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
