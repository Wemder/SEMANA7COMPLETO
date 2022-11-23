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
    public partial class Elementos : ContentPage
    {
        public int IdSeleccionado;
        public string NomSeleccionado, ApSeleccionado, TelSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<ConsultaRegistro> ResultadoDelete;
        IEnumerable<ConsultaRegistro> ResultadoUpdate;

        public Elementos(int id, string nom, string usua, string contra)
        {
            InitializeComponent();
            conexion = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = id;
            NomSeleccionado = nom;
            ApSeleccionado = usua;
            TelSeleccionado = contra;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensaje.Text = " ID :" + IdSeleccionado;
            txtNombre.Text = NomSeleccionado;
            txtUsuario.Text = ApSeleccionado;
            txtContrasena.Text = TelSeleccionado;
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(rutaDB);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Confirmación", "El contacto se eliminó correctamente", "OK");
            Limpiar();
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutadb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(rutadb);
            ResultadoUpdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, IdSeleccionado);
            DisplayAlert("Confirmación", "El contacto se acualizó correctamente", "OK");

        }
        public static IEnumerable<ConsultaRegistro> Delete(SQLiteConnection db, int id)
        {
            return db.Query<ConsultaRegistro>("Delete FROM Estudiante WHERE Id = ?", id);
        }
        public static IEnumerable<ConsultaRegistro> Update(SQLiteConnection db, string nombre, string usua, string contra, int id)
        {
            return db.Query<ConsultaRegistro>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, contrasena = ? WHERE Id =?", nombre, usua, contra, id);
        }
        public void Limpiar()
        {
            lblMensaje.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
        }
       
    }
}