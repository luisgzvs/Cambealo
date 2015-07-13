using Cambealo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cambealo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var usuario = System.Web.HttpContext.Current.Session["usuarioActual"] as Dictionary<string, string>;
            if (usuario != null)
            {
                var usuarioId = Convert.ToInt32(usuario["id"]);
                var sql = (from p in db.Productos
                           where p.IdUsuario != usuarioId
                           select new
                           {
                               id = p.Id,
                               nombre = p.Nombre,
                               descripcion = p.Descripcion,
                               foto = p.Foto,
                               estado = p.Estado,
                               idUsuario = p.IdUsuario
                           }).ToList();
                ViewBag.productos = sql;
            }
            else
            {
                var sql = (from p in db.Productos
                           select new 
                           {
                               Id = p.Id,
                               Nombre = p.Nombre,
                               Descripcion = p.Descripcion,
                               Foto = p.Foto,
                               Estado = p.Estado,
                               IdUsuario = p.IdUsuario
                           }).ToList();
                ViewBag.productos = sql;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}