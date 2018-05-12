using System.Web.Mvc;
using System.Web.Routing;

namespace AutoLookBackend
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "Login/",
                defaults: new { controller = "Login", action = "Authenticate" }
            );

            routes.MapRoute(
                name: "Car",
                url: "Car/",
                defaults: new { controller = "Car", action = "Index" }
            );

            routes.MapRoute(
                name: "Receive",
                url: "Receive/",
                defaults: new { controller = "Receive", action = "GetCars" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
