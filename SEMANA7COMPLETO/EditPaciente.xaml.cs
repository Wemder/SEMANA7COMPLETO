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
    public partial class EditPaciente : ContentPage
    {
        public Paciente pacienteVO;
        private SQLiteAsyncConnection conexion;
        IEnumerable<ConsultaRegistro> ResultadoDelete;
        IEnumerable<ConsultaRegistro> ResultadoUpdate;
        public EditPaciente(Paciente paciente)
        {
            InitializeComponent();
            conexion = DependencyService.Get<Database>().GetConnection();
            pacienteVO = paciente;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtPrimerNombre.Text = pacienteVO.primerNombre;
            txtSegundoNombre.Text = pacienteVO.segundoNombre;
            txtPrimerApellido.Text = pacienteVO.primerApellido;
            txtSegundoApellido.Text = pacienteVO.segundoApellido;
            txtCorreo.Text = pacienteVO.email;
            txtCelular.Text = pacienteVO.numeroContacto;
            txtClave.Text = pacienteVO.clave;
            txtIdentificacion.Text = pacienteVO.cedula;
            drpGenero.SelectedItem = pacienteVO.genero;
            dateFecha.Date = pacienteVO.fechaNacimiento;
            
        }


        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutadb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(rutadb);
            ResultadoUpdate = Update(db, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text,txtSegundoApellido.Text,txtClave.Text, pacienteVO.idPaciente);
            DisplayAlert("Confirmación", "El paciente se actualizó correctamente", "OK");

        }

        public static IEnumerable<ConsultaRegistro> Delete(SQLiteConnection db, int id)
        {
            return db.Query<ConsultaRegistro>("Delete FROM Estudiante WHERE Id = ?", id);
        }
        public static IEnumerable<ConsultaRegistro> Update(SQLiteConnection db, string primerNombre,string segundoNombre,string primerApellido,string segundoApellido,string clave, int id)
        {
            return db.Query<ConsultaRegistro>("UPDATE Paciente SET primerNombre = ?, segundoNombre = ?, primerApellido = ?,segundoApellido = ?,clave =? ,  WHERE idPaciente =?", primerNombre, segundoNombre, primerApellido, segundoApellido,clave,id);
        }
    }
}