using SEMANA7COMPLETO.modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7COMPLETO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MntPaciente : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public MntPaciente()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Paciente 
            { primerNombre = txtPrimerNombre.Text, 
                segundoNombre = txtSegundoNombre.Text ,
                primerApellido = txtPrimerApellido.Text,
                segundoApellido = txtSegundoApellido.Text,
                email = txtCorreo.Text,
                numeroContacto = txtCelular.Text,
                clave = txtClave.Text,
                cedula = txtIdentificacion.Text,
                genero = drpGenero.SelectedItem.ToString(),
                fechaNacimiento = dateFecha.Date,
                perfil = "P"
            };
            _conn.InsertAsync(datosRegistro);
            limpiarFormulario();
            DisplayAlert("Confirmación", "El paciente se registro correctamente", "OK");
        }

        private void limpiarFormulario()
        {
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
            txtClave.Text = "";
            txtClaveRepetida.Text = "";
            txtIdentificacion.Text = "";
        }
    }
}