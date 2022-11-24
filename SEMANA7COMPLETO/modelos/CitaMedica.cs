using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEMANA7COMPLETO.modelos
{
    public class CitaMedica
    {
        [PrimaryKey, AutoIncrement]
        public int idCita { get; set; }

        [ManyToOne]
        public Paciente paciente { get; set; }

        [ManyToOne]
        public Especialidad especialidad { get; set; }

        public DateTime fechaHoraInicioConsulta { get; set; }

        public DateTime fechaHoraFinConsulta { get; set; }

        [MaxLength(50)]
        public string titulo { get; set; }

        [MaxLength(200)]
        public string descipcion { get; set; }

        [MaxLength(50)]
        public string estado { get; set; }

        [MaxLength(50)]
        public string ubicacionConsultorio { get; set; }
    }
}
