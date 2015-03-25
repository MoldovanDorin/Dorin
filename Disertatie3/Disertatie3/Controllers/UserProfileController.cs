﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Disertatie3.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace Disertatie3.Controllers
{
    public class UserProfileController : Controller
    {
        private DbEntities db = new DbEntities();

        //
        // GET: /UserProfile/

        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        //
        // GET: /UserProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserProfile/Create

        [HttpPost]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        //
        // GET: /UserProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Edit/5

        [HttpPost]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Delete/5

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tmpuser = "";
            var ctx = new DbEntities();
            using (ctx)
            {
                var firstOrDefault = ctx.UserProfiles.FirstOrDefault(us => us.UserId == id);
                if (firstOrDefault != null)
                    tmpuser = firstOrDefault.UserName;
            }

            string[] allRoles = Roles.GetRolesForUser(tmpuser);
            Roles.RemoveUserFromRoles(tmpuser, allRoles);

            //Roles.RemoveUserFromRole(tmpuser, "RoleName");

            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(tmpuser);
            Membership.Provider.DeleteUser(tmpuser, true);
            Membership.DeleteUser(tmpuser, true);

            ctx = new DbEntities();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}