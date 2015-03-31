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
    public class StockProductsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /StockProducts/

        public ActionResult Index()
        {
            return View(db.StocProduse.ToList());
        }

        //
        // GET: /StockProducts/Details/5

        public ActionResult Details(int id = 0)
        {
            StockProducts stockproducts = db.StocProduse.Find(id);
            if (stockproducts == null)
            {
                return HttpNotFound();
            }
            return View(stockproducts);
        }

        //
        // GET: /StockProducts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StockProducts/Create

        [HttpPost]
        public ActionResult Create(StockProducts stockproducts)
        {
            if (ModelState.IsValid)
            {
                db.StocProduse.Add(stockproducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockproducts);
        }

        //
        // GET: /StockProducts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StockProducts stockproducts = db.StocProduse.Find(id);
            if (stockproducts == null)
            {
                return HttpNotFound();
            }
            return View(stockproducts);
        }

        //
        // POST: /StockProducts/Edit/5

        [HttpPost]
        public ActionResult Edit(StockProducts stockproducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockproducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockproducts);
        }

        //
        // GET: /StockProducts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StockProducts stockproducts = db.StocProduse.Find(id);
            if (stockproducts == null)
            {
                return HttpNotFound();
            }
            return View(stockproducts);
        }

        //
        // POST: /StockProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StockProducts stockproducts = db.StocProduse.Find(id);
            db.StocProduse.Remove(stockproducts);
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