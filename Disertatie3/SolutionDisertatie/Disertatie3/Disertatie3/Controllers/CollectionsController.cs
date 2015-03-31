using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisertatieModels.Models;
using DisertatieEntity;
using WebMatrix.WebData;
using DisertatieModels.Filters;

namespace DisertatieModels.Controllers
{
    public class CollectionsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Collections/

        public ActionResult Index()
        {
            var collections = db.Collections.Include(c => c.UserProfile);
            return View(collections.ToList());
        }

        //
        // GET: /Collections/Details/5

        public ActionResult Details(int id = 0)
        {
            Collections collections = db.Collections.Find(id);
            if (collections == null)
            {
                return HttpNotFound();
            }
            return View(collections);
        }

        //
        // GET: /Collections/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Collections/Create

        
        [HttpPost]
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Create(Collections collections)
        {
            if (ModelState.IsValid)
            {
                int memberId = WebSecurity.GetUserId(User.Identity.Name);
                collections.UserId = memberId;
                db.Collections.Add(collections);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", collections.UserId);
            return View(collections);
        }

        //
        // GET: /Collections/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Collections collections = db.Collections.Find(id);
            if (collections == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", collections.UserId);
            return View(collections);
        }

        //
        // POST: /Collections/Edit/5

        [HttpPost]
        public ActionResult Edit(Collections collections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", collections.UserId);
            return View(collections);
        }

        //
        // GET: /Collections/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Collections collections = db.Collections.Find(id);
            if (collections == null)
            {
                return HttpNotFound();
            }
            return View(collections);
        }

        //
        // POST: /Collections/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Collections collections = db.Collections.Find(id);
            db.Collections.Remove(collections);
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