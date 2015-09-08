using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using PagedList;
namespace MyWeb.Controllers
{
    public class ArticlesController : Controller
    {
        public MyWeb.Models.ShareicanEntities1 db = new Models.ShareicanEntities1();
        //
        // GET: /Article/

        public ActionResult Content(int id = 0)
        {
            List<WebInfo> tit = db.WebInfoes.Where(i => i.id == 1).ToList();
            ViewData["tit"] = tit;
            List<ArticleType> articleType = db.ArticleTypes.OrderBy(at => at.id).ToList();
            ViewData["articleType"] = articleType;
            //
            Article article = db.Articles.Find(id);
            var model = db.Articles;
            article.AgreeTimes += 1;
            return View(article);
        }

        public ActionResult Search(int page=1)
        {
            List<WebInfo> tit = db.WebInfoes.Where(i => i.id == 1).ToList();
            ViewData["tit"] = tit;
            List<ArticleType> articleType = db.ArticleTypes.OrderBy(at => at.id).ToList();
            ViewData["articleType"] = articleType;
            string ss = Request.QueryString["s"].ToString();
            var sc = db.Articles.Where(a => a.Title.Contains(ss)||a.ArticleContent.Contains(ss)).OrderByDescending(s => s.id).ToPagedList(page, 8);
            return View(sc);
        }

        public int times(int id) 
        {
            Article article = db.Articles.Find(id);
            //int a=Convert.ToInt32(article.ClickTimes);
            //a += 1;
            Article news = db.Articles.Where(x => x.id == id).FirstOrDefault();
            news.ClickTimes += 1;
          //new1 = new1 + 1;
            db.SaveChanges();
            //int t=0;
            //t += 1;
           //var d = db.Articles.Where(a => a.id==id);
            return Convert.ToInt32(news.ClickTimes);
;
        }

        public ActionResult Type(int id,int page=1)
        {

            List<WebInfo> tit = db.WebInfoes.Where(i => i.id == 1).ToList();
            ViewData["tit"] = tit;
            List<ArticleType> articleType = db.ArticleTypes.OrderBy(at => at.id).ToList();
            ViewData["articleType"] = articleType;
            var model = db.Articles.Where(a => a.TypeID == id).OrderByDescending(s => s.id).ToPagedList(page, 5);
            ViewBag.d = id;
            //var model = db.ArticleTypes;
            return View(model);
        }

        public ActionResult Top()
        {
           
            Models.Article stu = db.Articles.First();
            List<Models.DTO.ArticleDTO> list = db.Articles.OrderByDescending(s => s.ClickTimes).Take(8)
                .ToList().Select(s => s.ToDto()).ToList();
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


        public ActionResult List(int id)
        {
            int tpid= Convert.ToInt32(Request.QueryString["tpid"]);
            //int d =Convert.ToInt32( Request.QueryString["s"]);
            //1.EF的查询方法，实际创建的是 某个实体类的代理类，代理类 继承于 该 实体类。
            Models.Article stu = db.Articles.First();
            int pageIndex = id;
            int pageSize = 3;
            //2.1根据页码 获取分页数据(使用DTO学员实体类 内部不存在循环属性 --  关于使用DTO类的时候注意，类名不要和EF实体类一样)
            List<Models.DTO.ArticleDTO> list = db.Articles.Where(s=>s.TypeID==tpid).OrderByDescending(s=>s.id).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                //将EF查出的 EF实体集合 转成 DTO实体集合，并返回
                .ToList().Select(s => s.ToDto()).ToList();

            //2.2获取总行数
            int rowCount = db.Articles.Count();
            //2.3计算总页数
            int pageCount = Convert.ToInt32(Math.Ceiling((rowCount * 1.0) / pageSize));

            //2.4将数据 封装到 PagedDataModel 分页数据实体中
            Models.PagedDataModel<Models.DTO.ArticleDTO> dataModel = new Models.PagedDataModel<Models.DTO.ArticleDTO>()
            {
                PagedData = list,
                PageCount = pageCount,
                PageIndex = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount
            };

            //2.5将分页数据实体 封装到 Json标准格式实体中
            Models.JsonModel jsonModel = new Models.JsonModel()
            {
                Data = dataModel,
                Msg = "成功~",
                Statu = "ok",
                BackUrl = ""
            };
            //重要：JavaScriptSerializer 无法识别 被序列化的 对象里 各种属性是否存在 循环依赖
            //【所以，我们不能使用 jss 去序列化 EF实体对象A ！】
            //因为 jss 会 循环 EF实体对象A 里的每个属性，想要根据此属性 生成对应的Json字符串，但是，EF实体A 的外键(导航)属性如果被访问，则会自动去数据库获取数据，而这个导航属性 对应的实体类B 中可能又包含指向实体A的类型，那么，EF又会去加载 A的数据，然后A里有包含B........陷入死循环...........

            //System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string json = jsS.Serialize(jsonModel);

            //2.6生成 json格式数据，此Json方法默认只接收 Post请求，如果要接收 GEt请求，则需要加第二个参数
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        } 
    }
}
