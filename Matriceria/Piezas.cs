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
        private void btGuardar_Click(object sender, EventArgs e)
        {

            bool validar = true; //= ValidacionCamposProducto();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjPieza();
                nGrabados = objNegocioPieza.abmPieza1("Alta", objEntPieza);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar la pieza al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar la pieza con éxito");
                }
            }


            //bool validar = true; // Supongo que tienes un método de validación
            //int nGrabados = -1;

            //if (validar == true)
            //{
            //    try
            //    {
            //        TxtBox_a_ObjPieza();
            //        nGrabados = objNegocioPieza.abmPieza1("Alta", objEntPieza);
            //        if (nGrabados == -1)
            //        {
            //            MessageBox.Show("No se logró agregar la pieza al sistema");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Se logró agregar la pieza con éxito");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"{ex.Message}");
            //    }
            //}


        }
    }
}