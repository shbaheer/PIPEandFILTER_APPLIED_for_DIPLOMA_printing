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
    public class DepartmentApprovalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DepartmentApprovals
        public ActionResult Index()
        {
            return View(db.DepartmentApproval.ToList());
        }

        // GET: DepartmentApprovals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentApproval departmentApproval = db.DepartmentApproval.Find(id);
            if (departmentApproval == null)
            {
                return HttpNotFound();
            }
            return View(departmentApproval);
        }

        // GET: DepartmentApprovals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentApprovals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DRID,Cridate,thesis")] DepartmentApproval departmentApproval)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentApproval.Add(departmentApproval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentApproval);
        }

        // GET: DepartmentApprovals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentApproval departmentApproval = db.DepartmentApproval.Find(id);
            if (departmentApproval == null)
            {
                return HttpNotFound();
            }
            return View(departmentApproval);
        }

        // POST: DepartmentApprovals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DRID,Cridate,thesis")] DepartmentApproval departmentApproval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentApproval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentApproval);
        }

        // GET: DepartmentApprovals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentApproval departmentApproval = db.DepartmentApproval.Find(id);
            if (departmentApproval == null)
            {
                return HttpNotFound();
            }
            return View(departmentApproval);
        }

        // POST: DepartmentApprovals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentApproval departmentApproval = db.DepartmentApproval.Find(id);
            db.DepartmentApproval.Remove(departmentApproval);
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
        public ActionResult check()
        {
           
            
            return View();
        }
        public ActionResult Approval(DepartmentApproval da)
        {
            if (ModelState.IsValid)
            {
                
                db.DepartmentApproval.Add(da);
                db.SaveChanges();
                return RedirectToAction("check");
            }
            else
            {
                ViewBag.Message = "The Diploma Request is not Completed please check your Request";
            }
            return View("check");
        }
        public ActionResult search( int id)
        {
            var dr = (from d in db.diploma_Requests select new { d.ID, d.Name, d.IDCardID, d.Graduate }).Where(x => x.ID == id).ToList().FirstOrDefault();

            var da= db.diploma_Requests.Find(id);
            if (da == null)
            {

                ViewBag.Message = "This Request not exist in system";
                return View("check");

            }
            else
            {
                ViewBag.ID = id;
                ViewBag.Name = dr.Name;
                ViewBag.IdCard = dr.IDCardID;
                ViewBag.Graduate = dr.Graduate;
                if (dr.IDCardID == null)
                {
                    ViewBag.State = null;
                }
                else if (dr.Name == null)
                {
                    ViewBag.State = null;
                }
                else if (dr.Graduate == null)
                {
                    ViewBag.State = null;
                }
                else
                {
                    ViewBag.State = "Completed";
                }
            }
            return View("check");
        }
    }
}
