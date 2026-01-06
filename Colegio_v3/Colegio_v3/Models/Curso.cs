using Colegio_v3.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Colegio_v3.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required]
        [StringLength(10)]
        public string Grado { get; set; }

        [Required]
        [StringLength(5)]
        public string Grupo { get; set; }

        [ForeignKey("DirectorGrupo")]
        public int DirectorGrupoId { get; set; }
        public virtual Personal DirectorGrupo { get; set; }

        [Required]
        public int AñoEscolar { get; set; }

        [Required]
        public int CapacidadMaxima { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Asignatura> Asignaturas { get; set; }

        // 🔹 Propiedad que se usará para mostrar el texto en el DropDownList
        [NotMapped]
        public string NombreCompleto
        {
            get { return $"{Grado} {Grupo} - {AñoEscolar}"; }
        }
    }
}