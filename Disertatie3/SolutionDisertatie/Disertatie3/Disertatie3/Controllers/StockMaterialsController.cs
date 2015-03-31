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
    public class StockMaterialsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /StockMaterials/

        public ActionResult Index()
        {
            return View(db.StockMaterials.ToList());
        }

        //
        // GET: /StockMaterials/Details/5

        public ActionResult Details(int id = 0)
        {
            StockMaterials stockmaterials = db.StockMaterials.Find(id);
            if (stockmaterials == null)
            {
                return HttpNotFound();
            }
            return View(stockmaterials);
        }

        //
        // GET: /StockMaterials/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StockMaterials/Create

        [HttpPost]
        public ActionResult Create(StockMaterials stockmaterials)
        {
            if (ModelState.IsValid)
            {
                db.StockMaterials.Add(stockmaterials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockmaterials);
        }

        //
        // GET: /StockMaterials/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StockMaterials stockmaterials = db.StockMaterials.Find(id);
            if (stockmaterials == null)
            {
                return HttpNotFound();
            }
            return View(stockmaterials);
        }

        //
        // POST: /StockMaterials/Edit/5

        [HttpPost]
        public ActionResult Edit(StockMaterials stockmaterials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockmaterials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockmaterials);
        }

        //
        // GET: /StockMaterials/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StockMaterials stockmaterials = db.StockMaterials.Find(id);
            if (stockmaterials == null)
            {
                return HttpNotFound();
            }
            return View(stockmaterials);
        }

        //
        // POST: /StockMaterials/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StockMaterials stockmaterials = db.StockMaterials.Find(id);
            db.StockMaterials.Remove(stockmaterials);
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