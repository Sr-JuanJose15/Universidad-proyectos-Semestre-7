using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoDocumento { get; set; }

        [Required]
        [StringLength(20)]
        public string Documento { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string Genero { get; set; }

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

        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        [ForeignKey("Acudiente")]
        public int AcudienteId { get; set; }
        public virtual Acudiente Acudiente { get; set; }

        // Lista de calificaciones (relación 1:N)
        public virtual ICollection<Calificacion> Calificaciones { get; set; }
    }
}