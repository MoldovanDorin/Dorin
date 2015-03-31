using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisertatieModels.Models;
using DisertatieEntity;

namespace DisertatieModels.Controllers
{
    public class PaymentsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Payments/

        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.UserProfile);
            return View(payments.ToList());
        }

        //
        // GET: /Payments/Details/5

        public ActionResult Details(int id = 0)
        {
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            return View(payments);
        }

        //
        // GET: /Payments/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Payments/Create

        [HttpPost]
        public ActionResult Create(Payments payments)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", payments.UserId);
            return View(payments);
        }

        //
        // GET: /Payments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", payments.UserId);
            return View(payments);
        }

        //
        // POST: /Payments/Edit/5

        [HttpPost]
        public ActionResult Edit(Payments payments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", payments.UserId);
            return View(payments);
        }

        //
        // GET: /Payments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            return View(payments);
        }

        //
        // POST: /Payments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Payments payments = db.Payments.Find(id);
            db.Payments.Remove(payments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}