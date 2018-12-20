using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Summ2.Models;

namespace Summ2.Controllers
{
    public class tblDecksController : Controller
    {
        private MijnContext db = new MijnContext();

        // GET: tblDecks
        public ActionResult Index()
        {
            return View(db.tblDecks.ToList());
        }

        // GET: tblDecks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDeck tblDeck = db.tblDecks.Find(id);
            if (tblDeck == null)
            {
                return HttpNotFound();
            }
            return View(tblDeck);
        }

        // GET: tblDecks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDecks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeckID,DeckName")] tblDeck tblDeck)
        {
            if (ModelState.IsValid)
            {
                db.tblDecks.Add(tblDeck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDeck);
        }

        // GET: tblDecks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDeck tblDeck = db.tblDecks.Find(id);
            if (tblDeck == null)
            {
                return HttpNotFound();
            }
            return View(tblDeck);
        }

        // POST: tblDecks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeckID,DeckName")] tblDeck tblDeck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDeck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDeck);
        }

        // GET: tblDecks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDeck tblDeck = db.tblDecks.Find(id);
            if (tblDeck == null)
            {
                return HttpNotFound();
            }
            return View(tblDeck);
        }

        // POST: tblDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDeck tblDeck = db.tblDecks.Find(id);
            db.tblDecks.Remove(tblDeck);
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
