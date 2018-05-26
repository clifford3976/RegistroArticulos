using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
        }

        private void articulosDelRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rArticulos rA = new UI.Registros.rArticulos();
            rA.Show();
        }


        private void losArticulosDeLaConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Consultas.cArticulos cA = new UI.Consultas.cArticulos();
            cA.Show();
        }

        private void MainForms_Load(object sender, EventArgs e)
        {

        }

    }
}
