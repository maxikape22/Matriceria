using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Piezas : Form
    {
        public Pieza objEntPieza = new Pieza();
        public PiezaNegocio objNegocioPieza = new PiezaNegocio();
        public Piezas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtBox_a_ObjPieza()
        {
            objEntPieza.Codigo = txtCodigo.Text;
            objEntPieza.Nombre = txtNombrePieza.Text;
            objEntPieza.Descripcion = txtDescripcion.Text;
            objEntPieza.Precio = decimal.Parse(txtPrecio.Text);
        }

        private bool ValidacionCamposPieza()
        {
            // Validación del Código
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCodigo.Text.Length > 50 || txtCodigo.Text.Length < 2)
            {
                MessageBox.Show("El código debe tener entre 2 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Nombre
            if (string.IsNullOrWhiteSpace(txtNombrePieza.Text))
            {
                MessageBox.Show("Ingrese el nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombrePieza.Text.Length > 100)
            {
                MessageBox.Show("El nombre no debe tener más de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de la Descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDescripcion.Text.Length > 500)
            {
                MessageBox.Show("La descripción no debe tener más de 500 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Precio
            if (txtPrecio.Text.Length <= 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor a 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {

            bool validar = ValidacionCamposPieza();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjPieza();
                nGrabados = objNegocioPieza.InsertarPieza("Alta", objEntPieza);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar la pieza al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar la pieza con éxito");
                }
            }

        }
    }
}