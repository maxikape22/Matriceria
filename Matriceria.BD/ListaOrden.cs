using Matriceria.Entidades;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace Matriceria.BD
{
    public class ListaOrden : DatosConexionBD
    {
        public int abmOrden(string accion, Orden objOrden)
        {
            int resultado = -1;
            string orden = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            if (accion == "Alta")
            {
                orden = @"INSERT INTO Ordenes (id_orden, id_cliente, id_area, codigo, prioridad, descripcion, estado, fecha_inicio, fecha_prometido) 
                      VALUES (@IdOrden, @IdCliente, @IdArea, @Codigo, @Prioridad, @Descripcion, @Estado, @FechaInicio, @FechaPrometido)";

                cmd.CommandText = orden;
                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@IdOrden", objOrden.IdOrden);
                cmd.Parameters.AddWithValue("@IdCliente", objOrden.IdCliente);
                cmd.Parameters.AddWithValue("@IdArea", objOrden.IdArea);
                cmd.Parameters.AddWithValue("@Codigo", objOrden.Codigo);
                cmd.Parameters.AddWithValue("@Prioridad", objOrden.Prioridad);
                cmd.Parameters.AddWithValue("@Descripcion", objOrden.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", objOrden.Estado);
                cmd.Parameters.AddWithValue("@FechaInicio", objOrden.Fecha_inicio);
                cmd.Parameters.AddWithValue("@FechaPrometido", objOrden.Fecha_prometido);
            }

            if (accion == "Modificar")
            {
                orden = @"UPDATE Ordenes 
                      SET id_cliente = @IdCliente, 
                          id_area = @IdArea, 
                          codigo = @Codigo, 
                          prioridad = @Prioridad, 
                          descripcion = @Descripcion, 
                          estado = @Estado, 
                          fecha_inicio = @FechaInicio, 
                          fecha_prometido = @FechaPrometido 
                      WHERE id_orden = @IdOrden";

                cmd.CommandText = orden;
                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@IdOrden", objOrden.IdOrden);
                cmd.Parameters.AddWithValue("@IdCliente", objOrden.IdCliente);
                cmd.Parameters.AddWithValue("@IdArea", objOrden.IdArea);
                cmd.Parameters.AddWithValue("@Codigo", objOrden.Codigo);
                cmd.Parameters.AddWithValue("@Prioridad", objOrden.Prioridad);
                cmd.Parameters.AddWithValue("@Descripcion", objOrden.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", objOrden.Estado);
                cmd.Parameters.AddWithValue("@FechaInicio", objOrden.Fecha_inicio);
                cmd.Parameters.AddWithValue("@FechaPrometido", objOrden.Fecha_prometido);
            }

            if (accion == "Eliminar")
            {
                orden = @"DELETE FROM Ordenes WHERE id_orden = @IdOrden";

                cmd.CommandText = orden;
                cmd.Parameters.AddWithValue("@IdOrden", objOrden.IdOrden);
            }

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar, borrar o modificar la orden {objOrden.Codigo}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataTable ListarOrdenes()
        {
            string orden = "SELECT id_orden, id_cliente, id_area, codigo, prioridad, descripcion, estado, fecha_inicio, fecha_prometido FROM Ordenes";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                Abrirconexion();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar las órdenes", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return dt;
        }

        public DataTable FiltrarOrdenesPorCodigo(string codigo)
        {
            SqlCommand cmd = new SqlCommand("FiltrarOrdenesPorCodigo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Asignar el parámetro del código
            cmd.Parameters.AddWithValue("@Codigo", codigo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                Abrirconexion();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception("Error al filtrar las órdenes por código", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return dt;
        }

        public List<Orden> ObtenerOrdenes()
        {
            List<Orden> lista = new List<Orden>();

            string OrdenEjecucion = "SELECT id_orden, id_cliente, id_area, codigo, prioridad, descripcion, estado, fecha_inicio, fecha_prometido FROM Ordenes";

            SqlCommand cmd = new SqlCommand(OrdenEjecucion, conexion);
            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    // Aquí concatenamos código y prioridad similar a como lo hiciste con productos
                    string codigo = dataReader.GetString(3);
                    string prioridad = dataReader.GetString(4);
                    string codigoPrioridad = $"{codigo} - {prioridad}";

                    Orden orden = new Orden();

                    // Asignar valores a las propiedades de la clase Orden
                    orden.IdOrden = dataReader.GetGuid(0);
                    orden.IdCliente = dataReader.GetGuid(1);
                    orden.IdArea = dataReader.GetGuid(2);
                    orden.Codigo = codigoPrioridad;  // Asignar concatenación de código y prioridad
                    orden.Descripcion = dataReader.GetString(5);
                    orden.Estado = dataReader.GetString(6);
                    orden.Fecha_inicio = dataReader.GetDateTime(7);
                    orden.Fecha_prometido = dataReader.GetDateTime(8);

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

        public DataSet OrdenEliminar(string codigo)
        {
            string orden = $"DELETE FROM Ordenes WHERE id_orden = '{codigo}';";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery(); // Ejecuta la consulta DELETE
                da.SelectCommand = cmd;
                da.Fill(ds); // Llena el DataSet (aunque después de un DELETE, probablemente esté vacío)
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar la orden", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return ds;
        }

    }
}
