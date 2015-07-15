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
                var productos = db.Productoes.Where(p => p.IdUsuario != usuarioId);
                return View(productos.ToList());
            } else {
                return View(db.Productoes.ToList());
            }
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