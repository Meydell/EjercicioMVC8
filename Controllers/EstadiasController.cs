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
    public class EstadiasController : Controller
    {
        private EjercicioMVC8BDContainer db = new EjercicioMVC8BDContainer();

        // GET: Estadias
        [Authorize]
        public ActionResult Index()
        {
            var estadias = db.Estadias.Include(e => e.Paciente).Include(e => e.Unidad);
            return View(estadias.ToList());
        }

        // GET: Estadias/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadia estadia = db.Estadias.Find(id);
            if (estadia == null)
            {
                return HttpNotFound();
            }
            return View(estadia);
        }

        // GET: Estadias/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Pacientes");
            ViewBag.UnidadId = new SelectList(db.Unidades, "Id", "Unidades");
            return View();
        }

        // POST: Estadias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Entrada,Salida,Cita,PacienteId,UnidadId")] Estadia estadia)
        {
            if (ModelState.IsValid)
            {
                db.Estadias.Add(estadia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Paciente", estadia.PacienteId);
            ViewBag.UnidadId = new SelectList(db.Unidades, "Id", "Unidad", estadia.UnidadId);
            return View(estadia);
        }

        // GET: Estadias/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadia estadia = db.Estadias.Find(id);
            if (estadia == null)
            {
                return HttpNotFound();
            }
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Paciente", estadia.PacienteId);
            ViewBag.UnidadId = new SelectList(db.Unidades, "Id", "Unidad", estadia.UnidadId);
            return View(estadia);
        }

        // POST: Estadias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Entrada,Salida,Cita,PacienteId,UnidadId")] Estadia estadia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Paciente", estadia.PacienteId);
            ViewBag.UnidadId = new SelectList(db.Unidades, "Id", "Unidad", estadia.UnidadId);
            return View(estadia);
        }

        // GET: Estadias/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadia estadia = db.Estadias.Find(id);
            if (estadia == null)
            {
                return HttpNotFound();
            }
            return View(estadia);
        }

        // POST: Estadias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadia estadia = db.Estadias.Find(id);
            db.Estadias.Remove(estadia);
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
