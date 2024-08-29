using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Ots : Form
    {
        public Orden objEntOrden = new Orden();
        public OrdenNegocio objNegocioOrden = new OrdenNegocio();
        public Ots()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ots_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Areas ar = new Areas();
            ar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Piezas piezas = new Piezas();
            piezas.Show();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool validar = true; //= ValidacionCamposProducto();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjOrden();
                nGrabados = objNegocioOrden.abmOrden("Alta", objEntOrden);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar la orden al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar la orden con éxito");
                    //LlenarDGVProducto();
                    //LimpiarProducto();
                    //LlenarCombos();
                    //tabControl1.SelectTab(tabProducto);
                }
            }
        }

        private void TxtBox_a_ObjOrden()
        {
            objEntOrden.Codigo = txtCodigo.Text;
            objEntOrden.Prioridad = cmbPrioridad.Text;
            objEntOrden.Descripcion = txtDescripcion.Text;
            objEntOrden.Estado = cmbEstado.Text;
            objEntOrden.Fecha_inicio = dateTimeFechaInicio.Value;
            objEntOrden.Fecha_prometido = dateTimeFechaPrometido.Value;
        }



    }
}
