using System;

namespace SegundoExamen
{
    class Program
    {
        static void Main(String[] args)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            dynamic usuariosJSON = databaseConnection.GetDataFromJSON("usuarios.json");
            databaseConnection.LoadUsuariosFromJSON(usuariosJSON);

            dynamic materiasJSON = databaseConnection.GetDataFromJSON("materias.json");
            databaseConnection.LoadMateriasFromJSON(materiasJSON);

            dynamic calificacionesJSON = databaseConnection.GetDataFromJSON("calificaciones.json");
            databaseConnection.LoadCalificacionesFromJSON(calificacionesJSON);

            Aplicacion.app.IniciarAplicacion();
        }
    }
}