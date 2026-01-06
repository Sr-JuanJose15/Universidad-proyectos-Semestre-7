using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]

        [NotMapped]
        public string NombreCompleto
        {
            get { return $"{Nombres} {Apellidos}"; }
        }
        public string Cargo { get; set; } // Ej: Docente, Coordinador, Rector, etc.

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        // Relaciones

        // Cursos en los que este personal es director de grupo
        public virtual ICollection<Curso> CursosComoDirector { get; set; }

        // Asignaturas que dicta este personal (relación N:N)
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
    }
}