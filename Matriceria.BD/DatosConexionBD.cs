using System;
using System.Data;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class DatosConexionBD
    {
        protected SqlConnection conexion;
        protected string cadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TallerArmmecor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DatosConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public void Abrirconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State ==
               ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
        }


        public void Cerrarconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }
    }
}