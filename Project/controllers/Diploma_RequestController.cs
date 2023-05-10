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
    public class Diploma_RequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Diploma_Request
        public ActionResult Index()
        {
            return View(db.diploma_Requests.ToList());
        }

        // GET: Diploma_Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diploma_Request diploma_Request = db.diploma_Requests.Find(id);
            if (diploma_Request == null)
            {
                return HttpNotFound();
            }
            return View(diploma_Request);
        }

        // GET: Diploma_Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diploma_Request/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,IDCardID,Graduate")] Diploma_Request diploma_Request)
        {
            if (ModelState.IsValid)
            {
                db.diploma_Requests.Add(diploma_Request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diploma_Request);
        }

        // GET: Diploma_Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diploma_Request diploma_Request = db.diploma_Requests.Find(id);
            if (diploma_Request == null)
            {
                return HttpNotFound();
            }
            return View(diploma_Request);
        }

        // POST: Diploma_Request/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IDCardID,Graduate")] Diploma_Request diploma_Request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diploma_Request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diploma_Request);
        }

        // GET: Diploma_Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diploma_Request diploma_Request = db.diploma_Requests.Find(id);
            if (diploma_Request == null)
            {
                return HttpNotFound();
            }
            return View(diploma_Request);
        }

        // POST: Diploma_Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diploma_Request diploma_Request = db.diploma_Requests.Find(id);
            db.diploma_Requests.Remove(diploma_Request);
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
