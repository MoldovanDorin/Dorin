using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisertatieModels.Model;
using DisertatieEntity;

namespace DisertatieModels.Controllers
{
    public class AmountOfProductsController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /AmountOfProducts/

        public ActionResult Index()
        {
            var amountofproducts = db.AmountOfProducts.Include(a => a.recipes).Include(a => a.stockProducts);
            return View(amountofproducts.ToList());
        }

        //
        // GET: /AmountOfProducts/Details/5

        public ActionResult Details(int id = 0)
        {
            AmountOfProducts amountofproducts = db.AmountOfProducts.Find(id);
            if (amountofproducts == null)
            {
                return HttpNotFound();
            }
            return View(amountofproducts);
        }

        //
        // GET: /AmountOfProducts/Create

        public ActionResult Create()
        {
            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume");
            ViewBag.StockProductsId = new SelectList(db.StocProduse, "Id", "Id");
            return View();
        }

        //
        // POST: /AmountOfProducts/Create

        [HttpPost]
        public ActionResult Create(AmountOfProducts amountofproducts)
        {
            if (ModelState.IsValid)
            {
                db.AmountOfProducts.Add(amountofproducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume", amountofproducts.RecipesId);
            ViewBag.StockProductsId = new SelectList(db.StocProduse, "Id", "Id", amountofproducts.StockProductsId);
            return View(amountofproducts);
        }

        //
        // GET: /AmountOfProducts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AmountOfProducts amountofproducts = db.AmountOfProducts.Find(id);
            if (amountofproducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume", amountofproducts.RecipesId);
            ViewBag.StockProductsId = new SelectList(db.StocProduse, "Id", "Id", amountofproducts.StockProductsId);
            return View(amountofproducts);
        }

        //
        // POST: /AmountOfProducts/Edit/5

        [HttpPost]
        public ActionResult Edit(AmountOfProducts amountofproducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amountofproducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipesId = new SelectList(db.Recipes, "Id", "Nume", amountofproducts.RecipesId);
            ViewBag.StockProductsId = new SelectList(db.StocProduse, "Id", "Id", amountofproducts.StockProductsId);
            return View(amountofproducts);
        }

        //
        // GET: /AmountOfProducts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AmountOfProducts amountofproducts = db.AmountOfProducts.Find(id);
            if (amountofproducts == null)
            {
                return HttpNotFound();
            }
            return View(amountofproducts);
        }

        //
        // POST: /AmountOfProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AmountOfProducts amountofproducts = db.AmountOfProducts.Find(id);
            db.AmountOfProducts.Remove(amountofproducts);
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