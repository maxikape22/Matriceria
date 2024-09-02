using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
            LlenarDgOrdenes();
        }

        public Orden objEntOrden = new Orden();
        public OrdenNegocio objNegocioOrden = new OrdenNegocio();

        private void btFiltroOT_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura el filtro del TextBox
                string filtro = txtFiltroOT.Text.Trim();

                // Obtiene la lista completa de órdenes
                List<Orden> listaOrdenes = objNegocioOrden.ObtenerOrdenes();

                // Limpia las filas existentes en el DataGridView
                dgListaOrdenes.Rows.Clear();

                // Verifica si la lista no es nula y contiene elementos
                if (listaOrdenes != null && listaOrdenes.Count > 0)
                {
                    // Filtra la lista de órdenes por el código ingresado
                    var ordenesFiltradas = listaOrdenes
                        .Where(o => o.Codigo.Contains(filtro))  // Filtra por código
                        .ToList();

                    // Verifica si se encontraron órdenes filtradas
                    if (ordenesFiltradas.Count > 0)
                    {
                        // Añade cada orden filtrada al DataGridView
                        foreach (Orden orden in ordenesFiltradas)
                        {
                            dgListaOrdenes.Rows.Add(
                                orden.Codigo,
                                orden.Prioridad,
                                orden.Descripcion,
                                orden.Estado,
                                orden.Fecha_inicio.ToShortDateString(),
                                orden.Fecha_prometido.ToShortDateString()
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron órdenes con el código proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No hay órdenes disponibles para filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar las órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btEliminarOT_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si el código de la orden está ingresado
                string codigo = txtFiltroOT.Text.Trim();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("Ingrese el código de la orden a eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Confirmar la eliminación con el usuario
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta orden?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método de eliminación en la capa de negocio
                    int filasEliminadas = objNegocioOrden.EliminarOrden(codigo);

                    if (filasEliminadas > 0)  // Asumiendo que un valor mayor a 0 indica éxito
                    {
                        MessageBox.Show("Orden eliminada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Opcional: Limpiar formulario, recargar datos, etc.
                        LlenarDgOrdenes();  // Para actualizar la vista del DataGridView si es necesario
                    }
                    else
                    {
                        MessageBox.Show("No se logró eliminar la orden. Verifique el código ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btImprimirOT_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener la lista de órdenes de trabajo desde la capa de datos
                List<Orden> ordenes = objNegocioOrden.ObtenerOrdenes();

                if (ordenes == null || ordenes.Count == 0)
                {
                    MessageBox.Show("No hay órdenes de trabajo para imprimir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Crear un diálogo de guardar archivo para seleccionar la ubicación y el nombre del archivo PDF
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar PDF de Órdenes de Trabajo";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaArchivo = saveFileDialog.FileName;

                        // Llamar al método en la capa de datos para generar el PDF
                        byte[] pdfBytes = objNegocioOrden.GenerarPDFDeListaDeOrdenes(ordenes);

                        if (pdfBytes != null)
                        {
                            // Guardar el archivo PDF en la ubicación seleccionada
                            File.WriteAllBytes(rutaArchivo, pdfBytes);
                            MessageBox.Show($"PDF generado y guardado como {rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo generar el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LlenarDgOrdenes()
        {
            // Obtener lista de órdenes
            List<Orden> listaOrdenes = objNegocioOrden.ObtenerOrdenes();

            // Limpiar las filas existentes en el DataGridView
            dgListaOrdenes.Rows.Clear();

            // Asegúrate de que el DataGridView esté configurado correctamente para mostrar las columnas
            // Si no lo está, puedes configurar las columnas manualmente aquí

            if (listaOrdenes != null && listaOrdenes.Count > 0)
            {
                foreach (Orden orden in listaOrdenes)
                {
                    // Añadir cada orden como una nueva fila en el DataGridView
                    dgListaOrdenes.Rows.Add(
                        orden.Codigo,
                        orden.Prioridad,
                        orden.Descripcion,
                        orden.Estado,
                        orden.Fecha_inicio.ToShortDateString(), // Puedes ajustar el formato de la fecha si es necesario
                        orden.Fecha_prometido.ToShortDateString() // Puedes ajustar el formato de la fecha si es necesario
                    );
                }
            }
        }

    }
}
