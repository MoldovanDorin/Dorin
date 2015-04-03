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
    public class AmountOfMaterialController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /AmountOfMaterial/

        public ActionResult Index()
        {
            var amountofmaterials = db.AmountOfMaterials.Include(a => a.rawMaterials).Include(a => a.stockMaterials);
            return View(amountofmaterials.ToList());
        }

        //
        // GET: /AmountOfMaterial/Details/5

        public ActionResult Details(int id = 0)
        {
            AmountOfMaterial amountofmaterial = db.AmountOfMaterials.Find(id);
            if (amountofmaterial == null)
            {
                return HttpNotFound();
            }
            return View(amountofmaterial);
        }

        //
        // GET: /AmountOfMaterial/Create

        public ActionResult Create()
        {
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume");
            ViewBag.StockMaterialsId = new SelectList(db.StockMaterials, "Id", "Id");
            return View();
        }

        //
        // POST: /AmountOfMaterial/Create

        [HttpPost]
        public ActionResult Create(AmountOfMaterial amountofmaterial)
        {
            if (ModelState.IsValid)
            {
                db.AmountOfMaterials.Add(amountofmaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume", amountofmaterial.RawMaterialsId);
            ViewBag.StockMaterialsId = new SelectList(db.StockMaterials, "Id", "Id", amountofmaterial.StockMaterialsId);
            return View(amountofmaterial);
        }

        //
        // GET: /AmountOfMaterial/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AmountOfMaterial amountofmaterial = db.AmountOfMaterials.Find(id);
            if (amountofmaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume", amountofmaterial.RawMaterialsId);
            ViewBag.StockMaterialsId = new SelectList(db.StockMaterials, "Id", "Id", amountofmaterial.StockMaterialsId);
            return View(amountofmaterial);
        }

        //
        // POST: /AmountOfMaterial/Edit/5

        [HttpPost]
        public ActionResult Edit(AmountOfMaterial amountofmaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amountofmaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RawMaterialsId = new SelectList(db.RawMaterials, "Id", "Nume", amountofmaterial.RawMaterialsId);
            ViewBag.StockMaterialsId = new SelectList(db.StockMaterials, "Id", "Id", amountofmaterial.StockMaterialsId);
            return View(amountofmaterial);
        }

        //
        // GET: /AmountOfMaterial/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AmountOfMaterial amountofmaterial = db.AmountOfMaterials.Find(id);
            if (amountofmaterial == null)
            {
                return HttpNotFound();
            }
            return View(amountofmaterial);
        }

        //
        // POST: /AmountOfMaterial/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AmountOfMaterial amountofmaterial = db.AmountOfMaterials.Find(id);
            db.AmountOfMaterials.Remove(amountofmaterial);
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