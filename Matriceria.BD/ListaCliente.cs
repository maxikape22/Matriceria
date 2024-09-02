using Matriceria.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class ListaCliente : DatosConexionBD
    {
        public int InsertarCliente(Cliente objCliente)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_InsertarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Asignar los valores de los parámetros del procedimiento almacenado
            cmd.Parameters.AddWithValue("@razon_social", objCliente.RazonSocial);
            cmd.Parameters.AddWithValue("@cuit", objCliente.CUIT);
            cmd.Parameters.AddWithValue("@telefono", objCliente.Telefono);
            cmd.Parameters.AddWithValue("@domicilio", objCliente.Domicilio);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al intentar insertar el cliente con razon social {objCliente.RazonSocial}", e);
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