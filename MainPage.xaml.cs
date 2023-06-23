using System;
using Xamarin.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

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

            // Crear el documento PDF
            var document = new PdfDocument();
            var page = document.AddPage();

            using (var gfx = XGraphics.FromPdfPage(page))
            {
                // Agregar los datos al documento
                var font = new XFont("Arial", 12);
                var yPosition = 50;

                gfx.DrawString("Contacto:", font, XBrushes.Black, new XPoint(50, yPosition));
                gfx.DrawString(contacto, font, XBrushes.Black, new XPoint(150, yPosition));
                yPosition += 20;

                gfx.DrawString("Idiomas:", font, XBrushes.Black, new XPoint(50, yPosition));
                gfx.DrawString(idiomas, font, XBrushes.Black, new XPoint(150, yPosition));
                yPosition += 20;

                gfx.DrawString("Habilidades:", font, XBrushes.Black, new XPoint(50, yPosition));
                gfx.DrawString(habilidades, font, XBrushes.Black, new XPoint(150, yPosition));
                yPosition += 20;

                // Continuar agregando los demás campos del CV según tu diseño

                // Guardar el documento en un archivo
                var filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CV.pdf");
                document.Save(filePath);
            }

            DisplayAlert("Guardado", "El CV se ha generado correctamente.", "OK");
        }
    }
}
