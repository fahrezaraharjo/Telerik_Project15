using System;
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
            
            routes.MapRoute(
                name: "MenuItems",
                url: "MenuItems/{action}/{id}",
                defaults: new { controller = "MenuItems", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OrderItems",
                url: "OrderItems/{action}/{id}",
                defaults: new { controller = "OrderItems", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Orders",
                url: "Orders/{action}/{id}",
                defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Restaurants",
                url: "Restaurants/{action}/{id}",
                defaults: new { controller = "Restaurants", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
