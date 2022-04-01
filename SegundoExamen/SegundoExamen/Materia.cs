using System;
namespace SegundoExamen
{
	public class Materia
	{
		public string id;
		public string nombre;
		public string id_docente;

		public Materia(string id, string nombre, string id_docente)
		{
			this.id = id;
			this.nombre = nombre;
			this.id_docente = id_docente;
		}
	}
}

