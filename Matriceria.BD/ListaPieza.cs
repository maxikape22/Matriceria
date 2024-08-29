using Matriceria.Entidades;
using System.Data.SqlClient;
using System;

namespace Matriceria.BD
{
    public class ListaPieza : DatosConexionBD
    {
        public int abmPieza(string accion, Pieza objPieza)
        {
            int resultado = -1;
            string orden = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            if (accion == "Alta")
            {
                orden = @"INSERT INTO Piezas (id_pieza, id_area, codigo, nombre, descripcion, precio) 
                  VALUES (@Id_pieza, @Id_area, @Codigo, @Nombre, @Descripcion, @Precio)";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
                cmd.Parameters.AddWithValue("@Id_area", objPieza.Id_area);
                cmd.Parameters.AddWithValue("@Codigo", objPieza.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objPieza.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", objPieza.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", objPieza.Precio);
            }

            if (accion == "Modificar")
            {
                orden = @"UPDATE Piezas 
                  SET id_area = @Id_area, 
                      codigo = @Codigo, 
                      nombre = @Nombre, 
                      descripcion = @Descripcion, 
                      precio = @Precio 
                  WHERE id_pieza = @Id_pieza";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
                cmd.Parameters.AddWithValue("@Id_area", objPieza.Id_area);
                cmd.Parameters.AddWithValue("@Codigo", objPieza.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objPieza.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", objPieza.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", objPieza.Precio);
            }

            if (accion == "Eliminar")
            {
                orden = "DELETE FROM Piezas WHERE id_pieza = @Id_pieza";

                cmd.CommandText = orden;

                // Asignar el valor del parámetro
                cmd.Parameters.AddWithValue("@Id_pieza", objPieza.Id_pieza);
            }

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de guardar, borrar o modificar la pieza con ID {objPieza.Id_pieza}", e);
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
