using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using PagedList;

namespace MyWeb.Areas.SicAdmin.Controllers
{
    public class ArticleController : Controller
    {
        private ShareicanEntities1 db = new ShareicanEntities1();

        //
        // GET: /SicAdmin/Article/

        public ActionResult Index( int page=1)
        {
            var articles = db.Articles.OrderByDescending(a => a.id);
          var d=  articles.ToPagedList(page, 10);
            return View(d);
        }

        //
        // GET: /SicAdmin/Article/Details/5

        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /SicAdmin/Article/Create

        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.ArticleTypes, "id", "TypeName");
            return View();
        }
        //图片上传
         //[HttpPost]
        public void ImageUpLoad()
        {
            //定义错误消息
            string msg = "";
            //接受上传文件
            HttpPostedFileBase hp = Request.Files["upImage"];
            if (hp == null)
            {
                msg = "请选择文件.";
                //return Json(msg);
            }
            //获取上传目录 转换为物理路径
            string uploadPath = Server.MapPath("~/Areas/SicAdmin/Content/images/");
            //获取文件名
            string fileName = DateTime.Now.Ticks.ToString()+System.IO.Path.GetExtension(hp.FileName);
            //获取文件大小
            long contentLength = hp.ContentLength;
            //文件不能大于1M
            if (contentLength > 1024 * 1024)
            {
                msg = "文件大小超过限制要求.";
            }
            if (!checkFileExtension(fileName))
            {
                msg = "文件为不可上传的类型.";
            }
            //保存文件的物理路径
            string saveFile = uploadPath + fileName;
            try
            {
                //保存文件
                hp.SaveAs(saveFile);
                msg = "/Areas/SicAdmin/Content/images/" + fileName;
            }
            catch {
                msg = "上传失败.";
            }
            ViewBag.img = msg;
            
            string cm = HttpUtility.UrlEncode(msg,System.Text.Encoding.BigEndianUnicode);
            Areas.SicAdmin.Controllers.PageHelper.WriteJsMsg("放心，上传没问题", "/SicAdmin/Article/Create?img=" + cm);
            //Areas.SicAdmin.Controllers.AjaxMsgHelper.AjaxMsg("", "d", msg, "/SicAdmin/Article/Create");
            //return null;
        }
        /// <summary>
        /// 检查文件后缀名是否符合要求
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool checkFileExtension(string fileName)
        {
            //获取文件后缀
            string fileExtension = System.IO.Path.GetExtension(fileName);
            if (fileExtension != null)
                fileExtension = fileExtension.ToLower();
            else
                return false;

            if (fileExtension != ".jpg" && fileExtension != ".gif")
                return false;

            return true;
        }

        public void EditImageUpLoad(int id)
        {
            
            //定义错误消息
            string msg = "";
            //接受上传文件
            HttpPostedFileBase hp = Request.Files["upImage"];
            if (hp == null)
            {
                msg = "请选择文件.";
                //return Json(msg);
            }
            //获取上传目录 转换为物理路径
            string uploadPath = Server.MapPath("~/Areas/SicAdmin/Content/images/");
            //获取文件名
            string fileName = DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(hp.FileName);
            //获取文件大小
            long contentLength = hp.ContentLength;
            //文件不能大于1M
            if (contentLength > 1024 * 1024)
            {
                msg = "文件大小超过限制要求.";
            }
            if (!checkFileExtension(fileName))
            {
                msg = "文件为不可上传的类型.";
            }
            //保存文件的物理路径
            string saveFile = uploadPath + fileName;
            try
            {
                //保存文件
                hp.SaveAs(saveFile);
                msg = "/Areas/SicAdmin/Content/images/" + fileName;
            }
            catch
            {
                msg = "上传失败.";
            }
            ViewBag.img = msg;

            string cm = HttpUtility.UrlEncode(msg, System.Text.Encoding.BigEndianUnicode);
            Areas.SicAdmin.Controllers.PageHelper.WriteJsMsg("放心，上传没问题", "/SicAdmin/Article/Edit/"+id+"?img=" + cm);
            //Areas.SicAdmin.Controllers.AjaxMsgHelper.AjaxMsg("", "d", msg, "/SicAdmin/Article/Create");
            //return null;
        }


        //
        // POST: /SicAdmin/Article/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.ArticleTypes, "id", "TypeName", article.TypeID);
            return View(article);
        }

        //
        // GET: /SicAdmin/Article/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.id = id;
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.ArticleTypes, "id", "TypeName", article.TypeID);
            return View(article);
        }

        //
        // POST: /SicAdmin/Article/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Article article)
        {

            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.ArticleTypes, "id", "TypeName", article.TypeID);
            return View(article);
        }

        //
        // GET: /SicAdmin/Article/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /SicAdmin/Article/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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