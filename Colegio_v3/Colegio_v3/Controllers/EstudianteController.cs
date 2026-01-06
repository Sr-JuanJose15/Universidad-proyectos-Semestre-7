using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Colegio_v3.Models;
using System.Net;

namespace Colegio_v3.Controllers
{
    public class EstudianteController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        // GET: Estudiante
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Estudiante.ToList());
        }

        // GET: Estudiante/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AcudienteId = new SelectList(
                db.Acudiente
                  .ToList()
                  .Select(a => new {
                      a.AcudienteId,
                      NombreCompleto = a.Nombres + " " + a.Apellidos
                  }),
                "AcudienteId",
                "NombreCompleto"
            );

            ViewBag.CursoId = new SelectList(
                db.Curso.ToList().Select(c => new {
                    CursoId = c.CursoId,
                    NombreCompleto = c.NombreCompleto
                }),
                "CursoId",
                "NombreCompleto"
            );

            return View();
        }


        // POST: Estudiante/Create
// POST: Estudiante/Create
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(Estudiante estudiante)
{
    // Validación 1: Documento duplicado
    if (db.Estudiante.Any(e => e.Documento == estudiante.Documento))
    {
        ModelState.AddModelError("Documento", "Ya existe un estudiante con este número de documento.");
        ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", estudiante.CursoId);
        ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres", estudiante.AcudienteId);
        return View(estudiante);
    }

    if (ModelState.IsValid)
    {
        // Validación 2: Capacidad máxima del curso
        var curso = db.Curso.Include("Estudiantes").FirstOrDefault(c => c.CursoId == estudiante.CursoId);

        if (curso != null && curso.Estudiantes.Count >= curso.CapacidadMaxima)
        {
            ModelState.AddModelError("", "Este curso ya ha alcanzado su capacidad máxima.");
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", estudiante.CursoId);
            ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres", estudiante.AcudienteId);
            return View(estudiante);
        }

        db.Estudiante.Add(estudiante);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Si el modelo no es válido
    ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", estudiante.CursoId);
            ViewBag.AcudienteId = new SelectList(
                db.Acudiente
                    .ToList()
                    .Select(a => new {
                        a.AcudienteId,
                        NombreCompleto = a.Nombres + " " + a.Apellidos
                    }),
                "AcudienteId",
                "NombreCompleto",
                estudiante.AcudienteId
            ); return View(estudiante);
}


        // GET: Estudiante/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }

            // Carga lista de acudientes y cursos
            ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres", estudiante.AcudienteId);
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", estudiante.CursoId);

            return View(estudiante);
        }


        // POST: Estudiante/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudianteId,TipoDocumento,Documento,Nombres,Apellidos,FechaNacimiento,Genero,Direccion,Telefono,Correo,CursoId,AcudienteId")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Si algo falla, vuelve a cargar las listas
            ViewBag.AcudienteId = new SelectList(
                db.Acudiente
                    .ToList()
                    .Select(a => new {
                        a.AcudienteId,
                        NombreCompleto = a.Nombres + " " + a.Apellidos
                    }),
                "AcudienteId",
                "NombreCompleto",
                estudiante.AcudienteId
            );
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "Grado", estudiante.CursoId);

            return View(estudiante);
        }

        // GET: Estudiante/Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            return View(estudiante);
        }

        // GET: Estudiante/Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            return View(estudiante);
        }

        // POST: Estudiante/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante != null)
            {
                db.Estudiante.Remove(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // Liberar conexión con la base de datos
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
