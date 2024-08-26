using Matriceria.Entidades;
using System;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class ListaCliente : DatosConexionBD
    {
        public int abmCliente(string accion, Cliente objCliente)
        {
            int resultado = -1;
            string orden = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            if (accion == "Alta")
            {
                orden = @"INSERT INTO Clientes (id_cliente, razon_social, cuit, telefono, domicilio) 
                      VALUES (@IdCliente, @RazonSocial, @CUIT, @Telefono, @Domicilio)";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@IdCliente", objCliente.IdCliente);
                cmd.Parameters.AddWithValue("@RazonSocial", objCliente.RazonSocial);
                cmd.Parameters.AddWithValue("@CUIT", objCliente.CUIT);
                cmd.Parameters.AddWithValue("@Telefono", objCliente.Telefono);
                cmd.Parameters.AddWithValue("@Domicilio", objCliente.Domicilio);
            }

            // if para la acción "Modificar" (descomentado y adaptado)
            if (accion == "Modificar")
            {
                orden = @"UPDATE Clientes 
                      SET razon_social = @RazonSocial, 
                          cuit = @CUIT, 
                          telefono = @Telefono, 
                          domicilio = @Domicilio 
                      WHERE id_cliente = @IdCliente";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@IdCliente", objCliente.IdCliente);
                cmd.Parameters.AddWithValue("@RazonSocial", objCliente.RazonSocial);
                cmd.Parameters.AddWithValue("@CUIT", objCliente.CUIT);
                cmd.Parameters.AddWithValue("@Telefono", objCliente.Telefono);
                cmd.Parameters.AddWithValue("@Domicilio", objCliente.Domicilio);
            }

            // Agregar otras acciones (e.g., "Baja") si es necesario...

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar, borrar o modificar {objCliente}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }
    }

    #region
    //public class ListaCliente : DatosConexionBD
    //{
    //    public int abmCaja(string accion, Cliente objCliente)
    //    {

    //        int resultado = -1;
    //        string orden = string.Empty;
    //        if (accion == "Alta")
    //            orden = $"insert into Clientes values ('{objCliente.Razon_Social}','{objCliente.CUIT}','{objCliente.Telefono}','{objCliente.Domicilio}')";

    //        //if (accion == "Modificar")
    //        //   orden = $"update Cliente set razon_social = '{objCliente.Razon_Social}' where id_cliente = {objCliente.IdCliente};  update Cliente set cuit = '{objCliente.CUIT}' where id_cliente = {objCliente.IdCliente}; update Cliente set telefono  = '{objCliente.Telefono}' where id_cliente = {objCliente.IdCliente}; update Cliente set domicilio = '{objCliente.Domicilio}' where id_cliente = {objCliente.IdCliente}; ";

    //        SqlCommand cmd = new SqlCommand(orden, conexion);
    //        try
    //        {
    //            Abrirconexion();
    //            resultado = cmd.ExecuteNonQuery();
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception($"Error al tratar de guardar, borrar o modificar {objCliente}", e);
    //        }
    //        finally
    //        {
    //            Cerrarconexion();
    //            cmd.Dispose();
    //        }
    //        return resultado;
    //    }
    //}
    #endregion
}