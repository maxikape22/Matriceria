using Matriceria.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class ListaPieza : DatosConexionBD
    {
        public int InsertarPieza(string accion, Pieza ObjPieza)
        {
            int resultado = -1;
            string procedimiento = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            try
            {
                Abrirconexion();

                if (accion == "Alta")
                {
                    procedimiento = "sp_InsertarPieza";
                    cmd.CommandText = procedimiento;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", ObjPieza.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", ObjPieza.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", ObjPieza.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", ObjPieza.Precio);
                }

                resultado = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                //throw new Exception($"Error al tratar de guardar, borrar o modificar la orden {objOrden.Codigo}", e);
                throw new Exception(e.InnerException.Message);
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
