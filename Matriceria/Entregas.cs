using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Entregas : Form
    {
        public Entrega objEntEntrega = new Entrega();
        public EntregaNegocio objNegocioEntrega = new EntregaNegocio();
        public Entregas()
        {
            InitializeComponent();
        }

        public void LlenarDgEntregaBuscar()
        {
            string cual = txtEntrega.Text;
            dgvEntrega.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegocioEntrega.FiltroEntrega(cual);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvEntrega.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9]);
                }
            }

        }

        public void DgEliminarEntrega()
        {
            string id = txtEntrega.Text;
            dgvEntrega.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegocioEntrega.ListarEntregaEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvEntrega.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("No se pudo eliminar la entrega");
                        //MessageBox.Show(e.InnerException.Message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo eliminar la entrega");
                //MessageBox.Show(e.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LlenarDgEntregaBuscar();
        }

        private void btEliminarEntrega_Click(object sender, EventArgs e)
        {
            if (true)
            {

                DgEliminarEntrega();

                LlenarDgEntrega();

                MessageBox.Show("Se elimino la entrega");
            }
        }

        private void LlenarDgEntrega()
        {

            dgvEntrega.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegocioEntrega.Union();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvEntrega.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }
            }
        }
    }
}
