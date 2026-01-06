using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class Asignatura
    {
        [Key]
        public int AsignaturaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        // Relaciones

        // Calificaciones relacionadas a esta asignatura
        public virtual ICollection<Calificacion> Calificaciones { get; set; }

        // Cursos en los que se dicta esta asignatura (relación N:N)
        public virtual ICollection<Curso> Cursos { get; set; }

        // Docentes que dictan esta asignatura (relación N:N con Personal)
        public virtual ICollection<Personal> Docentes { get; set; }
    }
}