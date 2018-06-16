using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DemoSQLite.Clases;

namespace DemoSQLite.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaListaAmigos : ContentPage
	{
		public PaginaListaAmigos ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            lsvAmigos.ItemsSource = App.BD.ObtenerAmigos();
        }

        private void LsvAmigos_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Amigo amigo = e.SelectedItem as Amigo;
                PaginaAmigo pagina = new PaginaAmigo
                {
                    ID = amigo.ID
                };
                Navigation.PushAsync(pagina);
            }
        }

        private void BtnNuevo_Click(EventArgs a, object sender)
        {
            Navigation.PushAsync(new PaginaAmigo());
        }


    }
}