using SEMANA7COMPLETO.modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7COMPLETO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCita : ContentPage
    {
        public CitaMedica citaVO;
        private SQLiteAsyncConnection conexion;
        IEnumerable<ConsultaRegistro> ResultadoDelete;
        IEnumerable<ConsultaRegistro> ResultadoUpdate;
        public EditCita(CitaMedica cita)
        {
            InitializeComponent();
            conexion = DependencyService.Get<Database>().GetConnection();
            citaVO = cita;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //lblNombrePaciente.Text = citaVO.paciente.getNameValue();
            pickerEspecialidad.SelectedItem = citaVO.especialidad;
            dateFechaInicio.Date = citaVO.fechaHoraInicioConsulta;
            dateFechaFin.Date = citaVO.fechaHoraFinConsulta;
            txtTitulo.Text = citaVO.titulo;
            txtDescripcion.Text = citaVO.descipcion;
            txtDireccion.Text = citaVO.ubicacionConsultorio;

        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutadb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(rutadb);
            ResultadoUpdate = Update(db, dateFechaInicio.Date, dateFechaFin.Date, txtDescripcion.Text, txtDireccion.Text, citaVO.idCita);
            DisplayAlert("Confirmación", "La cita se actualizó correctamente", "OK");

        }

        public static IEnumerable<ConsultaRegistro> Update(SQLiteConnection db, DateTime fechaHoraInicioConsulta, DateTime fechaHoraFinConsulta, string descipcion, string ubicacionConsultorio, int id)
        {
            return db.Query<ConsultaRegistro>("UPDATE CitaMedica SET fechaHoraInicioConsulta = ?, fechaHoraFinConsulta = ?, descipcion = ?,ubicacionConsultorio =? ,  WHERE idCita =?", fechaHoraInicioConsulta, fechaHoraFinConsulta, descipcion, ubicacionConsultorio, id);
        }
    }
}