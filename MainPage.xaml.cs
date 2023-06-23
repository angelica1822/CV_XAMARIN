using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CVApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Capturar los datos del formulario
            string contacto = contactoEntry.Text;
            string idiomas = idiomasEditor.Text;
            string habilidades = habilidadesEditor.Text;
            string otrosIntereses = interesesEditor.Text;
            string perfil = perfilEditor.Text;
            string experienciaLaboral = experienciaEditor.Text;
            string formacion = formacionEditor.Text;

            
            string cvContent = $"Contacto: {contacto}\n" +
                               $"Idiomas: {idiomas}\n" +
                               $"Habilidades: {habilidades}\n" +
                               $"Otros Intereses: {otrosIntereses}\n" +
                               $"Perfil: {perfil}\n" +
                               $"Experiencia Laboral: {experienciaLaboral}\n" +
                               $"Formación: {formacion}";

            
            string filePath = Path.Combine(FileSystem.CacheDirectory, "CV.txt");
            File.WriteAllText(filePath, cvContent);

         
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Curriculum Vitae",
                File = new ShareFile(filePath, "application/pdf")
            });
        }
    }
}
