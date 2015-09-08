using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using MyWeb.Models;
using PagedList;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        public MyWeb.Models.ShareicanEntities1 db = new Models.ShareicanEntities1();
        // GET: /Home/

        public ActionResult Index(int page=1)
        {
            //title/keywords
            List<WebInfo> tit = db.WebInfoes.Where(id => id.id == 1).ToList();
            ViewData["tit"] = tit;
            List<ArticleType> articleType = db.ArticleTypes.OrderBy(at => at.id).ToList();
            ViewData["articleType"] = articleType;
            //头条
            List<Article> atc = db.Articles.Where(s => s.Sort == 1).ToList();
            ViewData["atc"] = atc;
            //短语
            List<Announcement> ann = db.Announcements.Where(a => a.Sort == 1).ToList();
            ViewData["ann"] = ann;


            //ViewData["funHtml"] = new MvcHtmlString("HTML代码");
            var model =db.Articles.OrderByDescending(s=>s.id).ToPagedList(page,8);
            return View(model);
        }
        public ActionResult Create(int page=1)
        {
            var model = db.Articles.OrderByDescending(s => s.id).ToPagedList(page, 8);
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Right()
        {
            return PartialView();
        }

        public ActionResult Link()
        {
            //Models.Link stu = db.Links.First();
            List<Models.DTO.LinkDTO> list = db.Links.OrderByDescending(s => s.id)
                .ToList().Select(s => s.ToDto()).ToList();
            Models.PagedDataModel<Models.DTO.LinkDTO> dataModel = new Models.PagedDataModel<Models.DTO.LinkDTO>()
            {
                PagedData = list
            };
            Models.JsonModel jsonModel = new Models.JsonModel()
            {
                Data = dataModel,
                Msg = "成功~",
                Statu = "ok",
                BackUrl = ""
            };
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        } 

        public ActionResult List()
        {

            //1.EF的查询方法，实际创建的是 某个实体类的代理类，代理类 继承于 该 实体类。
            //Models.Article stu = db.Articles.First();
            //2.1根据页码 获取分页数据(使用DTO学员实体类 内部不存在循环属性 --  关于使用DTO类的时候注意，类名不要和EF实体类一样)
            List<Models.DTO.ArticleDTO> list = db.Articles.OrderByDescending(a =>Guid.NewGuid()).Take(3)
                //将EF查出的 EF实体集合 转成 DTO实体集合，并返回
                .ToList().Select(s => s.ToDto()).ToList();
            //2.4将数据 封装到 PagedDataModel 分页数据实体中
            Models.PagedDataModel<Models.DTO.ArticleDTO> dataModel = new Models.PagedDataModel<Models.DTO.ArticleDTO>()
            {
                PagedData = list
            };
            Models.JsonModel jsonModel = new Models.JsonModel()
            {
                Data = dataModel,
                Msg = "成功~",
                Statu = "ok",
                BackUrl = ""
            };
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        } 
       
    }
}
