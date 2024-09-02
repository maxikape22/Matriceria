using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class RegistrarEntrega : Form
    {
        public Entrega objEntEntrega = new Entrega();
        public EntregaNegocio objNegocioEntrega = new EntregaNegocio();
        public RegistrarEntrega()
        {
            InitializeComponent();
            CargarComboBox();
        }

 
        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposEntrega();
            try
            {
                if (validar)
                {
                    // Crear el objeto de la entrega y asignar valores
                    TxtBox_a_ObjRegistrarEntrega();

                    // Insertar la entrega usando la capa de negocio
                    int nGrabados = objNegocioEntrega.InsertarEntrega("Alta", objEntEntrega);

                    if (nGrabados == -1)
                    {
                        MessageBox.Show("No se logró agregar la entrega al sistema");
                    }
                    else
                    {
                        MessageBox.Show("Se logró agregar la entrega con éxito");
                        // Opcional: Limpiar formulario, recargar datos, etc.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private bool ValidacionCamposEntrega()
        {
            // Validación del Código de Entrega
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCodigo.Text.Length > 50 || txtCodigo.Text.Length < 2)
            {
                MessageBox.Show("El código de entrega debe tener entre 2 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de la Fecha de Entrega
            DateTime fechaEntrega = dateTimeFechaEntrega.Value;
            if (fechaEntrega == default(DateTime))
            {
                MessageBox.Show("Ingrese una fecha de entrega válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Horario de Entrega
            if (string.IsNullOrWhiteSpace(txtHorarioEntrega.Text))
            {
                MessageBox.Show("Ingrese un horario de entrega", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Estado de Entrega
            if (cmbEntregado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado de la entrega", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Medio de Pago
            if (cmbMedioPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el medio de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Entregado
            if (cmbEntregado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione si la entrega ha sido realizada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void TxtBox_a_ObjRegistrarEntrega()
        {

            objEntEntrega.CodigoEntrega = txtCodigo.Text;
            dateTimeFechaEntrega.Text = (DateTime.Now).ToShortDateString();
            objEntEntrega.HorarioEntrega = txtHorarioEntrega.Text;
            objEntEntrega.EstadoEntrega = txtEstadoEntrega.Text;
            objEntEntrega.MedioDePago = cmbMedioPago.Text;
            objEntEntrega.Entregado = cmbEntregado.Text;
        }

        //TRANSFORMACIONES DE DATOS

        public enum MedioDePago
        {
            Tarjeta         =  1,
            Transferencia   =  2,
            Efectivo        =  3
        }

        public enum Entregado
        {
            Si  = 1,
            No  = 2
        }

        private readonly Dictionary<MedioDePago, string> MedioDePagoMapeo = new Dictionary<MedioDePago, string>()
        {
            {
                MedioDePago.Tarjeta, "Tarjeta de credito"
            },
            {
                MedioDePago.Transferencia, "Transferencia"
            },
            {
                MedioDePago.Efectivo, "Efectivo"
            }
        };

        private readonly Dictionary<Entregado, string> EntregadoMapeo = new Dictionary<Entregado, string>()
        {
            {
                Entregado.Si, "Sí"
            },
            {
                Entregado.No, "No"
            }
        };

        private void CargarComboBox()
        {
            // Cargar ComboBox de Medio de pago
            cmbMedioPago.DataSource = new BindingSource(MedioDePagoMapeo, null);
            cmbMedioPago.DisplayMember = "Value";
            cmbMedioPago.ValueMember = "Key";

            // Cargar ComboBox de Entregado
            cmbEntregado.DataSource = new BindingSource(EntregadoMapeo, null);
            cmbEntregado.DisplayMember = "Value";
            cmbEntregado.ValueMember = "Key";
        }

        private void btListaEntregas_Click(object sender, EventArgs e)
        {
            Entregas entregas = new Entregas();
            entregas.Show();
        }

        private void btRegresoInicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
