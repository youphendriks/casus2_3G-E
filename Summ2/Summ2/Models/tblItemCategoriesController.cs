using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Summ2.Models
{
    public class tblItemCategoriesController : Controller
    {
        private CollectionContext db = new CollectionContext();

        // GET: tblItemCategories
        public ActionResult Index()
        {
            var tblItemCategories = db.tblItemCategories.Include(t => t.tblCategory).Include(t => t.tblItem);
            return View(tblItemCategories.ToList());
        }

        // GET: tblItemCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemCategory tblItemCategory = db.tblItemCategories.Find(id);
            if (tblItemCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblItemCategory);
        }

        // GET: tblItemCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.tblCategories, "CategoryID", "CategoryName");
            ViewBag.ItemID = new SelectList(db.tblItems, "ItemID", "ItemName");
            return View();
        }

        // POST: tblItemCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemCategoryID,ItemID,CategoryID")] tblItemCategory tblItemCategory)
        {
            tblItemCategory.Status = "Te Accorderen creatie";
            if (ModelState.IsValid)
            {
                db.tblItemCategories.Add(tblItemCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.tblCategories, "CategoryID", "CategoryName", tblItemCategory.CategoryID);
            ViewBag.ItemID = new SelectList(db.tblItems, "ItemID", "ItemName", tblItemCategory.ItemID);
            return View(tblItemCategory);
        }

        // GET: tblItemCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemCategory tblItemCategory = db.tblItemCategories.Find(id);
            if (tblItemCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.tblCategories, "CategoryID", "CategoryName", tblItemCategory.CategoryID);
            ViewBag.ItemID = new SelectList(db.tblItems, "ItemID", "ItemName", tblItemCategory.ItemID);
            return View(tblItemCategory);
        }

        // POST: tblItemCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemCategoryID,ItemID,CategoryID")] tblItemCategory tblItemCategory)
        {
            tblItemCategory.Status = "Te Accorderen wijziging";
            if (ModelState.IsValid)
            {
                db.Entry(tblItemCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.tblCategories, "CategoryID", "CategoryName", tblItemCategory.CategoryID);
            ViewBag.ItemID = new SelectList(db.tblItems, "ItemID", "ItemName", tblItemCategory.ItemID);
            return View(tblItemCategory);
        }

        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemCategory tblItemCategory = db.tblItemCategories.Find(id);
            if (tblItemCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.tblCategories, "CategoryID", "CategoryName", tblItemCategory.CategoryID);
            ViewBag.ItemID = new SelectList(db.tblItems, "ItemID", "ItemName", tblItemCategory.ItemID);
            return View(tblItemCategory);
        }

        // POST: tblItemCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "ItemCategoryID,ItemID,CategoryID,Status,StatusBeschrijving")] tblItemCategory tblItemCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItemCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.tblCategories, "CategoryID", "CategoryName", tblItemCategory.CategoryID);
            ViewBag.ItemID = new SelectList(db.tblItems, "ItemID", "ItemName", tblItemCategory.ItemID);
            return View(tblItemCategory);
        }

        // GET: tblItemCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemCategory tblItemCategory = db.tblItemCategories.Find(id);
            if (tblItemCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblItemCategory);
        }

        // POST: tblItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItemCategory tblItemCategory = db.tblItemCategories.Find(id);
            db.tblItemCategories.Remove(tblItemCategory);
            db.SaveChanges();
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
