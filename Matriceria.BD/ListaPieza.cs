using Matriceria.Entidades;
using System.Data.SqlClient;
using System;
using System.Data;

namespace Matriceria.BD
{
    public class ListaPieza : DatosConexionBD
    {
        #region
        //public int abmPieza(string accion, Pieza objPieza)
        //{
        //    int resultado = -1;
        //    string orden = string.Empty;
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conexion;

        //    if (accion == "Alta")
        //    {
        //        orden = @"INSERT INTO Piezas (id_pieza, id_area, codigo, nombre, descripcion, precio) 
        //          VALUES (@Id_pieza, @Id_area, @Codigo, @Nombre, @Descripcion, @Precio)";

        //        cmd.CommandText = orden;

        //        // Asignar los valores de los parámetros
        //        cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
        //        cmd.Parameters.AddWithValue("@Id_area", objPieza.Id_area);
        //        cmd.Parameters.AddWithValue("@Codigo", objPieza.Codigo);
        //        cmd.Parameters.AddWithValue("@Nombre", objPieza.Nombre);
        //        cmd.Parameters.AddWithValue("@Descripcion", objPieza.Descripcion);
        //        cmd.Parameters.AddWithValue("@Precio", objPieza.Precio);
        //    }

        //    if (accion == "Modificar")
        //    {
        //        orden = @"UPDATE Piezas 
        //          SET id_area = @Id_area, 
        //              codigo = @Codigo, 
        //              nombre = @Nombre, 
        //              descripcion = @Descripcion, 
        //              precio = @Precio 
        //          WHERE id_pieza = @Id_pieza";

        //        cmd.CommandText = orden;

        //        // Asignar los valores de los parámetros
        //        cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
        //        cmd.Parameters.AddWithValue("@Id_area", objPieza.Id_area);
        //        cmd.Parameters.AddWithValue("@Codigo", objPieza.Codigo);
        //        cmd.Parameters.AddWithValue("@Nombre", objPieza.Nombre);
        //        cmd.Parameters.AddWithValue("@Descripcion", objPieza.Descripcion);
        //        cmd.Parameters.AddWithValue("@Precio", objPieza.Precio);
        //    }

        //    if (accion == "Eliminar")
        //    {
        //        orden = "DELETE FROM Piezas WHERE id_pieza = @Id_pieza";

        //        cmd.CommandText = orden;

        //        // Asignar el valor del parámetro
        //        cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
        //    }

        //    try
        //    {
        //        Abrirconexion();
        //        resultado = cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Error al tratar de guardar, borrar o modificar la pieza con ID {objPieza.Id_pieza}", e);
        //    }
        //    finally
        //    {
        //        Cerrarconexion();
        //        cmd.Dispose();
        //    }

        //    return resultado;
        //}

        #endregion

        //public int abmPieza(string accion, Pieza objPieza)
        //{
        //    int resultado = -1;
        //    using (SqlCommand cmd = new SqlCommand("sp_ManagePieza", conexion))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Asignar los valores de los parámetros
        //        cmd.Parameters.AddWithValue("@Accion", accion);
        //        cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
        //        cmd.Parameters.AddWithValue("@Id_area", objPieza.Id_area);
        //        cmd.Parameters.AddWithValue("@Codigo", objPieza.Codigo);
        //        cmd.Parameters.AddWithValue("@Nombre", objPieza.Nombre);
        //        cmd.Parameters.AddWithValue("@Descripcion", objPieza.Descripcion);
        //        cmd.Parameters.AddWithValue("@Precio", objPieza.Precio);

        //        try
        //        {
        //            Abrirconexion();
        //            resultado = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            // Capturar el mensaje de error del procedimiento almacenado
        //            throw new Exception($"Error al tratar de guardar, borrar o modificar la pieza con ID {objPieza.Id_pieza}: {e.Message}", e);
        //        }
        //        finally
        //        {
        //            Cerrarconexion();
        //        }
        //    }

        //    return resultado;
        //}



        public int abmPieza(string accion, Pieza objPieza)
        {
            int resultado = -1;
            string nombreProcedimiento = string.Empty;

            if (accion == "Alta")
            {
                nombreProcedimiento = "InsertarPieza";
            }
            else if (accion == "Modificar")
            {
                nombreProcedimiento = "ModificarPieza"; // Asegúrate de crear este procedimiento almacenado
            }
            else if (accion == "Eliminar")
            {
                nombreProcedimiento = "EliminarPieza"; // Asegúrate de crear este procedimiento almacenado
            }
            else
            {
                throw new ArgumentException("Acción no válida");
            }

            using (SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPieza", objPieza.Id_pieza);
                cmd.Parameters.AddWithValue("@Codigo", objPieza.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objPieza.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", objPieza.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", objPieza.Precio);

                try
                {
                    Abrirconexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new Exception($"Error al tratar de guardar, borrar o modificar la pieza con ID {objPieza.Id_pieza}", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }

            return resultado;
        }


        private bool ValidarCargaPiezaEnArea(Guid idArea)
        {
            bool areaExiste = false;

            // Crear la consulta SQL para verificar si el área existe
            string consulta = "SELECT COUNT(*) FROM Areas WHERE id_area = @idArea";
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@idArea", idArea);

            try
            {
                Abrirconexion();
                int count = (int)cmd.ExecuteScalar();
                areaExiste = count > 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error al validar el área", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return areaExiste;
        }

       



    }
}
