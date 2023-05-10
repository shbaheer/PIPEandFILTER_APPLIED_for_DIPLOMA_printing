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
    public class facltiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: faclties
        public ActionResult Index()
        {
            return View(db.faclty.ToList());
        }

        // GET: faclties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faclty faclty = db.faclty.Find(id);
            if (faclty == null)
            {
                return HttpNotFound();
            }
            return View(faclty);
        }

        // GET: faclties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: faclties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DRID,Approval")] faclty faclty)
        {
            if (ModelState.IsValid)
            {
                db.faclty.Add(faclty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faclty);
        }

        // GET: faclties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faclty faclty = db.faclty.Find(id);
            if (faclty == null)
            {
                return HttpNotFound();
            }
            return View(faclty);
        }

        // POST: faclties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DRID,Approval")] faclty faclty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faclty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faclty);
        }

        // GET: faclties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faclty faclty = db.faclty.Find(id);
            if (faclty == null)
            {
                return HttpNotFound();
            }
            return View(faclty);
        }

        // POST: faclties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            faclty faclty = db.faclty.Find(id);
            db.faclty.Remove(faclty);
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
