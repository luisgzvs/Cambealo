using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cambealo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
                name: "ProductoMostrar",
                url: "usuario/{nombre}/productos/{id}",
                defaults: new { controller = "Productos", action = "Show" }
            );

            routes.MapRoute(
                name: "ProductoEditar",
                url: "usuario/{nombre}/productos/editar/{id}",
                defaults: new { controller = "Productos", action = "Edit" }
            );

            routes.MapRoute(
                name: "Productos",
                url: "usuario/{nombre}/productos",
                defaults: new { controller = "Productos", action = "Index" }
            );

            routes.MapRoute(
                name: "ProductoCrear",
                url: "productos/crear",
                defaults: new { controller = "Productos", action = "Create" }
            );

            routes.MapRoute(
                name: "Salir",
                url: "salir",
                defaults: new { controller = "Session", action = "Delete" }
            );

            routes.MapRoute(
                name: "Ingresar",
                url: "ingresar",
                defaults: new { controller = "Session", action = "Create" }
            );

            routes.MapRoute(
                name: "Registrar",
                url: "registrar",
                defaults: new { controller = "Usuarios", action = "Create" }
            );

            routes.MapRoute(
                name: "Menu",
                url: "usuario/{nombre}",
                defaults: new { controller = "Usuarios", action = "Show" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           routes.MapRoute(
            name: "searchaction",
            url: "Productos/Search/{searchTerm}",
           defaults: new { controller = "Productos", action = "Search" }
           );
        }
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
