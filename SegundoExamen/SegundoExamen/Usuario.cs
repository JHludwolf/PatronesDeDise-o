using System;

namespace SegundoExamen
{
	public abstract class Usuario
	{
		public string id;
		public string nombre;
		protected string apellido;
		protected string carrera;
		protected string nacimiento;
		protected string ciudad;
		protected string contrasena;

		public Usuario(string id, string nombre, string apellido,
			string carrera, string nacimiento, string ciudad, string contrasena)
		{
			this.id = id;
			this.nombre = nombre;
			this.apellido = apellido;
			this.carrera = carrera;
			this.nacimiento = nacimiento;
			this.ciudad = ciudad;
			this.contrasena = contrasena;
		}

		public abstract void ConsultarInformacion();

		public string ConsultarContrasena()
		{
			return this.contrasena;
		}
	}
}

