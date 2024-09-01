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
        }

       

      
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura el filtro del TextBox
                string filtro = txtEntrega.Text.Trim();

                // Obtiene la lista completa de entregas con detalles
                DataSet dsEntregas = objNegocioEntrega.Union();

                // Limpia las filas existentes en el DataGridView
                dgvEntrega.Rows.Clear();

                // Verifica si el DataSet no es nulo y contiene la tabla de entregas
                if (dsEntregas != null && dsEntregas.Tables.Count > 0 && dsEntregas.Tables[0].Rows.Count > 0)
                {
                    // Filtra las filas del DataSet por el código de entrega ingresado
                    var entregasFiltradas = dsEntregas.Tables[0].AsEnumerable()
                        .Where(row => row.Field<string>("CodigoEntrega").Contains(filtro)) // Filtra por código de entrega
                        .ToList();

                    // Verifica si se encontraron entregas filtradas
                    if (entregasFiltradas.Count > 0)
                    {
                        // Añade cada entrega filtrada al DataGridView
                        foreach (DataRow row in entregasFiltradas)
                        {
                            dgvEntrega.Rows.Add(
                                row["CodigoEntrega"].ToString(),
                                row["CodigoOrden"].ToString(),
                                row["RazonSocial"].ToString(),
                                Convert.ToDateTime(row["FechaEntrega"]).ToShortDateString(),
                                row["HorarioEntrega"].ToString(),
                                row["EstadoEntrega"].ToString(),
                                row["MedioDePago"].ToString(),
                                row["Entregado"].ToString()
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron entregas con el código proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No hay entregas disponibles para filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"Error al eliminar la entrega: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LlenarDgEntregas()
        {

            try
            {
                // Obtener lista de entregas con detalles
                DataSet dsEntregas = objNegocioEntrega.Union();

                // Limpiar las filas existentes en el DataGridView
                dgvEntrega.Rows.Clear();

                // Verificar si hay datos en el DataSet
                if (dsEntregas != null && dsEntregas.Tables.Count > 0 && dsEntregas.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsEntregas.Tables[0].Rows)
                    {
                        // Añadir cada fila de datos al DataGridView
                        dgvEntrega.Rows.Add(
                            row["CodigoEntrega"].ToString(),
                            row["CodigoOrden"].ToString(),
                            row["RazonSocial"].ToString(),
                            Convert.ToDateTime(row["FechaEntrega"]).ToShortDateString(),
                            row["HorarioEntrega"].ToString(),
                            row["EstadoEntrega"].ToString(),
                            row["MedioDePago"].ToString(),
                            row["Entregado"].ToString()
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron entregas con los detalles solicitados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las entregas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}