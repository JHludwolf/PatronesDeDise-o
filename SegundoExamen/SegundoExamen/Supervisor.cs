using System;
namespace SegundoExamen
{
	public class Supervisor: Usuario
	{
		public Supervisor(string id, string nombre, string apellido,
			string carrera, string nacimiento, string ciudad, string contrasena) :
			base(id, nombre, apellido, carrera, nacimiento, ciudad, contrasena)
		{
		}

		public override void ConsultarInformacion()
		{
			Console.WriteLine(this.id + " | " + this.nombre + " " + this.apellido + "\n" + nacimiento + " | " + ciudad);
		}
	}
}

