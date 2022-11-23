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
    public partial class elemento : ContentPage
    {
        public int IdSeleccionado;
        public string NomSeleccionado, ApSeleccionado, TelSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<ConsultaRegistro> ResultadoDelete;
        IEnumerable<ConsultaRegistro> ResultadoUpdate;
        public elemento(int id ,string nom, string ap, string tel)
        {
            InitializeComponent();
            conexion = DependencyService.Get<Database>().GetConnection();
            NomSeleccionado = nom;
            ApSeleccionado = ap;
            TelSeleccionado = tel;
            btn_actualizar.Clicked += Btn_actualizar_Clicked;
            btn_eliminar.Clicked += Btn_eliminar_Clicked;
        }

        private void Btn_eliminar_Clicked(object sender, EventArgs e)
        {
          var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(rutaDB);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Confirmación", "El contacto se eliminó correctamente", "OK");
            Limpiar();
        }
        public static IEnumerable<ConsultaRegistro> Delete(SQLiteConnection db, int id)
        {
            return db.Query<ConsultaRegistro>("Delete FROM Estudiante WHERE Id = ?", id);
        }

        private void Btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutadb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(rutadb);
            ResultadoUpdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, IdSeleccionado);
            DisplayAlert("Confirmación", "El contacto se acualizó correctamente", "OK");
        }
        public static IEnumerable<ConsultaRegistro> Update(SQLiteConnection db, string nombre, string apellidos, string telefono, int id)
        {
            return db.Query<ConsultaRegistro>("UPDATE Estudiante SET Nombre = ?, usuario = ?, contrasena = ? WHERE Id =?", nombre, apellidos, telefono, id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtNombre.Text = NomSeleccionado;
            txtUsuario.Text = ApSeleccionado;
            txtContrasena.Text = TelSeleccionado;
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