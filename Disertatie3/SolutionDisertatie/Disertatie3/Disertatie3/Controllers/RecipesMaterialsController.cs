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
    public class RecipesMaterialsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /RecipesMaterials/

        public ActionResult Index()
        {
            var recipesmaterials = db.RecipesMaterials.Include(r => r.Recipes).Include(r => r.RawMaterials);
            return View(recipesmaterials.ToList());
        }

        //
        // GET: /RecipesMaterials/Details/5

        public ActionResult Details(int id = 0)
        {
            RecipesMaterials recipesmaterials = db.RecipesMaterials.Find(id);
            if (recipesmaterials == null)
            {
                return HttpNotFound();
            }
            return View(recipesmaterials);
        }

        //
        // GET: /RecipesMaterials/Create

        public ActionResult Create()
        {
            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume");
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume");
            return View();
        }

        //
        // POST: /RecipesMaterials/Create

        [HttpPost]
        public ActionResult Create(RecipesMaterials recipesmaterials)
        {
            if (ModelState.IsValid)
            {
                db.RecipesMaterials.Add(recipesmaterials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume", recipesmaterials.RecipesId);
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume", recipesmaterials.RawMaterialsId);
            return View(recipesmaterials);
        }

        //
        // GET: /RecipesMaterials/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RecipesMaterials recipesmaterials = db.RecipesMaterials.Find(id);
            if (recipesmaterials == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume", recipesmaterials.RecipesId);
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume", recipesmaterials.RawMaterialsId);
            return View(recipesmaterials);
        }

        //
        // POST: /RecipesMaterials/Edit/5

        [HttpPost]
        public ActionResult Edit(RecipesMaterials recipesmaterials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipesmaterials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume", recipesmaterials.RecipesId);
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume", recipesmaterials.RawMaterialsId);
            return View(recipesmaterials);
        }

        //
        // GET: /RecipesMaterials/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecipesMaterials recipesmaterials = db.RecipesMaterials.Find(id);
            if (recipesmaterials == null)
            {
                return HttpNotFound();
            }
            return View(recipesmaterials);
        }

        //
        // POST: /RecipesMaterials/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipesMaterials recipesmaterials = db.RecipesMaterials.Find(id);
            db.RecipesMaterials.Remove(recipesmaterials);
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