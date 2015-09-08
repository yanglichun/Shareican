using System.Web.Mvc;

namespace MyWeb.Areas.SicAdmin
{
    public class SicAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SicAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SicAdmin_default",
                "SicAdmin/{controller}/{action}/{id}",
                new {controller="SicAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
