using Matriceria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Matriceria.BD
{
    public class ListaArea : DatosConexionBD
    {
        // Método para insertar un área

        public int abmArea(string accion, Area objArea)
        {
            int resultado = -1;
            string orden = string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            if (accion == "Alta")
            {
                orden = @"INSERT INTO Areas (id_area, nombre_area, tiempo) 
                  VALUES (@Id_area, @Nombre_area, @Tiempo)";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@Id_area", objArea.Id_area);
                cmd.Parameters.AddWithValue("@Nombre_area", objArea.Nombre_area);
                cmd.Parameters.AddWithValue("@Tiempo", objArea.Tiempo);
            }

            if (accion == "Modificar")
            {
                orden = @"UPDATE Areas 
                  SET nombre_area = @Nombre_area, 
                      tiempo = @Tiempo 
                  WHERE id_area = @Id_area";

                cmd.CommandText = orden;

                // Asignar los valores de los parámetros
                cmd.Parameters.AddWithValue("@Id_area", objArea.Id_area);
                cmd.Parameters.AddWithValue("@Nombre_area", objArea.Nombre_area);
                cmd.Parameters.AddWithValue("@Tiempo", objArea.Tiempo);
            }

            if (accion == "Eliminar")
            {
                orden = "DELETE FROM Areas WHERE id_area = @Id_area";

                cmd.CommandText = orden;

                // Asignar el valor del parámetro
                cmd.Parameters.AddWithValue("@Id_area", objArea.Id_area);
            }

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error al tratar de realizar la acción '{accion}' para el área con ID {objArea.Id_area}", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public int abmArea1(Area objArea)
        {
            int resultado = -1;
            string orden = @"INSERT INTO Areas (id_area, nombrea_area, tiempo) 
                         VALUES (@Id_area, @Nombre_area, @Tiempo)";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@Id_area", objArea.Id_area);
            cmd.Parameters.AddWithValue("@Nombre_area", objArea.Nombre_area);
            cmd.Parameters.AddWithValue("@Tiempo", objArea.Tiempo);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al insertar el área", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        // Método para modificar un área
        public int ModificarArea(Area objArea)
        {
            int resultado = -1;
            string orden = @"UPDATE Areas 
                         SET nombre_area = @Nombre_area, 
                             tiempo = @Tiempo 
                         WHERE id_area = @Id_area";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@Id_area", objArea.Id_area);
            cmd.Parameters.AddWithValue("@Nombre_area", objArea.Nombre_area);
            cmd.Parameters.AddWithValue("@Tiempo", objArea.Tiempo);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al modificar el área", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        // Método para listar todas las áreas
        public List<Area> ObtenerListarAreas()
        {
            List<Area> lista = new List<Area>();
            string orden = "SELECT id_area, nombre_area, tiempo FROM Areas";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            SqlDataReader dataReader;

            try
            {
                Abrirconexion();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Area area = new Area
                    {
                        Id_area = dataReader.GetInt32(0),
                        Nombre_area = dataReader.GetString(1),
                        Tiempo = dataReader.GetInt32(2)
                    };

                    lista.Add(area);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar las áreas", e);
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
