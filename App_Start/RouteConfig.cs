using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnvanterYonetimi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //    routes.MapMvcAttributeRoutes();
        //    routes.MapRoute(
        //        name: "Login",
        //        url: "",
        //        defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
        //    );
        //    routes.MapRoute(
        //        name: "Main",
        //        url: "Main",
        //        defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
        //        );
        //    routes.MapRoute(
        //        name: "ArizaBildirimi",
        //        url: "ArizaBildirimi",
        //        defaults: new { controller = "ArizaBildirimi", action = "Index", id = UrlParameter.Optional }
        //        );
        //}
    }
}
