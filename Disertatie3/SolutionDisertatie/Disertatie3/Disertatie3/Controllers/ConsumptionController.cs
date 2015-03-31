using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisertatieModels.Models;
using DisertatieEntity;
using DisertatieModels.Filters;
using WebMatrix.WebData;

namespace DisertatieModels.Views
{
    public class ConsumptionController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Consumption/

        public ActionResult Index()
        {
            var consumption = db.Consumption.Include(c => c.UserProfile);
            return View(consumption.ToList());
        }

        //
        // GET: /Consumption/Details/5

        public ActionResult Details(int id = 0)
        {
            Consumption consumption = db.Consumption.Find(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        //
        // GET: /Consumption/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Consumption/Create

        [HttpPost]
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Create(Consumption consumption)
        {
            if (ModelState.IsValid)
            {
                int memberId = WebSecurity.GetUserId(User.Identity.Name);
                consumption.UserId = memberId;
                db.Consumption.Add(consumption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", consumption.UserId);
            return View(consumption);
        }

        //
        // GET: /Consumption/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Consumption consumption = db.Consumption.Find(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", consumption.UserId);
            return View(consumption);
        }

        //
        // POST: /Consumption/Edit/5

        [HttpPost]
        public ActionResult Edit(Consumption consumption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", consumption.UserId);
            return View(consumption);
        }

        //
        // GET: /Consumption/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Consumption consumption = db.Consumption.Find(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        //
        // POST: /Consumption/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumption consumption = db.Consumption.Find(id);
            db.Consumption.Remove(consumption);
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