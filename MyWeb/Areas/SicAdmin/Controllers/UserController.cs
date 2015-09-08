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
    public class UserController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/User/

        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Article);
            var d = db.Users.Include(s => s.Gender);
            return View(users.ToList());
        }

        //
        // GET: /SicAdmin/User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /SicAdmin/User/Create

        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "id", "Title");
            return View();
        }

        //
        // POST: /SicAdmin/User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "id", "Title", user.ArticleID);
            return View(user);
        }

        //
        // GET: /SicAdmin/User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "id", "Title", user.ArticleID);
            return View(user);
        }

        //
        // POST: /SicAdmin/User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "id", "Title", user.ArticleID);
            return View(user);
        }

        //
        // GET: /SicAdmin/User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /SicAdmin/User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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