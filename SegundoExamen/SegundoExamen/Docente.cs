using System;
namespace SegundoExamen
{
	public class Docente: Usuario
	{
		public Docente(string id, string nombre, string apellido,
			string carrera, string nacimiento, string ciudad, string contrasena) :
			base(id, nombre, apellido, carrera, nacimiento, ciudad, contrasena)
		{
		}

		public void ConsultarCalificaciones()
		{
			foreach (var materia in DatabaseConnection.materiasIIA)
            {
				if(materia.Value.id_docente == UsuarioActivo.id)
                {
					Console.WriteLine("Calificaciones de " + materia.Key + ": " + DatabaseConnection.materiasIIA[materia.Key].nombre);

					foreach (var alumno in DatabaseConnection.calificaciones_por_materia[materia.Key])
                    {
						Console.WriteLine(alumno.Key + " " + DatabaseConnection.alumnos[alumno.Key].ObtenerNombreCompleto() + " " + alumno.Value);
                    }
                }
            }
			return;
		}

        public override void ConsultarInformacion()
        {
			Console.WriteLine(this.id + " | " + this.nombre + " " + this.apellido + "\n" + nacimiento + " | " + ciudad);
		}
    }
}

