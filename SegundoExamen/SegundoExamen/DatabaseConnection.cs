using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SegundoExamen
{
	public class DatabaseConnection
	{
		public static Dictionary<string, Alumno> alumnos = new Dictionary<string, Alumno>();
		public static Dictionary<string, Docente> docentes = new Dictionary<string, Docente>();
		public static Dictionary<string, Supervisor> supervisores = new Dictionary<string, Supervisor>();

		public static Dictionary<string, Materia> materiasIIA = new Dictionary<string, Materia>();

		public static Dictionary<string, Dictionary<string, float>> calificaciones_por_materia = new Dictionary<string, Dictionary<string, float>>();

		Adapter JSON_adapter = new Adapter();

		public DatabaseConnection()
		{
		}

		public dynamic GetDataFromJSON(string fileName)
		{
			string jsonString = File.ReadAllText(fileName);

			dynamic data = JsonConvert.DeserializeObject(jsonString);

			return data;
		}

		public void LoadUsuariosFromJSON(dynamic usuarios)
        {
			// Convertr cada alumno en formato JSON a Alumno.cs

			foreach (var alumno in usuarios.alumnos)
            {
				Dictionary<string, string> usr = JSON_adapter.adapt_JSON_user(alumno);

				alumnos.Add(usr["id"], new Alumno(usr["id"], usr["nombre"], usr["apellido"],
					usr["carrera"], usr["nacimiento"], usr["ciudad"], usr["contrasena"]));

			}

			// Convertr cada docente en formato JSON a Docente.cs

			foreach (var docente in usuarios.docentes)
			{
				Dictionary<string, string> usr = JSON_adapter.adapt_JSON_user(docente);

				docentes.Add(usr["id"], new Docente(usr["id"], usr["nombre"], usr["apellido"],
					usr["carrera"], usr["nacimiento"], usr["ciudad"], usr["contrasena"]));

			}

			// Convertir cada supervisor en formato JSON a Supervisor.cs

			foreach (var supervisor in usuarios.supervisores)
			{
				Dictionary<string, string> usr = JSON_adapter.adapt_JSON_user(supervisor);

				supervisores.Add(usr["id"], new Supervisor(usr["id"], usr["nombre"], usr["apellido"],
					usr["carrera"], usr["nacimiento"], usr["ciudad"], usr["contrasena"]));

			}
		}

		public void LoadMateriasFromJSON(dynamic materias)
        {
			// Convertir materias en formato JSON a Materia.cs
			foreach (var materia in materias["IIA"])
            {
				Dictionary<string, string> mtr = JSON_adapter.adapt_JSON_materia(materia);

				materiasIIA.Add(mtr["id"], new Materia(mtr["id"], mtr["nombre"], mtr["id_docente"]));
			}
		}

		public void LoadCalificacionesFromJSON(dynamic calificaciones)
        {
			foreach (var materia in calificaciones)
            {
				Dictionary<string, float> calificaciones_de_materia = new Dictionary<string, float>();

				foreach (var calif_de_alumno in calificaciones[materia.Name])
                {
					Dictionary<string, string> stn = JSON_adapter.adapt_JSON_grade(calif_de_alumno);

					calificaciones_de_materia.Add(stn["id_alumno"], float.Parse(stn["calificacion"]));

				}
				calificaciones_por_materia.Add(materia.Name.ToString(), calificaciones_de_materia);
			}
		}
	}
}

