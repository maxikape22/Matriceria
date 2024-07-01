using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AreaPorOt area = new AreaPorOt();
            area.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Lista_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("22356","matriz tapitas","abierto", "17/01/2014", "17/01/2014", "4/03/2014");
            dataGridView1.Rows.Add("59364","Cerradura","abierto","17/01/2014", "17/01/2014", "1/05/2014");
        }
    }
}
