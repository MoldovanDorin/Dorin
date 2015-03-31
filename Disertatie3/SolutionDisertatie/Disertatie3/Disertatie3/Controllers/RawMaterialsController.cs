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

namespace DisertatieModels.Controllers
{
    public class RawMaterialsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /RawMaterials/

        public ActionResult Index()
        {
            var rawmaterials = db.RawMaterials.Include(r => r.UserProfile);
            return View(rawmaterials.ToList());
        }

        //
        // GET: /RawMaterials/Details/5

        public ActionResult Details(int id = 0)
        {
            RawMaterials rawmaterials = db.RawMaterials.Find(id);
            if (rawmaterials == null)
            {
                return HttpNotFound();
            }
            return View(rawmaterials);
        }

        //
        // GET: /RawMaterials/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /RawMaterials/Create

        [HttpPost]
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Create(RawMaterials rawmaterials)
        {
            if (ModelState.IsValid)
            {
                int memberId = WebSecurity.GetUserId(User.Identity.Name);
                rawmaterials.UserId = memberId;
                db.RawMaterials.Add(rawmaterials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", rawmaterials.UserId);
            return View(rawmaterials);
        }

        //
        // GET: /RawMaterials/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RawMaterials rawmaterials = db.RawMaterials.Find(id);
            if (rawmaterials == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", rawmaterials.UserId);
            return View(rawmaterials);
        }

        //
        // POST: /RawMaterials/Edit/5

        [HttpPost]
        public ActionResult Edit(RawMaterials rawmaterials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rawmaterials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", rawmaterials.UserId);
            return View(rawmaterials);
        }

        //
        // GET: /RawMaterials/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RawMaterials rawmaterials = db.RawMaterials.Find(id);
            if (rawmaterials == null)
            {
                return HttpNotFound();
            }
            return View(rawmaterials);
        }

        //
        // POST: /RawMaterials/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RawMaterials rawmaterials = db.RawMaterials.Find(id);
            db.RawMaterials.Remove(rawmaterials);
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