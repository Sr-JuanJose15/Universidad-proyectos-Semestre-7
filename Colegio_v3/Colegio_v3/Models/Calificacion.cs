using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class Calificacion
    {
        [Key]
        public int CalificacionId { get; set; }

        [Required]
        [Range(0, 5)]
        public double Nota { get; set; }

        [Required]
        [StringLength(20)]
        public string Periodo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        // Relaciones

        [ForeignKey("Estudiante")]
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }

        [ForeignKey("Asignatura")]
        public int AsignaturaId { get; set; }
        public virtual Asignatura Asignatura { get; set; }
    }
}