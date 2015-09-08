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
    public class ArticleTypeController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/ArticleType/

        public ActionResult Index()
        {
            return View(db.ArticleTypes.ToList());
        }

        //
        // GET: /SicAdmin/ArticleType/Details/5

        public ActionResult Details(int id = 0)
        {
            ArticleType articletype = db.ArticleTypes.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        //
        // GET: /SicAdmin/ArticleType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SicAdmin/ArticleType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleType articletype)
        {
            if (ModelState.IsValid)
            {
                db.ArticleTypes.Add(articletype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articletype);
        }

        //
        // GET: /SicAdmin/ArticleType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ArticleType articletype = db.ArticleTypes.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        //
        // POST: /SicAdmin/ArticleType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleType articletype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articletype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articletype);
        }

        //
        // GET: /SicAdmin/ArticleType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ArticleType articletype = db.ArticleTypes.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        //
        // POST: /SicAdmin/ArticleType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleType articletype = db.ArticleTypes.Find(id);
            db.ArticleTypes.Remove(articletype);
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