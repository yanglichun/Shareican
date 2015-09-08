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
    public class LinkController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/Link/

        public ActionResult Index()
        {
            return View(db.Links.ToList());
        }

        //
        // GET: /SicAdmin/Link/Details/5

        public ActionResult Details(int id = 0)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        //
        // GET: /SicAdmin/Link/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SicAdmin/Link/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Link link)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(link);
        }

        //
        // GET: /SicAdmin/Link/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        //
        // POST: /SicAdmin/Link/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Link link)
        {
            if (ModelState.IsValid)
            {
                db.Entry(link).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(link);
        }

        //
        // GET: /SicAdmin/Link/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        //
        // POST: /SicAdmin/Link/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Link link = db.Links.Find(id);
            db.Links.Remove(link);
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