using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colegio_v3.Models;

namespace Colegio_v3.Controllers
{
    public class AsignaturaController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        [HttpGet]

        // GET: Asignatura
        public ActionResult Index()
        {
            return View(db.Asignatura.ToList());
        }


        [HttpGet]
        //Agregar o create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(
                db.Curso.ToList().Select(c => new
                {
                    CursoId = c.CursoId,
                    NombreCompleto = c.NombreCompleto
                }),
                "CursoId",
                "NombreCompleto"
            );
            
            return View();
        }

        [HttpPost]

        public ActionResult Create(Asignatura asignatura)
        {
            //insert into asignatura
            db.Asignatura.Add(asignatura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //select * from Estudiante 
            Asignatura asignatura = db.Asignatura.Find(id);
            if (asignatura != null)
            {
                return View(asignatura);
            }
            else
            {
                ViewBag.Error = "Estudiante no encontrado";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Asignatura asignatura)
        {
            db.Entry(asignatura).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Asignatura asignatura = db.Asignatura.Find(id);
            return View(asignatura);
        }

        //Delete

        public ActionResult Delete(int? id)
        {
            Asignatura asignatura = db.Asignatura.Find(id);
            return View(asignatura);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            Asignatura asignatura = db.Asignatura.Find(id);
            if (asignatura != null)
            {
                db.Asignatura.Remove(asignatura);
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