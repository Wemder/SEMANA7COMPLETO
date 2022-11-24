using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEMANA7COMPLETO.modelos
{
    public class Paciente
    {
        [PrimaryKey, AutoIncrement]
        public int idPaciente { get; set; }

        [MaxLength(50)]
        public string primerNombre { get; set; }

        [MaxLength(50)]
        public string segundoNombre { get; set; }

        [MaxLength(50)]
        public string primerApellido { get; set; }

        [MaxLength(50)]
        public string segundoApellido { get; set; }

        [MaxLength(50)]
        public string email { get; set; }

        [MaxLength(50)]
        public string numeroContacto { get; set; }

        [MaxLength(50)]
        public string clave { get; set; }

        [MaxLength(10)]
        public string cedula { get; set; }

        [MaxLength(50)]
        public string genero { get; set; }

        public DateTime fechaNacimiento { get; set; }

        [OneToMany]
        public List<CitaMedica> citaMedica { get; set; } 
        
        public string getNameValue() {
            return this.primerNombre + this.primerApellido;
        }


    }
}
