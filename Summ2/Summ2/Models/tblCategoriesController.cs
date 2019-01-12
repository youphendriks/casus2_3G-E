using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Summ2.ViewModels;

namespace Summ2.Models
{
    public class tblCategoriesController : Controller
    {
        private CollectionContext db = new CollectionContext();

        // GET: tblCategories
        public ActionResult Index(int? id)
        {
            var viewModel = new CollectionViewModel();

            string query = "SELECT tblCategory.CategoryID, tblCategory.CategoryName, tblCategory.CategoryBeschrijving, tblCategory.Status, tblCategory.StatusBeschrijving FROM tblCategory LEFT JOIN tblItemCategory ON tblCategory.CategoryID = tblItemCategory.CategoryID WHERE tblItemCategory.ItemCategoryID IS NULL";
            using (CollectionContext context = new CollectionContext())
            {
                var list = context.Database.SqlQuery<tblCategory>(query).ToList();
                viewModel.tblCategory = list;
                //return View(viewModel);
            }
            string query2 = "SELECT tblCategory.CategoryID, tblCategory.CategoryName, tblCategory.CategoryBeschrijving, tblCategory.Status, tblCategory.StatusBeschrijving, SUM(tblItem.BuyPrice) AS TotalBuyPrice, SUM(tblItem.CurrentPrice) AS TotalCurrentPrice, SUM(tblItem.CurrentPrice) - SUM(tblItem.BuyPrice) AS TotalPriceDiffrence FROM tblCategory INNER JOIN tblItemCategory ON tblCategory.CategoryID = tblItemCategory.CategoryID INNER JOIN tblItem ON tblItemCategory.ItemID = tblItem.ItemID GROUP BY tblCategory.CategoryID,tblCategory.CategoryName,tblCategory.CategoryBeschrijving,tblCategory.Status,tblCategory.StatusBeschrijving";
            using (CollectionContext context = new CollectionContext())
            {
                var list2 = context.Database.SqlQuery<tblCategoryTotals>(query2).ToList();
                viewModel.tblCategoryTotals = list2;
                //return View(viewModel);
            }
            //viewModel.tblCategory = list;

            if (id != null)
            {
                viewModel.tblItem = db.tblItems;
                var items = new List<tblItem>();
                tblItem eenItem = new tblItem();
                viewModel.tblItemCategory = db.tblCategories.Where(i => i.CategoryID == id.Value).Single().tblItemCategories;
                foreach (tblItemCategory pp in viewModel.tblItemCategory)
                {
                    eenItem = (tblItem) db.tblItems.Where(i => i.ItemID == pp.ItemID).Single();
                    items.Add(eenItem);
                }
                viewModel.tblItem = items;

            }
            return View(viewModel);
        }

        // GET: tblCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblCategory);
        }

        // GET: tblCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,CategoryBeschrijving")] tblCategory tblCategory)
        {
            tblCategory.Status = "Te Accorderen creatie";
            if (ModelState.IsValid)
            {
                db.tblCategories.Add(tblCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCategory);
        }

        // GET: tblCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblCategory);
        }

        // POST: tblCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,CategoryBeschrijving")] tblCategory tblCategory)
        {
            tblCategory.Status = "Te Accorderen wijziging";
            if (ModelState.IsValid)
            {
                db.Entry(tblCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategory);
        }

        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblCategory);
        }

        // POST: tblCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "CategoryID,CategoryName,CategoryBeschrijving,Status,StatusBeschrijving")] tblCategory tblCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategory);
        }

        // GET: tblCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblCategory);
        }

        // POST: tblCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCategory tblCategory = db.tblCategories.Find(id);
            db.tblCategories.Remove(tblCategory);
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
