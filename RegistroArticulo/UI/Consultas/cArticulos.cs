using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo.UI.Consultas
{
    public partial class cArticulos : Form
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> Filtro = x => true;

            int id;
            switch(FiltrocomboBox.SelectedIndex)
            {
                case 0:
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = x => x.ArticuloID == id;
                    break;

                case 1:
                    Filtro = x => x.FechaVencimiento.Equals(CriteriotextBox.Text);
                    break;

                case 2:
                    Filtro = x => x.Descripcion.Equals(CriteriotextBox.Text);
                    break;

                case 3:
                    Filtro = x => x.Precio.Equals(CriteriotextBox.Text);
                    break;

                case 4:
                    Filtro = x => x.Existencia.Equals(CriteriotextBox.Text);
                    break;

                case 5:
                    Filtro = x => x.CantidadCotizado.Equals(CriteriotextBox.Text);
                    break;
            }
            ConsultadataGridView.DataSource = BLL.ArticulosBLL.GetList(Filtro);
        }
    }
}
