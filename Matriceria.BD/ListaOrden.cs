using Matriceria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Matriceria.BD
{
    public class ListaOrden : DatosConexionBD
    {
        public int InsertarOrden(string accion, Orden objOrden)
        {
            int resultado = -1;
            string procedimiento = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            objOrden.Fecha_inicio = SqlDateTime.MinValue.Value;
            objOrden.Fecha_prometido = SqlDateTime.MaxValue.Value;

            try
            {
                Abrirconexion();

                if (accion == "Alta")
                {
                    procedimiento = "sp_InsertarOrden";
                    cmd.CommandText = procedimiento;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", objOrden.Codigo);
                    cmd.Parameters.AddWithValue("@prioridad", objOrden.Prioridad);
                    cmd.Parameters.AddWithValue("@descripcion", objOrden.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", objOrden.Estado);
                    cmd.Parameters.AddWithValue("@fecha_inicio", objOrden.Fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_prometido", objOrden.Fecha_prometido);
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

        public int EliminarOrden(string codigo)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            try
            {
                Abrirconexion();

                string procedimiento = "sp_EliminarOrden";
                cmd.CommandText = procedimiento;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", codigo);

                resultado = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception($"Error al tratar de eliminar la orden de codigo:  {codigo}", e);
                //throw new Exception(e.InnerException.Message);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public int ModificarOrden(Orden objOrden)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            try
            {
                Abrirconexion();

                string procedimiento = "sp_ModificarOrden";
                cmd.CommandText = procedimiento;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_orden", objOrden.IdOrden);
                cmd.Parameters.AddWithValue("@codigo", objOrden.Codigo);
                cmd.Parameters.AddWithValue("@prioridad", objOrden.Prioridad);
                cmd.Parameters.AddWithValue("@descripcion", objOrden.Descripcion);
                cmd.Parameters.AddWithValue("@estado", objOrden.Estado);
                cmd.Parameters.AddWithValue("@fecha_inicio", objOrden.Fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_prometido", objOrden.Fecha_prometido);

                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de modificar la orden {objOrden.Codigo}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataTable FiltrarOrdenes(int idOrden)
        {
            string procedimiento = "sp_FiltrarOrdenes";
            SqlCommand cmd = new SqlCommand(procedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_orden", idOrden);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                Abrirconexion();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception($"Error al filtrar las órdenes con ID {idOrden}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return dt;
        }


        public DataSet FiltrarOrdenesPorCodigo(string codigo)
        {
            SqlCommand cmd = new SqlCommand("sp_FiltrarOrdenesPorCodigo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Asignar el parámetro del procedimiento almacenado
            cmd.Parameters.AddWithValue("@codigo", codigo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet(); // Crear un nuevo DataSet

            try
            {
                Abrirconexion(); // Abrir la conexión
                da.Fill(ds); // Llenar el DataSet con los resultados del procedimiento almacenado
            }
            catch (Exception e)
            {
                throw new Exception("Error al filtrar las órdenes por código", e);
            }
            finally
            {
                Cerrarconexion(); // Cerrar la conexión
                cmd.Dispose(); // Liberar recursos del comando
            }

            return ds; // Devolver el DataSet
        }

        public List<Orden> ObtenerOrdenes()
        {
            List<Orden> lista = new List<Orden>();
            SqlCommand cmd = new SqlCommand("sp_ListarOrdenes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader;

            try
            {
                Abrirconexion();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Orden orden = new Orden();

                    orden.IdOrden = dataReader.GetInt32(0);                
                    orden.Codigo = dataReader.GetString(1);               
                    orden.Prioridad = dataReader.GetString(2);         
                    orden.Descripcion = dataReader.GetString(3);         
                    orden.Estado = dataReader.GetString(4);               
                    orden.Fecha_inicio = dataReader.GetDateTime(5);      
                    orden.Fecha_prometido = dataReader.GetDateTime(6);   

                    lista.Add(orden);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener la lista de órdenes", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }
    }
}
