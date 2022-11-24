using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEMANA7COMPLETO.modelos
{
    public class Especialidad
    {
        [PrimaryKey, AutoIncrement]
        public int idEspecialidad { get; set; }
        
        [MaxLength(50)]
        public string especialidad { get; set; }
        
        [MaxLength(50)]
        public string descripcion { get; set; }

        [OneToMany]
        public List<CitaMedica> citaMedica { get; set; }
    }
}
