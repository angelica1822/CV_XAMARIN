using System;
using Xamarin.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

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
            var document = new Document();
            var section = document.AddSection();

            // Crear el grid
            var grid = section.AddTable();
            grid.Style = "Table";
            grid.Borders.Color = Colors.Black;

            // Definir las columnas del grid
            grid.AddColumn(Unit.FromCentimeter(5));
            grid.AddColumn(Unit.FromCentimeter(10));

            // Agregar filas y celdas al grid
            AddRow(grid, "Contacto", contacto);
            AddRow(grid, "Idiomas", idiomas);
            AddRow(grid, "Habilidades", habilidades);
            AddRow(grid, "Otros intereses", otrosIntereses);
            AddRow(grid, "Perfil", perfil);
            AddRow(grid, "Experiencia Laboral", experienciaLaboral);
            AddRow(grid, "Formación", formacion);

            // Guardar el documento en un archivo
            var filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CV.pdf");
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.Save(filePath);

            DisplayAlert("Guardado", "El CV se ha generado correctamente.", "OK");
        }

        private void AddRow(Table table, string labelText, string valueText)
        {
            var row = table.AddRow();
            row.Height = "1cm";

            var labelCell = row.Cells[0];
            labelCell.Format.Alignment = ParagraphAlignment.Left;
            labelCell.VerticalAlignment = VerticalAlignment.Center;
            labelCell.Shading.Color = Colors.LightGray;
            labelCell.AddParagraph(labelText);

            var valueCell = row.Cells[1];
            valueCell.Format.Alignment = ParagraphAlignment.Left;
            valueCell.VerticalAlignment = VerticalAlignment.Center;
            valueCell.AddParagraph(valueText);
        }
    }
}
