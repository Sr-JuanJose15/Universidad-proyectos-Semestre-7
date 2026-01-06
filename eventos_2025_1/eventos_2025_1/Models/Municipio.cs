using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eventos_2025_1.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(30,MinimumLength =4, 
            ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Nombre { get;set; }

        //crear relacion con torneo 

        public virtual ICollection<torneos>
    }
}