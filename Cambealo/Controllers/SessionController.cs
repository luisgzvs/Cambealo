using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cambealo.Models;

namespace Cambealo.Controllers
{
    public class SessionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Session/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Session/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (usuario.Correo == null && usuario.Contraseña == null)
            {
                TempData["message"] = "Se necesitan más datos";
                return RedirectToAction("Create");
            }
            
            var sql = (from u in db.Usuarios
                          where u.Correo == usuario.Correo
                          select new{
                              id = u.Id,
                              contraseña = u.Contraseña
                          }).ToList();

           if (sql.Count == 0 || sql[0].contraseña != usuario.Contraseña)
           {
                TempData["message"] = "Usuario o contraseña inválido";
                return RedirectToAction("Create");
           }
           Session["isLoggedIn"] = sql[0].id;
            return Redirect("/Usuarios/Details/" + sql[0].id);
        }

        public ActionResult Delete()
        {
            return Redirect("/");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
