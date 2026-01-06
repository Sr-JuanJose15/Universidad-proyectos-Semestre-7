using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class Colegio_v3Context : DbContext
    {
        public Colegio_v3Context() : base("DefaultConnection"){}

        //DBs

        public DbSet<Estudiante> Estudiante { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Personal> Personal { get; set; }

        public DbSet<Asignatura> Asignatura { get; set; }

        public DbSet<Calificacion> Calificacion { get; set; }

        public DbSet<Acudiente> Acudiente { get; set; }

        public DbSet<CursoAsignatura> CursoAsignatura { get; set; }

        public DbSet<AsignaturaPersonal> AsignaturaPersonal { get; set; }



    }
}       