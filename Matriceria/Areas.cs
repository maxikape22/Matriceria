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


        private bool ValidacionCamposArea()
        {
            // Validación del Nombre del Área
            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                MessageBox.Show("Ingrese el nombre del área", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtArea.Text.Length > 100 || txtArea.Text.Length < 2)
            {
                MessageBox.Show("El nombre del área debe tener entre 2 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación del Tiempo
            if (!int.TryParse(txtTiempo.Text, out int tiempo) || tiempo <= 0)
            {
                MessageBox.Show("Ingrese un tiempo válido (en minutos) mayor a 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Si todas las validaciones pasan, retorna true
            return true;
        }

        private void btRegistrarArea_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposArea();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjArea();
                nGrabados = objNegocioArea.InsertarArea(objEntArea);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el área al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar el área con éxito");
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
