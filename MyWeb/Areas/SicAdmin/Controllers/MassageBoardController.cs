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
    public class MassageBoardController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/MassageBoard/

        public ActionResult Index()
        {
            return View(db.MassageBoards.ToList());
        }

        //
        // GET: /SicAdmin/MassageBoard/Details/5

        public ActionResult Details(int id = 0)
        {
            MassageBoard massageboard = db.MassageBoards.Find(id);
            if (massageboard == null)
            {
                return HttpNotFound();
            }
            return View(massageboard);
        }

        //
        // GET: /SicAdmin/MassageBoard/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SicAdmin/MassageBoard/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MassageBoard massageboard)
        {
            if (ModelState.IsValid)
            {
                db.MassageBoards.Add(massageboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(massageboard);
        }

        //
        // GET: /SicAdmin/MassageBoard/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MassageBoard massageboard = db.MassageBoards.Find(id);
            if (massageboard == null)
            {
                return HttpNotFound();
            }
            return View(massageboard);
        }

        //
        // POST: /SicAdmin/MassageBoard/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MassageBoard massageboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(massageboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(massageboard);
        }

        //
        // GET: /SicAdmin/MassageBoard/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MassageBoard massageboard = db.MassageBoards.Find(id);
            if (massageboard == null)
            {
                return HttpNotFound();
            }
            return View(massageboard);
        }

        //
        // POST: /SicAdmin/MassageBoard/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MassageBoard massageboard = db.MassageBoards.Find(id);
            db.MassageBoards.Remove(massageboard);
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