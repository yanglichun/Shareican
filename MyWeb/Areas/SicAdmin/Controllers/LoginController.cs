using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Areas.SicAdmin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /SicAdmin/LoginManage/
        private ShareicanEntities1 db = new ShareicanEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public void Validate()
        {
            string admin = Request.Form["admin"];
            string pwd = Request.Form["password"];
            List<Admin> admin1 = db.Admins.Where(i => i.id!=0).ToList();
            foreach (var am in admin1)
            {
                if (admin == am.AdminName.ToString() && pwd == am.Password.ToString())
                {
                    Session["admin"] = am.AdminName;
                    Controllers.PageHelper.WriteJsMsg("(●—●)Listen，欢迎你回来", "/sicadmin");
                    Redirect("/sicadmin");
                    Response.Write("<script>alrer('我是弹出框');</script>");
                }
                else
                {
                    Response.Write("<script>alrer('我是弹出框');</script>");
                    Redirect("/sicadmin");
                    Controllers.PageHelper.WriteJsMsg("不认识你，滚粗","/Sicadmin/login");
                }
            }
            //return View();
        }
    }
}
