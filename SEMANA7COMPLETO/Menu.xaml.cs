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
    public partial class Menu : TabbedPage
    {
        private Paciente pacienteActual;
        public Menu(Paciente paciente)
        {
            InitializeComponent();
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);

            var cedulaPaciente = Application.Current.Properties["usuarioLogeado"];
            Console.WriteLine("CEDULA_LOGIN*****" + cedulaPaciente);

            IEnumerable<Paciente> resultado = SELECT_WHERE_PACIENTE(db, cedulaPaciente.ToString());
            this.pacienteActual = resultado.First();

            if (this.pacienteActual.perfil.Equals("P")) { 
                this.Children.Remove(mntPacientes);
                this.Children.Remove(especialidades);
                this.Children.Remove(mntEspecialidades);
                //this.Children.Remove(listadoPacientes);
            }
            
        }

        //protected async override void OnAppearing()
        //{
        //    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
       //     var db = new SQLiteConnection(databasePath);

        //    var cedulaPaciente = Application.Current.Properties["usuarioLogeado"];
      //      Console.WriteLine("CEDULA_LOGIN*****" + cedulaPaciente);

         //   IEnumerable<Paciente> resultado = SELECT_WHERE_PACIENTE(db, cedulaPaciente.ToString());
        //    this.pacienteActual = resultado.First();
       //     base.OnAppearing();
       // }

        public static IEnumerable<Paciente> SELECT_WHERE_PACIENTE(SQLiteConnection db, string cedula)
        {
            return db.Query<Paciente>("SELECT * FROM Paciente where cedula=?", cedula);
        }
    }
}