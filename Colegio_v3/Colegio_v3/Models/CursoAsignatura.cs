using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class CursoAsignatura
    {
        [Key]
        public int CursoAsignaturaId { get; set; }

        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        [ForeignKey("Asignatura")]
        public int AsignaturaId { get; set; }
        public virtual Asignatura Asignatura { get; set; }
    }
}