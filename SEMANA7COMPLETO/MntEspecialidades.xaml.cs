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
    public partial class MntEspecialidades : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public MntEspecialidades()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Especialidad { especialidad = txtEspecialidad.Text, descripcion = txtDescipcion.Text };
            _conn.InsertAsync(datosRegistro);
            limpiarFormulario();

        }

        private void limpiarFormulario() {
            txtDescipcion.Text = "";
            txtEspecialidad.Text = "";
        }
    }
}