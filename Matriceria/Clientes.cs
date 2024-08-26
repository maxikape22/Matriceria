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

        private void btGuardarCliente_Click_1(object sender, EventArgs e)
        {
            bool validar = true; //= ValidacionCamposProducto();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjCliente();
                nGrabados = objNegocioCliente.abmCliente("Alta", objEntCliente);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el cliente al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar al Producto con éxito");
                    //LlenarDGVProducto();
                    //LimpiarProducto();
                    //LlenarCombos();
                    //tabControl1.SelectTab(tabProducto);
                }
            }
        }
    }
}
