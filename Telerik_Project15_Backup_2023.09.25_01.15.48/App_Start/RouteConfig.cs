﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Telerik_Project15
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Dashboard",
                 url: "dashboard",
                 defaults: new { controller = "Dashboard", action = "Index" }
             );

            routes.MapRoute(
                name: "Customer",
                url: "Customer/{action}/{id}",
                defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
