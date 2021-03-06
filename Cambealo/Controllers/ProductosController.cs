﻿using System;
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
    public class ProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Productos/
        public ActionResult Index()
        {
            var usuario = System.Web.HttpContext.Current.Session["usuarioActual"] as Dictionary<string, string>;
            var usuarioId = Convert.ToInt32(usuario["id"]);
            var miProducto = db.Productoes.Where(p => p.IdUsuario == usuarioId);
            return View(miProducto.ToList());
        }

        // GET: /Productos/Details/5
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: /Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Foto,Fecha")] Producto producto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null && upload.ContentLength > 0)
            {
                var usuario = System.Web.HttpContext.Current.Session["usuarioActual"] as Dictionary<string, string>;
                producto.Foto = new byte[upload.ContentLength];
                upload.InputStream.Read(producto.Foto, 0, upload.ContentLength);
                producto.IdUsuario = Convert.ToInt32(usuario["id"]);
                producto.Fecha = DateTime.Today.ToString();
                producto.Estado = "activo";
                db.Productoes.Add(producto);
                db.SaveChanges();
                TempData["message"] = "Producto creado con éxito";
                TempData["created"] = true;
                return RedirectToAction("Create");
            }
               TempData["message"] = "El producto no pudo ser creado";
               TempData["created"] = false;
               return RedirectToAction("Create");
                
        }

            
        // GET: /Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: /Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Foto,Fecha")] Producto producto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null && upload.ContentLength > 0)
            {
                db.Entry(producto).State = EntityState.Modified;
                producto.Foto = new byte[upload.ContentLength];
                upload.InputStream.Read(producto.Foto, 0, upload.ContentLength);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: /Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search(string searchTerm = "")
        {
            return View("Index");
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
