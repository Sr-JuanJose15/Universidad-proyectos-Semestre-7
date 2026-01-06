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
    public class CursoController : Controller
    {

        private Colegio_v3Context db = new Colegio_v3Context();

        // GET: Curso
        [HttpGet]

        public ActionResult Index()
        {
            return View(db.Curso.ToList());
        }


        [HttpGet]
        //Agregar o create
        public ActionResult Create()
        {
            ViewBag.DirectorGrupoId = new SelectList(db.Personal.ToList(), "PersonalId", "Nombres");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorGrupoId = new SelectList(db.Personal, "Id", "NombreCompleto");
            return View(curso);
        }


        // Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }

            var personalList = db.Personal.ToList()
                .Select(p => new
                {
                    PersonalId = p.PersonalId,
                    NombreCompleto = p.Nombres + " " + p.Apellidos
                });

            ViewBag.DirectorGrupoId = new SelectList(personalList, "PersonalId", "NombreCompleto", curso.DirectorGrupoId);

            return View(curso);
        }



        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorGrupoId = new SelectList(db.Personal, "PersonalId", "NombreCompleto", curso.DirectorGrupoId);
            return View(curso);
        }


        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Curso curso = db.Curso.Find(id);
            return View(curso);
        }

        //Delete

        public ActionResult Delete(int? id)
        {
            Curso curso = db.Curso.Find(id);
            return View(curso);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            Curso curso = db.Curso.Find(id);
            if (curso != null)
            {
                db.Curso.Remove(curso);
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