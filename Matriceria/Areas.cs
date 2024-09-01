using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Areas : Form
    {
        public Area objEntArea = new Area();
        public AreaNegocio objNegocioArea = new AreaNegocio();

        public Areas()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btRegistrarArea_Click(object sender, EventArgs e)
        {
            bool validar = true; //= ValidacionCamposProducto();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjArea();
                nGrabados = objNegocioArea.abmArea("Alta", objEntArea);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el área al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar el área con éxito");
                    //LlenarDGVProducto();
                    //LimpiarProducto();
                    //LlenarCombos();
                    //tabControl1.SelectTab(tabProducto);
                }
            }
        }

        private void TxtBox_a_ObjArea()
        {
            objEntArea.Nombre_area = txtArea.Text;
            objEntArea.Tiempo = Convert.ToInt32(txtTiempo.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
