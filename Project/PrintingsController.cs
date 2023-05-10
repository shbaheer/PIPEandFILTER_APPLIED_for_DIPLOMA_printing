using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dip2.Models;

namespace dip2.Controllers
{
    public class PrintingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Printings
        public ActionResult Index()
        {
            return View(db.Printing.ToList());
        }

        // GET: Printings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printing printing = db.Printing.Find(id);
            if (printing == null)
            {
                return HttpNotFound();
            }
            return View(printing);
        }

        // GET: Printings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Printings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DRID,States")] Printing printing)
        {
            if (ModelState.IsValid)
            {
                db.Printing.Add(printing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(printing);
        }

        // GET: Printings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printing printing = db.Printing.Find(id);
            if (printing == null)
            {
                return HttpNotFound();
            }
            return View(printing);
        }

        // POST: Printings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DRID,States")] Printing printing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(printing);
        }

        // GET: Printings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printing printing = db.Printing.Find(id);
            if (printing == null)
            {
                return HttpNotFound();
            }
            return View(printing);
        }

        // POST: Printings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Printing printing = db.Printing.Find(id);
            db.Printing.Remove(printing);
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
