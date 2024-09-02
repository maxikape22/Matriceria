using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Entregas : Form
    {
        public Entrega objEntEntrega = new Entrega();
        public Orden objOrden = new Orden();
        public Cliente objCliente = new Cliente();
        public EntregaNegocio objNegocioEntrega = new EntregaNegocio();
        public Entregas()
        {
            InitializeComponent();
            LlenarDgEntregas();
        }

       

      
        //ESTE ES EL BOTON PARA FILTRAR LA ENTREGA--> EL DISEÑADOR NO DEJA CAMBIAR NOMBRE DEL CONTROL
        private void button2_Click(object sender, EventArgs e)
        {
            #region
            //try
            //{
            //    // Captura el filtro del TextBox
            //    string filtro = txtEntrega.Text.Trim();

            //    // Obtiene la lista completa de entregas
            //    List<Entrega> listaEntregas = objNegocioEntrega.ObtenerEntregas();

            //    // Limpia las filas existentes en el DataGridView
            //    dgvEntrega.Rows.Clear();

            //    // Verifica si la lista no es nula y contiene elementos
            //    if (listaEntregas != null && listaEntregas.Count > 0)
            //    {
            //        // Filtra la lista de entregas por el código ingresado
            //        var entregasFiltradas = listaEntregas
            //            .Where(ex => ex.CodigoEntrega.Contains(filtro))  // Filtra por código de entrega
            //            .ToList();

            //        // Verifica si se encontraron entregas filtradas
            //        if (entregasFiltradas.Count > 0)
            //        {
            //            // Añade cada entrega filtrada al DataGridView
            //            foreach (Entrega entrega in entregasFiltradas)
            //            {
            //                dgvEntrega.Rows.Add(
            //                    entrega.CodigoEntrega,                        // Código de la Entrega
            //                    entrega.FechaEntrega.ToShortDateString(),     // Fecha de Entrega
            //                    entrega.HorarioEntrega,                      // Horario de Entrega
            //                    entrega.EstadoEntrega,                       // Estado de Entrega
            //                    entrega.MedioDePago,                         // Medio de Pago
            //                    entrega.Entregado                            // Entregado (booleano)
            //                );
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se encontraron entregas con el código proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No hay entregas disponibles para filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al filtrar las entregas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion

            try
            {
                // Captura el filtro del TextBox
                string filtro = txtEntrega.Text.Trim();

                // Obtiene la lista filtrada de entregas desde la capa de negocio
                DataSet dsEntregasFiltradas = objNegocioEntrega.FiltrarEntregasPorCodigo(filtro);

                // Limpia las filas existentes en el DataGridView
                dgvEntrega.Rows.Clear();

                // Verifica si se obtuvieron resultados
                if (dsEntregasFiltradas.Tables.Count > 0 && dsEntregasFiltradas.Tables[0].Rows.Count > 0)
                {
                    // Recorrer cada fila del DataSet
                    foreach (DataRow row in dsEntregasFiltradas.Tables[0].Rows)
                    {
                        dgvEntrega.Rows.Add(
                            row["codigo_entrega"].ToString(),                 // Código de la Entrega
                            Convert.ToDateTime(row["fecha_entrega"]).ToShortDateString(), // Fecha de Entrega
                            row["horario_entrega"].ToString(),               // Horario de Entrega
                            row["estado_entrega"].ToString(),                // Estado de Entrega
                            row["medio_de_pago"].ToString(),                 // Medio de Pago
                            row["entregado"].ToString()                      // Entregado
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron entregas con el código proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar las entregas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btEliminarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si el código de la entrega está ingresado
                string codigoEntrega = txtEntrega.Text.Trim();

                if (string.IsNullOrWhiteSpace(codigoEntrega))
                {
                    MessageBox.Show("Ingrese el código de la entrega a eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Confirmar la eliminación con el usuario
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta entrega?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método de eliminación en la capa de negocio
                    int eliminado = objNegocioEntrega.EliminarEntrega(codigoEntrega);

                    if (eliminado > 0) // Aquí se verifica si la eliminación fue exitosa
                    {
                        MessageBox.Show("Entrega eliminada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Opcional: Limpiar formulario, recargar datos, etc.
                        LlenarDgEntregas();  // Para actualizar la vista del DataGridView si es necesario
                    }
                    else
                    {
                        MessageBox.Show("No se logró eliminar la entrega. Verifique el código ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al eliminar la entrega: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show(ex.Message);
            }
        }

        public void LlenarDgEntregas()
        {
            #region
            //try
            //{
            //    // Obtener lista de entregas con detalles
            //    DataSet dsEntregas = objNegocioEntrega.Union();

            //    // Limpiar las filas existentes en el DataGridView
            //    dgvEntrega.Rows.Clear();

            //    // Verificar si hay datos en el DataSet
            //    if (dsEntregas != null && dsEntregas.Tables.Count > 0 && dsEntregas.Tables[0].Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dsEntregas.Tables[0].Rows)
            //        {
            //            // Añadir cada fila de datos al DataGridView
            //            dgvEntrega.Rows.Add(
            //                row["CodigoEntrega"].ToString(),
            //                row["CodigoOrden"].ToString(),
            //                row["RazonSocial"].ToString(),
            //                Convert.ToDateTime(row["FechaEntrega"]).ToShortDateString(),
            //                row["HorarioEntrega"].ToString(),
            //                row["EstadoEntrega"].ToString(),
            //                row["MedioDePago"].ToString(),
            //                row["Entregado"].ToString()
            //            );
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se encontraron entregas con los detalles solicitados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al cargar las entregas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion

            List<Entrega> listaEntregas = objNegocioEntrega.ObtenerEntregas();

            dgvEntrega.Rows.Clear();

            // Asegúrate de que el DataGridView esté configurado correctamente para mostrar las columnas
            // Si no lo está, puedes configurar las columnas manualmente aquí

            if (listaEntregas != null && listaEntregas.Count > 0)
            {
                foreach (Entrega entrega in listaEntregas)
                {
                    // Añadir cada entrega como una nueva fila en el DataGridView
                    dgvEntrega.Rows.Add(
                        entrega.CodigoEntrega,                       
                        entrega.FechaEntrega.ToShortDateString(),     
                        entrega.HorarioEntrega,                      
                        entrega.EstadoEntrega,                       
                        entrega.MedioDePago,                         
                        entrega.Entregado                            
                    );
                }
            }
        }
    }
}