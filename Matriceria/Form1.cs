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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lista s = new Lista();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistrarEntrega entr = new RegistrarEntrega();
            entr.Show();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ots ot = new Ots();
            ot.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.Show();
        }
    }
}
