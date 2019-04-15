using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rezervasyon.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "KayitOl",
                url: "kayitol",
                defaults: new { controller = "Home", action = "KayitOl" }
            );

            routes.MapRoute(
                name: "GirisYap",
                url: "girisyap",
                defaults: new { controller = "Home", action = "GirisYap" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
