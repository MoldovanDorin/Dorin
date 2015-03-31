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
    public class RecipesController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /Recipes/

        public ActionResult Index()
        {
            var recipes = db.Recipes.Include(r => r.UserProfile);
            return View(recipes.ToList());
        }

        //
        // GET: /Recipes/Details/5

        public ActionResult Details(int id = 0)
        {
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        //
        // GET: /Recipes/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Recipes/Create

        [HttpPost]
        public ActionResult Create(Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", recipes.UserId);
            return View(recipes);
        }

        //
        // GET: /Recipes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", recipes.UserId);
            return View(recipes);
        }

        //
        // POST: /Recipes/Edit/5

        [HttpPost]
        public ActionResult Edit(Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", recipes.UserId);
            return View(recipes);
        }

        //
        // GET: /Recipes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        //
        // POST: /Recipes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipes recipes = db.Recipes.Find(id);
            db.Recipes.Remove(recipes);
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