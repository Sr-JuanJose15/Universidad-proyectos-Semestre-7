using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class Acudiente
    {
        [Key]
        public int AcudienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(30)]
        public string Parentesco { get; set; }

        [Required]
        [StringLength(20)]
        public string TelefonoPrincipal { get; set; }

        [StringLength(20)]
        public string TelefonoSecundario { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        // Relación: Un acudiente puede tener varios estudiantes a cargo
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}