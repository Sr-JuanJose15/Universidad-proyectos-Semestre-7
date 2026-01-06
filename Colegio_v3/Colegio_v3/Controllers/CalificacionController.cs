using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Colegio_v3.Models;

namespace Colegio_v3.Controllers
{
    public class CalificacionController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        // GET: Calificacion
        public ActionResult Index()
        {
            var calificaciones = db.Calificacion
                .Include(c => c.Estudiante)
                .Include(c => c.Estudiante.Curso)
                .OrderBy(c => c.Estudiante.Curso.Grado) // ordenar por curso
                .ThenBy(c => c.Estudiante.Nombres)      // opcional: también ordenar por nombre del estudiante
                .ToList();

            return View(calificaciones);
        }

        // GET: Calificacion/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres");
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre");
            return View();
        }

        // POST: Calificacion/Create
        [HttpPost]
        public ActionResult Create(Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Calificacion.Add(calificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres", calificacion.EstudianteId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", calificacion.AsignaturaId);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            var calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                ViewBag.Error = "Calificación no encontrada";
                return View();
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres", calificacion.EstudianteId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", calificacion.AsignaturaId);
            return View(calificacion);
        }

        // POST: Calificacion/Edit
        [HttpPost]
        public ActionResult Edit(Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres", calificacion.EstudianteId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", calificacion.AsignaturaId);
            return View(calificacion);
        }

        // GET: Calificacion/Details/5
        public ActionResult Details(int? id)
        {
            var calificacion = db.Calificacion
                .Include(c => c.Estudiante)
                .Include(c => c.Asignatura)
                .FirstOrDefault(c => c.CalificacionId == id);

            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            var calificacion = db.Calificacion.Find(id);
            return View(calificacion);
        }

        // POST: Calificacion/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var calificacion = db.Calificacion.Find(id);
            if (calificacion != null)
            {
                db.Calificacion.Remove(calificacion);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
