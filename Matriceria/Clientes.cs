using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Clientes : Form
    {
        public Cliente objEntCliente = new Cliente();
        public ClienteNegocio objNegocioCliente = new ClienteNegocio();

        public Clientes()
        {
            InitializeComponent();
        }

       

        private void TxtBox_a_ObjCliente()
        {
            objEntCliente.RazonSocial = txtRazonSocial.Text;
            objEntCliente.CUIT = Convert.ToInt32(txtCUIT.Text);
            objEntCliente.Telefono = txtTelefono.Text;
            objEntCliente.Domicilio = txtDomicilio.Text;
        }

        private bool ValidacionCamposCliente()
        {
            // Validación de la Razón Social
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("Ingrese la razón social", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtRazonSocial.Text.Length > 100)
            {
                MessageBox.Show("La razón social no debe tener más de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del CUIT
            if (string.IsNullOrWhiteSpace(txtCUIT.Text))
            {
                MessageBox.Show("Ingrese el CUIT", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!int.TryParse(txtCUIT.Text, out int cuit) || cuit <= 0)
            {
                MessageBox.Show("Ingrese un CUIT válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Teléfono
            string telefonoPattern = @"^\+549351\d{7}$";
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, telefonoPattern))
            {
                MessageBox.Show("Ingrese un teléfono válido en el formato +549351XXXXXXX", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Domicilio
            if (string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                MessageBox.Show("Ingrese el domicilio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDomicilio.Text.Length > 200)
            {
                MessageBox.Show("El domicilio no debe tener más de 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btGuardarCliente_Click_1(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposCliente();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjCliente();
                nGrabados = objNegocioCliente.InsertarCliente(objEntCliente);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el cliente al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar el cliente con éxito al sistema");
                }
            }
        }
    }
}
