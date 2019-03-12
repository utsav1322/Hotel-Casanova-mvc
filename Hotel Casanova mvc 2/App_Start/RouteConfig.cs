using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hotel_Casanova_mvc_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Registration",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Registration", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

           routes.MapRoute(
           name: "Image",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Image", action = "Index", id = UrlParameter.Optional }
       );
        }
    }
}
