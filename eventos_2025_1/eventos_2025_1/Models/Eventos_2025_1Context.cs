using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eventos_2025_1.Models
{
    public class Eventos_2025_1Context : DbContext
    {
        //constructor
        public Eventos_2025_1Context()
            :base("DefaultConnection")
        {          
        }
        //atributos
        public DbSet<Municipio> Municipios { get; set; }

        public Dbset
    }
}