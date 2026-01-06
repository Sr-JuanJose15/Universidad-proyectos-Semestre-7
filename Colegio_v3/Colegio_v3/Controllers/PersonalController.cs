using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colegio_v3.Models;

namespace Colegio_v3.Controllers
{
    public class PersonalController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        [HttpGet]

        // GET: Estudiante
        public ActionResult Index()
        {
            return View(db.Personal.ToList());
        }


        [HttpGet]   
        //Agregar o create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Personal personal)
        {
            //insert into Estudiantes
            db.Personal.Add(personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //select * from Estudiante 
            Personal personal = db.Personal.Find(id);
            if (personal != null)
            {
                return View(personal);
            }
            else
            {
                ViewBag.Error = "Personal no encontrado";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Personal personal)
        {
            db.Entry(personal).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            Personal personal = db.Personal.Find(id);
            return View(personal);
        }

        //Delete

        public ActionResult Delete(int? id)
        {
            Personal personal = db.Personal.Find(id);
            return View(personal);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            Personal personal = db.Personal.Find(id);
            if (personal != null)
            {
                db.Personal.Remove(personal);
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