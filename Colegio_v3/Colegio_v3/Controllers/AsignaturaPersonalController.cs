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
    public class AsignaturaPersonalController : Controller
    {
        private Colegio_v3Context db = new Colegio_v3Context();

        [HttpGet]

        // GET: AsignaturaPersonal
        public ActionResult Index()
        {
            return View(db.AsignaturaPersonal.ToList());
        }


        [HttpGet]
        //Agregar o create
        public ActionResult Create()
        {
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre");

            // También asegúrate de llenar cualquier otro DropDownList que uses, por ejemplo:
            ViewBag.PersonalId = new SelectList(
                db.Personal.ToList().Select(p => new {
                    PersonalId = p.PersonalId,
                    NombreCompleto = p.Nombres + " " + p.Apellidos
                }),
                "PersonalId",
                "NombreCompleto"
            );

            return View();
        }

        [HttpPost]

        public ActionResult Create(AsignaturaPersonal asignaturaPersonal)
        {
            //insert into Estudiantes
            db.AsignaturaPersonal.Add(asignaturaPersonal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AsignaturaPersonal asignaturaPersonal = db.AsignaturaPersonal.Find(id);
            if (asignaturaPersonal == null)
            {
                return HttpNotFound();
            }

            // 🔹 Llenar el DropDownList con la lista de asignaturas
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", asignaturaPersonal.AsignaturaId);

            // 🔹 Llenar el DropDownList con la lista de personal (profesores)
            ViewBag.PersonalId = new SelectList(
                db.Personal.ToList().Select(p => new {
                    PersonalId = p.PersonalId,
                    NombreCompleto = p.Nombres + " " + p.Apellidos
                }),
                "PersonalId",
                "NombreCompleto",
                asignaturaPersonal.PersonalId
            );

            return View(asignaturaPersonal);
        }

        [HttpPost]
        public ActionResult Edit(AsignaturaPersonal asignaturaPersonal)
        {
            db.Entry(asignaturaPersonal).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            AsignaturaPersonal asignaturaPersonal = db.AsignaturaPersonal.Find(id);
            return View(asignaturaPersonal);
        }

        //Delete

        public ActionResult Delete(int? id)
        {
            AsignaturaPersonal asignaturaPersonal = db.AsignaturaPersonal.Find(id);
            return View(asignaturaPersonal);
        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            AsignaturaPersonal asignaturaPersonal = db.AsignaturaPersonal.Find(id);
            if (asignaturaPersonal!= null)
            {
                db.AsignaturaPersonal.Remove(asignaturaPersonal);
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