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

                cmd.Parameters.AddWithValue("@codigoEntrega", codigoEntrega);

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

        public DataSet Union()
        {
            // Nombre del procedimiento almacenado
            string procedimiento = "sp_ObtenerEntregasConOrdenYCliente";

            // Crear el comando para el procedimiento almacenado
            SqlCommand cmd = new SqlCommand(procedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Configurar el DataSet y SqlDataAdapter
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();

                // Establecer el comando para el SqlDataAdapter
                da.SelectCommand = cmd;

                // Llenar el DataSet con los resultados del procedimiento almacenado
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener las entregas con la información de órdenes y clientes", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return ds;
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
                    Entrega entrega = new Entrega
                    {
                        CodigoEntrega = dataReader.GetString(0),             // Código de Entrega
                        FechaEntrega = dataReader.GetDateTime(1),            // Fecha de Entrega
                        HorarioEntrega = dataReader.GetString(2),            // Horario de Entrega
                        EstadoEntrega = dataReader.GetString(3),             // Estado de Entrega
                        MedioDePago = dataReader.GetString(4),               // Medio de Pago
                        Entregado = dataReader.GetString(5),                 // Entregado
                        //CodigoOrden = dataReader.GetString(6),               // Código de Orden
                        //RazonSocial = dataReader.GetString(7)                // Razón Social del Cliente
                    };

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



    }
}