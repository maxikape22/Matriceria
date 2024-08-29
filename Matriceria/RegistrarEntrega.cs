using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Matriceria
{
    public partial class RegistrarEntrega : Form
    {
        public Entrega objEntEntrega = new Entrega();
        public EntregaNegocio objNegocioEntrega = new EntregaNegocio();
        public RegistrarEntrega()
        {
            InitializeComponent();
            ComboboxEntregado();
        }

        public void ComboboxEntregado()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Entregado", typeof(bool));

            // Agregar filas simuladas
            dataTable.Rows.Add(true);
            dataTable.Rows.Add(false);

            // Llenar el ComboBox
            cmbEntregado.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                string entregadoTexto = (bool)row["Entregado"] ? "Sí" : "No";
                cmbEntregado.Items.Add(entregadoTexto);
            }

        }

        private void TxtBox_a_ObjRegistrarEntrega()
        {
            objEntEntrega.CodigoEntrega = txtCodigo.Text;
            objEntEntrega.FechaEntrega = dateTimeFechaEntrega.Value;
            objEntEntrega.HorarioEntrega = txtHorarioEntrega.Text;
            objEntEntrega.EstadoEntrega = txtEstadoEntrega.Text;
            objEntEntrega.MedioDePago = cmbMedioPago.Text;
            objEntEntrega.Entregado = bool.Parse(cmbEntregado.Text);
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool validar = true; //= ValidacionCamposProducto();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjRegistrarEntrega();
                nGrabados = objNegocioEntrega.abmEntrega("Alta", objEntEntrega);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar la entrega al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar la entrega con éxito");
                    //LlenarDGVProducto();
                    //LimpiarProducto();
                    //LlenarCombos();
                    //tabControl1.SelectTab(tabProducto);
                }
            }
        }
    }
}
