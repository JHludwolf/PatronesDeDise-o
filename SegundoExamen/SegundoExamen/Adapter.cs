using System;
namespace SegundoExamen
{
	public class Adapter
	{
		public Adapter()
		{
		}

		public Dictionary<string, string> adapt_JSON_user(dynamic usuario)
        {
			Dictionary<string, string> adaptee = new Dictionary<string, string>();

			adaptee.Add("id", usuario.id.ToString());
			adaptee.Add("nombre", usuario.nombre.ToString());
			adaptee.Add("apellido", usuario.apellido.ToString());
			adaptee.Add("carrera", usuario.carrera.ToString());
			adaptee.Add("nacimiento", usuario.nacimiento.ToString());
			adaptee.Add("ciudad", usuario.ciudad.ToString());
			adaptee.Add("contrasena", usuario.contrasena.ToString());

			return adaptee;

		}

		public Dictionary<string, string> adapt_JSON_materia(dynamic materia)
		{
			Dictionary<string, string> adaptee = new Dictionary<string, string>();

			adaptee.Add("id", materia.id_materia.ToString());
			adaptee.Add("nombre", materia.nombre_de_materia.ToString());
			adaptee.Add("id_docente", materia.docente.ToString());

			return adaptee;

		}

		public Dictionary<string, string> adapt_JSON_grade(dynamic calificacion)
        {
			Dictionary<string, string> adaptee = new Dictionary<string, string>();

			adaptee.Add("id_alumno", calificacion.id_alumno.ToString());
			adaptee.Add("calificacion", calificacion.calificacion.ToString());

			return adaptee;
        }
	}
}

