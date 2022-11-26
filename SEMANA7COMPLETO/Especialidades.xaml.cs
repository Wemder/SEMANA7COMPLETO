using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SEMANA7COMPLETO.modelos;
using System.Collections.ObjectModel;


namespace SEMANA7COMPLETO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Especialidades : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Especialidad> _TablaEspecialidad;
        public Especialidades()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var ResultRegistros = await _conn.Table<Especialidad>().ToListAsync();
            _TablaEspecialidad = new ObservableCollection<Especialidad>(ResultRegistros);
            ListaEspecialidades.ItemsSource = _TablaEspecialidad;
            base.OnAppearing();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Especialidad)e.SelectedItem;
            var item = Obj.idEspecialidad.ToString();
            var especialidad = Obj.especialidad;
            var descripcion = Obj.descripcion;
           
            int ID = Convert.ToInt32(item);
            try
            {
               // Navigation.PushAsync(new Elementos(ID, especialidad, descripcion));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}