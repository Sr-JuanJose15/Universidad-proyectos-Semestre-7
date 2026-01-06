using eventos_2025_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace eventos_2025_1.Controllers
{
    public class MunicipiosController : Controller
    {
        //Crear un objeto de la clase contexto
        private Eventos_2025_1Context db = new Eventos_2025_1Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Municipios.ToList()); // select * from Municipios
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Municipio municipio) 
        { 
            //insert into Municipios(nombre) values(municipio.nombre) 
            db.Municipios.Add(municipio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //select * from Municipios where MunicipioId= id
            Municipio municipio = db.Municipios.Find(id);
            if (municipio != null)
            {
                return View(municipio);
            }
            else 
            {
                ViewBag.Error = "Municipio no encontrado";
                return View();
            }            
        }

        [HttpPost]
        public ActionResult Edit(Municipio municipio)
        {
            db.Entry(municipio).State= EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            //select * from Municipios where MunicipioId= id
            Municipio municipio = db.Municipios.Find(id);
            return View(municipio);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //select * from Municipios where MunicipioId= id
            Municipio municipio = db.Municipios.Find(id);
            return View(municipio);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio != null)
            {
                db.Municipios.Remove(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        //Liberar la conexión con la base de datos
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