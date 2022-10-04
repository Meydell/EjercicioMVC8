using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjercicioMVC8.Models;

namespace EjercicioMVC8.Controllers
{
    public class UnidadesController : Controller
    {
        private EjercicioMVC8BDContainer db = new EjercicioMVC8BDContainer();

        // GET: Unidades
        [AllowAnonymous]
        public ActionResult Index()
        {
            var unidades = db.Unidades.Include(u => u.Planta).Include(u => u.Doctor);
            return View(unidades.ToList());
        }

        // GET: Unidades/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidades.Find(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        // GET: Unidades/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PlantaId = new SelectList(db.Plantas, "Id", "Nombre");
            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Nombres");
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Nombre,Codigo,PlantaId,DoctorId")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                db.Unidades.Add(unidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantaId = new SelectList(db.Plantas, "Id", "Nombre", unidad.PlantaId);
            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Nombres", unidad.DoctorId);
            return View(unidad);
        }

        // GET: Unidades/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidades.Find(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantaId = new SelectList(db.Plantas, "Id", "Planta", unidad.PlantaId);
            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Doctor", unidad.DoctorId);
            return View(unidad);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Codigo,PlantaId,DoctorId")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantaId = new SelectList(db.Plantas, "Id", "Nombre", unidad.PlantaId);
            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Nombres", unidad.DoctorId);
            return View(unidad);
        }

        // GET: Unidades/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidades.Find(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidad unidad = db.Unidades.Find(id);
            db.Unidades.Remove(unidad);
            db.SaveChanges();
            return RedirectToAction("Index");
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
