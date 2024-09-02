using Matriceria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Matriceria.BD
{
    public class ListaEntrega : DatosConexionBD
    {

        public int InsertarEntrega(string accion, Entrega objEntrega)
        {
            int resultado = -1;
            string procedimiento = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;


            objEntrega.FechaEntrega = SqlDateTime.MinValue.Value;
            objEntrega.FechaEntrega = SqlDateTime.MaxValue.Value;

            try
            {
                Abrirconexion();

                if (accion == "Alta")
                {
                    procedimiento = "sp_InsertarEntrega";
                    cmd.CommandText = procedimiento;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo_entrega", objEntrega.CodigoEntrega);
                    cmd.Parameters.AddWithValue("@fecha_entrega", objEntrega.FechaEntrega);
                    cmd.Parameters.AddWithValue("@horario_entrega", objEntrega.HorarioEntrega);
                    cmd.Parameters.AddWithValue("@estado_entrega", objEntrega.EstadoEntrega);
                    cmd.Parameters.AddWithValue("@medio_de_pago", objEntrega.MedioDePago);
                    cmd.Parameters.AddWithValue("@entregado", objEntrega.Entregado);
                }

                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar, borrar o modificar la orden {e.Message}", e);
                //throw new Exception(e.InnerException.Message);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public int EliminarEntrega(string codigoEntrega)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            try
            {
                Abrirconexion();

                string procedimiento = "sp_EliminarEntrega"; // Nombre del procedimiento almacenado para eliminar una entrega
                cmd.CommandText = procedimiento;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo_entrega", codigoEntrega);

                resultado = cmd.ExecuteNonQuery(); // Ejecuta el procedimiento almacenado y devuelve el número de filas afectadas
            }
            catch (SqlException e)
            {
                throw new Exception($"Error al tratar de eliminar la entrega con código: {codigoEntrega}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }


        public List<Entrega> ObtenerEntregas()
        {
            List<Entrega> lista = new List<Entrega>();
            SqlCommand cmd = new SqlCommand("sp_ListarEntregas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader;

            try
            {
                Abrirconexion();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Entrega entrega = new Entrega();

                    entrega.CodigoEntrega = dataReader.GetString(0);             // Campo de Entrega
                    entrega.FechaEntrega = dataReader.GetDateTime(1);            // Fecha de Entrega
                    entrega.HorarioEntrega = dataReader.GetString(2);            // Horario de Entrega
                    entrega.EstadoEntrega = dataReader.GetString(3);             // Estado de Entrega
                    entrega.MedioDePago = dataReader.GetString(4);               // Medio de Pago
                    entrega.Entregado = dataReader.GetString(5);                // Entregado

                    lista.Add(entrega);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener la lista de entregas", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return lista;
        }

        public DataSet FiltrarEntregasPorCodigo(string codigoEntrega)
        {
            SqlCommand cmd = new SqlCommand("sp_FiltrarEntregas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Asignar el parámetro del procedimiento almacenado
            cmd.Parameters.AddWithValue("@codigo_entrega", codigoEntrega);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet(); // Crear un nuevo DataSet

            try
            {
                Abrirconexion(); // Abrir la conexión
                da.Fill(ds); // Llenar el DataSet con los resultados del procedimiento almacenado
            }
            catch (Exception e)
            {
                //throw new Exception("Error al filtrar las entregas por código", e);
                throw new Exception($"{e.InnerException.Message}");
            }
            finally
            {
                Cerrarconexion(); // Cerrar la conexión
                cmd.Dispose(); // Liberar recursos del comando
            }

            return ds; // Devolver el DataSet
        }



    }
}