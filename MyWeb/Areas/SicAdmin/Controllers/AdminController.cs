using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Areas.SicAdmin.Controllers
{
    public class AdminController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/Admin/

        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        //
        // GET: /SicAdmin/Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /SicAdmin/Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SicAdmin/Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /SicAdmin/Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /SicAdmin/Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /SicAdmin/Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /SicAdmin/Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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