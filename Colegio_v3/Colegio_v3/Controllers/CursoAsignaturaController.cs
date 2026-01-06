using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio_v3.Models;

namespace Colegio_v3.Controllers
{
    public class CursoAsignaturaController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        [HttpGet]

        // GET: CursoAsignatura
        public ActionResult Index()
        {
            return View(db.CursoAsignatura.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Curso.ToList(), "CursoId", "NombreCompleto");
            ViewBag.AsignaturaId = new SelectList(db.Asignatura.ToList(), "AsignaturaId", "Nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoAsignatura cursoAsignatura)
        {
            if (ModelState.IsValid)
            {
                // Validar si ya existe la asignación
                bool yaExiste = db.CursoAsignatura
                    .Any(ca => ca.CursoId == cursoAsignatura.CursoId && ca.AsignaturaId == cursoAsignatura.AsignaturaId);

                if (yaExiste)
                {
                    ModelState.AddModelError("", "Esta asignatura ya ha sido asignada a este curso.");

                    // Recargar dropdowns si es necesario
                    ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", cursoAsignatura.CursoId);
                    ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", cursoAsignatura.AsignaturaId);
                    return View(cursoAsignatura);
                }

                db.CursoAsignatura.Add(cursoAsignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Si hay errores, volver a cargar dropdowns
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", cursoAsignatura.CursoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", cursoAsignatura.AsignaturaId);
            return View(cursoAsignatura);
        }


        // Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CursoAsignatura cursoAsignatura = db.CursoAsignatura.Find(id);
            if (cursoAsignatura == null)
            {
                return HttpNotFound();
            }

            // Usamos NombreCompleto para mostrar correctamente los cursos
            ViewBag.CursoId = new SelectList(db.Curso.ToList(), "CursoId", "NombreCompleto", cursoAsignatura.CursoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura.ToList(), "AsignaturaId", "Nombre");

            return View(cursoAsignatura);
        }

        [HttpPost]
        public ActionResult Edit(CursoAsignatura cursoasignatura)
        {
            db.Entry(cursoasignatura).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            CursoAsignatura cursoasignatura = db.CursoAsignatura.Find(id);
            return View(cursoasignatura);
        }

        //Delete

        public ActionResult Delete(int? id)
        {
            CursoAsignatura cursoasignatura = db.CursoAsignatura.Find(id);
            return View(cursoasignatura);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            CursoAsignatura cursoasignatura = db.CursoAsignatura.Find(id);
            if (cursoasignatura != null)
            {
                db.CursoAsignatura.Remove(cursoasignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }






        //liberar conexion con base de datos
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