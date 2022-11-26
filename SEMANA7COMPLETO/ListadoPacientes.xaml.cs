using SEMANA7COMPLETO.modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7COMPLETO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoPacientes : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Paciente> _TablaPaciente;
        public ListadoPacientes()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var ResultRegistros = await _conn.Table<Paciente>().ToListAsync();
            
            _TablaPaciente = new ObservableCollection<Paciente>(ResultRegistros);
            
            ListaPacientes.ItemsSource = _TablaPaciente;
            base.OnAppearing();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Paciente)e.SelectedItem;
            

            //int ID = Convert.ToInt32(item);
            try
            {
                 Navigation.PushAsync(new EditPaciente(Obj));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}