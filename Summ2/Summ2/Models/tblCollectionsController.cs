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
    public class tblCollectionsController : Controller
    {
        private CollectionContext db = new CollectionContext();

        // GET: tblCollections
        public ActionResult Index()
        {
            return View(db.tblCollections.ToList());
        }

        // GET: tblCollections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCollection tblCollection = db.tblCollections.Find(id);
            if (tblCollection == null)
            {
                return HttpNotFound();
            }
            return View(tblCollection);
        }

        // GET: tblCollections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCollections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollectionID,CollectionName,CollectionDiscription")] tblCollection tblCollection)
        {
            if (ModelState.IsValid)
            {
                db.tblCollections.Add(tblCollection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCollection);
        }

        // GET: tblCollections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCollection tblCollection = db.tblCollections.Find(id);
            if (tblCollection == null)
            {
                return HttpNotFound();
            }
            return View(tblCollection);
        }

        // POST: tblCollections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollectionID,CollectionName,CollectionDiscription")] tblCollection tblCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCollection);
        }

        // GET: tblCollections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCollection tblCollection = db.tblCollections.Find(id);
            if (tblCollection == null)
            {
                return HttpNotFound();
            }
            return View(tblCollection);
        }

        // POST: tblCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCollection tblCollection = db.tblCollections.Find(id);
            db.tblCollections.Remove(tblCollection);
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
