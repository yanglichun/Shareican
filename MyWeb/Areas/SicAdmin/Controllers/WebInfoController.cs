﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Areas.SicAdmin.Controllers
{
    public class WebInfoController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/WebInfo/

        public ActionResult Index()
        {
            return View(db.WebInfoes.ToList());
        }

        //
        // GET: /SicAdmin/WebInfo/Details/5

        public ActionResult Details(int id = 0)
        {
            WebInfo webinfo = db.WebInfoes.Find(id);
            if (webinfo == null)
            {
                return HttpNotFound();
            }
            return View(webinfo);
        }

        //
        // GET: /SicAdmin/WebInfo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SicAdmin/WebInfo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebInfo webinfo)
        {
            if (ModelState.IsValid)
            {
                db.WebInfoes.Add(webinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webinfo);
        }

        //
        // GET: /SicAdmin/WebInfo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WebInfo webinfo = db.WebInfoes.Find(id);
            if (webinfo == null)
            {
                return HttpNotFound();
            }
            return View(webinfo);
        }

        //
        // POST: /SicAdmin/WebInfo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WebInfo webinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webinfo);
        }

        //
        // GET: /SicAdmin/WebInfo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WebInfo webinfo = db.WebInfoes.Find(id);
            if (webinfo == null)
            {
                return HttpNotFound();
            }
            return View(webinfo);
        }

        //
        // POST: /SicAdmin/WebInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebInfo webinfo = db.WebInfoes.Find(id);
            db.WebInfoes.Remove(webinfo);
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