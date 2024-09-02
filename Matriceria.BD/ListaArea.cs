using Matriceria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class ListaArea : DatosConexionBD
    {
        // Método para insertar un área

        public int InsertarArea(Area objArea)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_InsertarArea", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Asignar los valores de los parámetros del procedimiento almacenado
            cmd.Parameters.AddWithValue("@nombre_area", objArea.Nombre_area);
            cmd.Parameters.AddWithValue("@tiempo", objArea.Tiempo);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al intentar insertar el área con nombre {objArea.Nombre_area}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }




    }
}
