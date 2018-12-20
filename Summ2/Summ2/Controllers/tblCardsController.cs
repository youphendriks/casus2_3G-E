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
    public class tblCardsController : Controller
    {
        private MijnContext db = new MijnContext();

        // GET: tblCards
        public ActionResult Index()
        {
            return View(db.tblCards.ToList());
        }

        // GET: tblCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCard tblCard = db.tblCards.Find(id);
            if (tblCard == null)
            {
                return HttpNotFound();
            }
            return View(tblCard);
        }

        // GET: tblCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardID,Name,Owned,State,Foil,Language,BuyPrice,CurrentPrice")] tblCard tblCard)
        {
            if (ModelState.IsValid)
            {
                db.tblCards.Add(tblCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCard);
        }

        // GET: tblCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCard tblCard = db.tblCards.Find(id);
            if (tblCard == null)
            {
                return HttpNotFound();
            }
            return View(tblCard);
        }

        // POST: tblCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardID,Name,Owned,State,Foil,Language,BuyPrice,CurrentPrice")] tblCard tblCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCard);
        }

        // GET: tblCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCard tblCard = db.tblCards.Find(id);
            if (tblCard == null)
            {
                return HttpNotFound();
            }
            return View(tblCard);
        }

        // POST: tblCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCard tblCard = db.tblCards.Find(id);
            db.tblCards.Remove(tblCard);
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
