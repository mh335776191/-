using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Duanzu.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "Duanzu.Controller.Controllers" }
            );

            //发布短租路由
            routes.MapRoute(
                name: "ShortRentRoute", // 路由名称
                url: "{controller}/{action}", // 带有参数的 URL
                defaults: new { controller = "ShortRent", action = "ShortRent" }, // 参数默认值
                namespaces: new string[] { "Duanzu.Controller.Controllers" }
                );
        }
    }
}