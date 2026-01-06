using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colegio_v3.Models;

namespace Colegio_v3.Controllers
{
    public class AcudienteController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        [HttpGet]

        // GET: Acudiente
        public ActionResult Index()
        {
            return View(db.Acudiente.ToList());
        }


        [HttpGet]
        //Agregar o create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Acudiente acudiente)
        {
            //insert into Estudiantes
            db.Acudiente.Add(acudiente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //select * from Estudiante 
            Acudiente acudiente = db.Acudiente.Find(id);
            if (acudiente != null)
            {
                return View(acudiente);
            }
            else
            {
                ViewBag.Error = "Estudiante no encontrado";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Acudiente acudiente)
        {
            db.Entry(acudiente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Acudiente acudiente = db.Acudiente.Find(id);
            return View(acudiente);
        }

        //Delete

        public ActionResult Delete(int? id)
        {
            Acudiente acudiente = db.Acudiente.Find(id);
            return View(acudiente);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            Acudiente acudiente = db.Acudiente.Find(id);
            if (acudiente != null)
            {
                db.Acudiente.Remove(acudiente);
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