using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace OrdenesTrabajo
{
    public static class RouteConfig  //public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config) //(RouteCollection routes)
        {
            // Configuracion y servicios de API


            //RUtas de API Web

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            //este estaba originalmente
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "ActionApi", //Default
            //    url: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional} //new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
