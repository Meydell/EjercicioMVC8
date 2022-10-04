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
    public class AtencionesController : Controller
    {
        private EjercicioMVC8BDContainer db = new EjercicioMVC8BDContainer();

        // GET: Atenciones
        [Authorize]
        public ActionResult Index()
        {
            var atenciones = db.Atenciones.Include(a => a.Doctor).Include(a => a.Paciente);
            return View(atenciones.ToList());
        }

        // GET: Atenciones/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atencion atencion = db.Atenciones.Find(id);
            if (atencion == null)
            {
                return HttpNotFound();
            }
            return View(atencion);
        }

        // GET: Atenciones/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctores, nameof(Doctor.Id), nameof(Doctor.Nombres));
            ViewBag.PacienteId = new SelectList(db.Pacientes, nameof(Paciente.Id), nameof(Paciente.Nombres));
            return View();
        }

        // POST: Atenciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Fecha,Sintoma,Diagnostico,Medicamentos,DoctorId,PacienteId")] Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                db.Atenciones.Add(atencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Doctor", atencion.DoctorId);
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Paciente", atencion.PacienteId);
            return View(atencion);
        }

        // GET: Atenciones/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atencion atencion = db.Atenciones.Find(id);
            if (atencion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Nombres", atencion.DoctorId);
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nombres", atencion.PacienteId);
            return View(atencion);
        }

        // POST: Atenciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Sintoma,Diagnostico,Medicamentos,DoctorId,PacienteId")] Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctores, "Id", "Nombres", atencion.DoctorId);
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nombres", atencion.PacienteId);
            return View(atencion);
        }

        // GET: Atenciones/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atencion atencion = db.Atenciones.Find(id);
            if (atencion == null)
            {
                return HttpNotFound();
            }
            return View(atencion);
        }

        // POST: Atenciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Atencion atencion = db.Atenciones.Find(id);
            db.Atenciones.Remove(atencion);
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
