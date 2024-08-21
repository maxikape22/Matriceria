using System;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Ots : Form
    {
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
    }
}
