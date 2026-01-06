using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio_v3.Models
{
    public class AsignaturaPersonal
    {
        [Key]
        public int AsignaturaPersonalId { get; set; }

        [ForeignKey("Asignatura")]
        public int AsignaturaId { get; set; }
        public virtual Asignatura Asignatura { get; set; }

        [ForeignKey("Personal")]
        public int PersonalId { get; set; }
        public virtual Personal Personal { get; set; }
    }
}