using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo.UI.Registros
{
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        public bool validar()
        {
            
            if(string.IsNullOrEmpty(DescripcionrichTextBox.Text))
            {
                errorProvider1.SetError(DescripcionrichTextBox, "llenar Descripcion");
                
                return false;
            }

            if (string.IsNullOrEmpty(PrecionumericUpDown.ToString()))
            {
                errorProvider1.SetError(PrecionumericUpDown, "No debes dejar el precio vacio");
                return false;

            }
            return true;
        }

        private Articulos LLenaClase()
        {
            Articulos Articulo = new Articulos();
            Articulo.ArticuloID = Convert.ToInt32(ArticuloIDnumericUpDown.Value);
            Articulo.FechaVencimiento = FechaVencimientodateTimePicker.Value;
            Articulo.Descripcion = DescripcionrichTextBox.Text;
            Articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            Articulo.Existencia = Convert.ToInt32(ExistencianumericUpDown.Value);
            Articulo.CantidadCotizado = Convert.ToInt32(CantidadCotizadonumericUpDown.Value);

            return Articulo;

        }

        private void rArticulos_Load(object sender, EventArgs e)
        {

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            ArticuloIDnumericUpDown.Value = 0;
            FechaVencimientodateTimePicker.Value = DateTime.Now;
            DescripcionrichTextBox.Clear();
            PrecionumericUpDown.Value = 0 ;
            ExistencianumericUpDown.Value = 0;
            CantidadCotizadonumericUpDown.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if(!validar())
            {
                MessageBox.Show("llena", "y trate de guardar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else    
           
            {
                Articulos Articulo = LLenaClase();
                bool paso = false;


                if (ArticuloIDnumericUpDown.Value == 0)
                {
                    paso = BLL.ArticulosBLL.Guardar(Articulo);
                }
                else
                {
                    paso = BLL.ArticulosBLL.Modificar(Articulo);
                }

                if (paso)
                {
                    MessageBox.Show("guardado", "se guardo exitosamente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(ArticuloIDnumericUpDown.Value);
            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("fue eliminado", "acceptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArticuloIDnumericUpDown.Value);
            Articulos Articulo = BLL.ArticulosBLL.Buscar(id);


            if (Articulo != null)

            {
                FechaVencimientodateTimePicker.Value = Articulo.FechaVencimiento;
                DescripcionrichTextBox.Text = Articulo.Descripcion;
                PrecionumericUpDown.Value = Articulo.Precio;
                ExistencianumericUpDown.Value = Articulo.Existencia;
                CantidadCotizadonumericUpDown.Value = Articulo.CantidadCotizado;
                
            }
            else
            {
                MessageBox.Show("no encontrado", "Buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}