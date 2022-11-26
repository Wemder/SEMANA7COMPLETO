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
    public partial class ListadoCita : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<CitaMedica> _TablaCitaMedica;
        public ListadoCita()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);

            var cedulaPaciente = Application.Current.Properties["usuarioLogeado"];
            IEnumerable<Paciente> resultado = SELECT_WHERE_PACIENTE(db, cedulaPaciente.ToString());
           
            lblCitaMedica.Text = "Lista de citas paciente:"+ resultado.First().getNameValue();
            var ResultRegistros = await _conn.Table<CitaMedica>().ToListAsync();
            _TablaCitaMedica = new ObservableCollection<CitaMedica>(ResultRegistros);
            ListaCitas.ItemsSource = _TablaCitaMedica;
            base.OnAppearing();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (CitaMedica)e.SelectedItem;


            //int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new EditCita(Obj));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IEnumerable<Paciente> SELECT_WHERE_PACIENTE(SQLiteConnection db, string cedula)
        {
            return db.Query<Paciente>("SELECT * FROM Paciente where cedula=?", cedula);
        }
    }
}