using System;
using Xamarin.Forms;

namespace CVApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            var contacto = ((Entry)fieldsLayout.Children[1]).Text;
            var idiomas = ((Editor)fieldsLayout.Children[3]).Text;
            var habilidades = ((Editor)fieldsLayout.Children[5]).Text;
            var otrosIntereses = ((Editor)fieldsLayout.Children[7]).Text;
            var perfil = ((Editor)fieldsLayout.Children[9]).Text;
            var experienciaLaboral = ((Editor)fieldsLayout.Children[11]).Text;
            var formacion = ((Editor)fieldsLayout.Children[13]).Text;


            DisplayAlert("Guardado", "Los datos han sido guardados correctamente.", "OK");
        }
    }
}
