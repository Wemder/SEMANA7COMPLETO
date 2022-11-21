using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMANA7COMPLETO.modelos;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7COMPLETO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regristro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Regristro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();  
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            var DatosRegristro = new Estudiante { Nombre = Nombre.Text, usuario = Usuario.Text, contrasena = Contrasenia.Text };
            _conn.InsertAsync(DatosRegristro);
            limpiarFormulario();

        }

         void limpiarFormulario()
        {
            Nombre.Text = "";
            Usuario.Text = "";
            Contrasenia.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "ok");

        }
    }
}