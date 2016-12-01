using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VapingStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "ElectronicCigarettes", action = "List", page = 1}
                );

            routes.MapRoute(
                null,
                "Page{page}",
                new { controller = "ElectronicCigarettes", action = "List" , produser = (string)null},
                new { page = @"\d+"}
                );

            routes.MapRoute(
                null,
                "{produser}",
                new { controller = "ElectronicCigarettes", action = "List", page = 1 }
                );

            routes.MapRoute(
                null,
                "{produser}/Page{page}",
                new { controller = "ElectronicCigarettes", action = "List"},
                new { page = @"\d+" }
                );

            routes.MapRoute(
                null,
                "{controller}/{action}"
            );
        }
    }
}
