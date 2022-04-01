using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SegundoExamen
{
	public class Alumno: Usuario
	{
		public Alumno(string id, string nombre, string apellido,
			string carrera, string nacimiento, string ciudad, string contrasena) :
			base(id, nombre, apellido, carrera, nacimiento, ciudad, contrasena)
		{

		}

		public string ConsultarCalificaciones()
        {
			string calificaciones = "";

			foreach (var materia in DatabaseConnection.calificaciones_por_materia)
            {
				calificaciones += DatabaseConnection.materiasIIA[materia.Key].nombre + ": " + materia.Value[id] + "\n";
            }
			return calificaciones;
        }

		private float CalcularPromedio()
		{
			float total = 0.0f;
			foreach (var materia in DatabaseConnection.calificaciones_por_materia)
			{
				total += materia.Value[id];
			}

			return total / 5;
		}

		public override void ConsultarInformacion()
        {
			Console.WriteLine(this.id + " | " + this.nombre + " " + this.apellido + "\n" + "Carrera: " + carrera + "\n" + nacimiento + " | " + ciudad);
			Console.WriteLine(this.ConsultarCalificaciones());
			Console.WriteLine("Promedio: " + this.CalcularPromedio().ToString());

		}

		public void DescargarCalificaciones()
		{
			string formato = ".docx";

			if (formato == ".txt")
			{
				File.WriteAllTextAsync("Calificaciones.txt", this.ConsultarCalificaciones());
			}
			else if (formato == ".docx")
            {
				using (var document = WordprocessingDocument.Create(
				"Calificaciones.docx", WordprocessingDocumentType.Document))
				{
					document.AddMainDocumentPart();
					document.MainDocumentPart.Document = new Document(
						new Body(new Paragraph(new Run(new Text(this.ConsultarCalificaciones())))));
				}
			}
			Console.WriteLine("Calificaciones descargadas exitosamente en formato " + formato);
			return;
		}

		public static async Task ExampleAsync()
		{
			string text =
				"A class is the most powerful data type in C#. Like a structure, " +
				"a class defines the data and behavior of the data type. ";

			await File.WriteAllTextAsync("WriteText.txt", text);
		}

		public string ObtenerNombreCompleto()
        {
			return this.nombre + " " + this.apellido;
        }

	}
}

