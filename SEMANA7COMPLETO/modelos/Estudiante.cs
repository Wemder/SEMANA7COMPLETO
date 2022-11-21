using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEMANA7COMPLETO.modelos
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]

        public string usuario { get; set; }
        [MaxLength(50)]

        public string contrasena { get; set; }
    }
}
