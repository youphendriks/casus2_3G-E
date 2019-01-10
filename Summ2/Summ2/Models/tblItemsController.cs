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
    public class tblItemsController : Controller
    {
        private CollectionContext db = new CollectionContext();

        // GET: tblItems
        public ActionResult Index(int? id)
        {
            var viewModel = new CollectionViewModel();
            
            viewModel.tblCollection = db.tblCollections;

            if (id != null)
            {
                viewModel.tblItem = db.tblItems.Where(i => i.ColletionID == id.Value);
                //ViewBag.Collection = ;
                //viewModel.tblItem = viewModel.tblCollection.Where(i => i.CollectionID == id.Value).Single().tblItem;

                //viewModel.tblCategory = db.tblCategories;
                //var categories = new List<tblCategory>();
                //tblCategory eenCategory = new tblCategory();
                //viewModel.tblItemCategory = db.tblItems.Where(i => i.ItemID == id.Value).Single().tblItemCategories;
                //foreach (tblItemCategory pp in viewModel.tblItemCategory)
                //{
                //    eenCategory = (tblCategory) db.tblCategories.Where(i => i.CategoryID == pp.CategoryID).Single();
                //    categories.Add(eenCategory);
                //}
                //viewModel.tblCategory = categories;

            }
            return View(viewModel);
        }
        
      
        // GET: tblItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItem tblItem = db.tblItems.Find(id);
            if (tblItem == null)
            {
                return HttpNotFound();
            }
            return View(tblItem);
        }

        // GET: tblItems/Create
        public ActionResult Create()
        {
            ViewBag.ColletionID = new SelectList(db.tblCollections, "CollectionID", "CollectionName");
            return View();
        }

        // POST: tblItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ColletionID,ItemName,ItemBeschrijving,ItemOwned,ItemState,BuyPrice,CurrentPrice")] tblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                db.tblItems.Add(tblItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColletionID = new SelectList(db.tblCollections, "CollectionID", "CollectionName", tblItem.ColletionID);
            return View(tblItem);
        }

        // GET: tblItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItem tblItem = db.tblItems.Find(id);
            if (tblItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColletionID = new SelectList(db.tblCollections, "CollectionID", "CollectionName", tblItem.ColletionID);
            return View(tblItem);
        }

        // POST: tblItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ColletionID,ItemName,ItemBeschrijving,ItemOwned,ItemState,BuyPrice,CurrentPrice")] tblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColletionID = new SelectList(db.tblCollections, "CollectionID", "CollectionName", tblItem.ColletionID);
            return View(tblItem);
        }

        // GET: tblItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItem tblItem = db.tblItems.Find(id);
            if (tblItem == null)
            {
                return HttpNotFound();
            }
            return View(tblItem);
        }

        // POST: tblItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItem tblItem = db.tblItems.Find(id);
            db.tblItems.Remove(tblItem);
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
