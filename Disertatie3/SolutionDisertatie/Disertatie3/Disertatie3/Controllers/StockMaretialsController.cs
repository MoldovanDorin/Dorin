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
    public class StockMaretialsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /StockMaretials/

        public ActionResult Index()
        {
            return View(db.StockMaterials.ToList());
        }

        //
        // GET: /StockMaretials/Details/5

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
        // GET: /StockMaretials/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StockMaretials/Create

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
        // GET: /StockMaretials/Edit/5

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
        // POST: /StockMaretials/Edit/5

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
        // GET: /StockMaretials/Delete/5

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
        // POST: /StockMaretials/Delete/5

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