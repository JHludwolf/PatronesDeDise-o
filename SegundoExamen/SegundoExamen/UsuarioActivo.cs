using System;
namespace SegundoExamen
{
	public class UsuarioActivo
	{
		public static UsuarioActivo usuarioActivo = new UsuarioActivo();
		public static string id;
		public static string tipo_de_usuario;

		private UsuarioActivo()
		{

		}

		public bool TryAuthentication(string id, string intento_de_contrasena)
        {
			if (DatabaseConnection.alumnos.ContainsKey(id) && DatabaseConnection.alumnos[id].ConsultarContrasena() == intento_de_contrasena)
			{
				UsuarioActivo.id = id;
				UsuarioActivo.tipo_de_usuario = "alumno";

				return true;
			}
			else if (DatabaseConnection.docentes.ContainsKey(id) && DatabaseConnection.docentes[id].ConsultarContrasena() == intento_de_contrasena)
			{
				UsuarioActivo.id = id;
				UsuarioActivo.tipo_de_usuario = "docente";

				return true;
			}
			else if (DatabaseConnection.supervisores.ContainsKey(id) && DatabaseConnection.supervisores[id].ConsultarContrasena() == intento_de_contrasena)
			{
				UsuarioActivo.id = id;
				UsuarioActivo.tipo_de_usuario = "supervisor";

				return true;
			}
			

			return false;
        }
	}
}

