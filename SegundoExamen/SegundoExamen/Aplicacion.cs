using System;
namespace SegundoExamen
{
	public class Aplicacion
	{
		public static Aplicacion app = new Aplicacion();

		private Aplicacion()
		{
		}

		public void IniciarAplicacion()
        {
            while (true)
            {
                Console.WriteLine("Alumni API");

                this.Login();

                switch (UsuarioActivo.tipo_de_usuario)
                {
                    case "alumno":
                        this.PerfilAlumno();
                        break;

                    case "docente":
                        this.PerfilDocente();
                        break;

                    case "supervisor":
                        this.PerfilSupervisor();
                        break;

                    default:
                        break;
                }
            }
        }

        private void Login()
        {
            bool acceso;

            do
            {
                Console.Write("Usuario: ");
                string usuario = Console.ReadLine();

                Console.Write("Constraseña: ");
                string contrasena = Console.ReadLine();

                acceso = UsuarioActivo.usuarioActivo.TryAuthentication(usuario, contrasena);

                if (!acceso) Console.WriteLine("Acceso Denegado.");
            } while (!acceso);

            return;
        }

        private void PerfilAlumno()
        {
            Console.WriteLine("¡Bienvenid@ " + DatabaseConnection.alumnos[UsuarioActivo.id].nombre + "!");

            int input = -1;

            do
            {
                Console.WriteLine("1. Consultar Calificaciones");
                Console.WriteLine("2. Consultar Informacion de perfil");
                Console.WriteLine("3. Descargar Calificaciones");
                Console.WriteLine("0. Cerrar sesion");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    input = -1;
                }

                switch (input)
                {
                    case 1:
                        Console.WriteLine(DatabaseConnection.alumnos[UsuarioActivo.id].ConsultarCalificaciones());
                        break;
                    case 2:
                        DatabaseConnection.alumnos[UsuarioActivo.id].ConsultarInformacion();
                        break;
                    case 3:
                        DatabaseConnection.alumnos[UsuarioActivo.id].DescargarCalificaciones();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida.");
                        break;
                }

            } while (input != 0);

            Console.WriteLine("¡Adios " + DatabaseConnection.alumnos[UsuarioActivo.id].nombre + "!");
        }

        private void PerfilDocente()
        {
            Console.WriteLine("¡Bienvenid@ docente " + DatabaseConnection.docentes[UsuarioActivo.id].nombre + "!");

            int input = -1;

            do
            {
                Console.WriteLine("1. Consultar Calificaciones");
                Console.WriteLine("2. Consultar Informacion de perfil");
                Console.WriteLine("0. Cerrar sesion");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    input = -1;
                }

                switch (input)
                {
                    case 1:
                        DatabaseConnection.docentes[UsuarioActivo.id].ConsultarCalificaciones();
                        break;
                    case 2:
                        DatabaseConnection.docentes[UsuarioActivo.id].ConsultarInformacion();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida.");
                        break;
                }

            } while (input != 0);

            Console.WriteLine("¡Adios docente " + DatabaseConnection.docentes[UsuarioActivo.id].nombre + "!");
        }
        private void PerfilSupervisor()
        {
            Console.WriteLine("¡Bienvenid@ supervisor@ " + DatabaseConnection.supervisores[UsuarioActivo.id].nombre + "!");

            int input = -1;

            do
            {
                Console.WriteLine("1. Consultar Informacion de perfil");
                Console.WriteLine("0. Cerrar sesion");

                try
                {
                    input = int.Parse(Console.ReadLine());
                } catch (FormatException e)
                {
                    input = -1;
                }

                switch (input)
                {
                    case 1:
                        DatabaseConnection.supervisores[UsuarioActivo.id].ConsultarInformacion();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida.");
                        break;
                }

            } while (input != 0);

            Console.WriteLine("¡Adios supervisor@ " + DatabaseConnection.supervisores[UsuarioActivo.id].nombre + "!");
        }
    }
}

