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
    public class AboutController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/About/

        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        //
        // GET: /SicAdmin/About/Details/5

        public ActionResult Details(int id = 0)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        //
        // GET: /SicAdmin/About/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SicAdmin/About/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                db.Abouts.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        //
        // GET: /SicAdmin/About/Edit/5

        public ActionResult Edit(int id = 0)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        //
        // POST: /SicAdmin/About/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        //
        // GET: /SicAdmin/About/Delete/5

        public ActionResult Delete(int id = 0)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        //
        // POST: /SicAdmin/About/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = db.Abouts.Find(id);
            db.Abouts.Remove(about);
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