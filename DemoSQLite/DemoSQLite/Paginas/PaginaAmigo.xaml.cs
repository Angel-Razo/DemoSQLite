using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DemoSQLite.Clases;

namespace DemoSQLite.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaAmigo : ContentPage
	{
        public string ID = "";
        public PaginaAmigo ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ID != "")
            {
                Amigo amigo = App.BD.ObtenerAmigo(ID);
                txtNombre.Text = amigo.Nombre;
                pckSexo.SelectedIndex = amigo.Sexo;
                dppCumple.Date = amigo.Cumple;
                txtCorreo.Text = amigo.Correo;
                txtTelefono.Text = amigo.Telefono;
                swtMejorAmigo.IsToggled = amigo.EsMejorAmigo;
            }
        }

        void BtnGuardar_Click(object sender, EventArgs a)
        {
            string nombre = txtNombre.Text;
            int sexo = pckSexo.SelectedIndex;
            DateTime cumple = dppCumple.Date;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            bool esMejorAmigo = swtMejorAmigo.IsToggled;

            App.BD.GuardarAmigo(ID, nombre, sexo, cumple, correo, telefono, esMejorAmigo);
            Navigation.PopAsync();

        }

        void BtnEliminar_Click(object sender, EventArgs a)
        {
            if (ID != "")
            {
                App.BD.EliminarAmigo(ID);
                Navigation.PopAsync();
            }

        }

    }
}