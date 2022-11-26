using SEMANA7COMPLETO.modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7COMPLETO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MntCitaMedica : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private List<Especialidad> listEspecialidades;
        private Paciente pacienteActual;
        public MntCitaMedica()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            

           
        }

        protected async override void OnAppearing()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);

            var cedulaPaciente = Application.Current.Properties["usuarioLogeado"];
            Console.WriteLine("CEDULA_LOGIN*****"+cedulaPaciente);

            IEnumerable<Paciente> resultado = SELECT_WHERE_PACIENTE(db, cedulaPaciente.ToString());
            this.pacienteActual = resultado.First();
            lblNombrePaciente.Text = this.pacienteActual.getNameValue();
            var ResultRegistros = await _conn.Table<Especialidad>().ToListAsync();
            listEspecialidades = ResultRegistros;

             foreach (var especialidad in this.listEspecialidades) {
                pickerEspecialidad.Items.Add(especialidad.especialidad);
            }

            base.OnAppearing();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {

            var especialidadSelect =
                this.listEspecialidades.Find(value => value.especialidad.Equals(pickerEspecialidad.SelectedItem));

            var datosRegistro = new CitaMedica {
                paciente = this.pacienteActual,
                especialidad = especialidadSelect, 
                fechaHoraInicioConsulta = dateFechaInicio.Date,
                fechaHoraFinConsulta = dateFechaFin.Date,
                titulo = txtTitulo.Text,
                descipcion = txtDescripcion.Text,
                estado = "Activo",
                ubicacionConsultorio = txtDireccion.Text
            };
            _conn.InsertAsync(datosRegistro);
            DisplayAlert("Confirmación", "El paciente se registro correctamente", "OK");
        }

        public static IEnumerable<Paciente> SELECT_WHERE_PACIENTE(SQLiteConnection db, string cedula)
        {
            return db.Query<Paciente>("SELECT * FROM Paciente where cedula=?", cedula);
        }
    }
}