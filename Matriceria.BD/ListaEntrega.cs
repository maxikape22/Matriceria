using Matriceria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class ListaEntrega : DatosConexionBD
    {
        public int abmEntrega(string accion, Entrega objEntrega)
        {
            int resultado = -1;
            string orden = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            if (accion == "Alta")
            {
                orden = @"INSERT INTO Entregas (id_entrega, id_orden, codigo_entrega, fecha_entrega, horario_entrega, estado_entrega, medio_de_pago, entregado)
                  VALUES (@IdEntrega, @IdOrden, @CodigoEntrega, @FechaEntrega, @HorarioEntrega, @EstadoEntrega, @MedioDePago, @Entregado)";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@IdEntrega", objEntrega.IdEntrega);
                cmd.Parameters.AddWithValue("@IdOrden", objEntrega.IdOrden);
                cmd.Parameters.AddWithValue("@CodigoEntrega", objEntrega.CodigoEntrega);
                cmd.Parameters.AddWithValue("@FechaEntrega", objEntrega.FechaEntrega);
                cmd.Parameters.AddWithValue("@HorarioEntrega", objEntrega.HorarioEntrega);
                cmd.Parameters.AddWithValue("@EstadoEntrega", objEntrega.EstadoEntrega);
                cmd.Parameters.AddWithValue("@MedioDePago", objEntrega.MedioDePago);
                cmd.Parameters.AddWithValue("@Entregado", objEntrega.Entregado);
            }

            if (accion == "Modificar")
            {
                orden = @"UPDATE Entregas
                  SET id_orden = @IdOrden,
                      codigo_entrega = @CodigoEntrega,
                      fecha_entrega = @FechaEntrega,
                      horario_entrega = @HorarioEntrega,
                      estado_entrega = @EstadoEntrega,
                      medio_de_pago = @MedioDePago,
                      entregado = @Entregado
                  WHERE id_entrega = @IdEntrega";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@IdEntrega", objEntrega.IdEntrega);
                cmd.Parameters.AddWithValue("@IdOrden", objEntrega.IdOrden);
                cmd.Parameters.AddWithValue("@CodigoEntrega", objEntrega.CodigoEntrega);
                cmd.Parameters.AddWithValue("@FechaEntrega", objEntrega.FechaEntrega);
                cmd.Parameters.AddWithValue("@HorarioEntrega", objEntrega.HorarioEntrega);
                cmd.Parameters.AddWithValue("@EstadoEntrega", objEntrega.EstadoEntrega);
                cmd.Parameters.AddWithValue("@MedioDePago", objEntrega.MedioDePago);
                cmd.Parameters.AddWithValue("@Entregado", objEntrega.Entregado);
            }

            // Si se requiere una acción de eliminación, agregar el código correspondiente aquí

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar, modificar o eliminar {objEntrega}", e);
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
            // Consulta SQL adaptada para unir Entregas con Ordenes y Clientes
            string orden = @"
        SELECT e.id_entrega, e.codigo_entrega, e.fecha_entrega, e.horario_entrega, e.estado_entrega, e.medio_de_pago, e.entregado,
               o.codigo AS codigo_orden, 
               c.razon_social AS razon_social_cliente
        FROM Entregas AS e
        INNER JOIN Ordenes AS o ON e.id_orden = o.id_orden
        INNER JOIN Clientes AS c ON o.id_cliente = c.id_cliente";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener los detalles de las entregas", e);
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

            string ordenEjecucion = @"
        SELECT id_entrega, id_orden, codigo_entrega, fecha_entrega, horario_entrega, estado_entrega, medio_de_pago, entregado
        FROM Entregas";

            SqlCommand cmd = new SqlCommand(ordenEjecucion, conexion);
            SqlDataReader dataReader;

            try
            {
                Abrirconexion();

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Entrega entrega = new Entrega
                    {
                        IdEntrega = dataReader.GetGuid(0),
                        IdOrden = dataReader.GetGuid(1),
                        CodigoEntrega = dataReader.GetString(2),
                        FechaEntrega = dataReader.GetDateTime(3),
                        HorarioEntrega = dataReader.IsDBNull(4) ? null : dataReader.GetString(4),
                        EstadoEntrega = dataReader.GetString(5),
                        MedioDePago = dataReader.GetString(6),
                        Entregado = dataReader.GetBoolean(7)
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

        public DataSet ListarEntregasBuscar(string cual)
        {
            string orden = @"
        SELECT e.id_entrega, e.id_orden, e.codigo_entrega, e.fecha_entrega, e.horario_entrega, e.estado_entrega, e.medio_de_pago, e.entregado, o.codigo AS codigo_orden, c.razon_social AS nombre_cliente
        FROM Entregas AS e
        INNER JOIN Ordenes AS o ON e.id_orden = o.id_orden
        INNER JOIN Clientes AS c ON o.id_cliente = c.id_cliente
        WHERE e.id_entrega LIKE '%' + @Cual + '%' 
           OR e.codigo_entrega LIKE '%' + @Cual + '%'
           OR e.fecha_entrega LIKE '%' + @Cual + '%'
           OR e.horario_entrega LIKE '%' + @Cual + '%'
           OR e.estado_entrega LIKE '%' + @Cual + '%'
           OR e.medio_de_pago LIKE '%' + @Cual + '%'
           OR e.entregado LIKE '%' + @Cual + '%'
           OR o.codigo LIKE '%' + @Cual + '%'
           OR c.razon_social LIKE '%' + @Cual + '%';
    ";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@Cual", cual);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar las entregas", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return ds;
        }


        public DataSet ListarEntregasEliminar(string id)
{
    string orden = $"DELETE FROM Entregas WHERE id_entrega = @IdEntrega";

    SqlCommand cmd = new SqlCommand(orden, conexion);
    cmd.Parameters.AddWithValue("@IdEntrega", id);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();

    try
    {
        Abrirconexion();
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds); // Opcional, normalmente se usa solo para consultas SELECT, aquí puede no ser necesario
    }
    catch (Exception e)
    {
        throw new Exception("Error al eliminar la entrega", e);
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
