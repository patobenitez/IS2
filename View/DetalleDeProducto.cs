using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObligatorioIS2.Business_Logic;

namespace ObligatorioIS2.View
{
    public partial class DetalleDeProducto : Form
    {
        private Producto _producto;
        private string _condicionBuscada;

        public DetalleDeProducto(Producto producto, string condicionBuscada)
        {
            InitializeComponent();
            _producto = producto;
            _condicionBuscada = condicionBuscada;
            CargarDatosProducto();
            CargarSugerencias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var venBuscarProd = new BuscarProducto();
            venBuscarProd.Show();
        }

        private void CargarDatosProducto()
        {
            if (_producto == null)
            {
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
                groupBox4.Hide();
                button2.Hide();
                groupBox5.BringToFront();
                label4.Text = string.Format("No se encontro producto con ese {0}", _condicionBuscada);
                pictureBox5.Image = Helpers.Helpers.GetPathImagen("forbidden.png");
            }
            else
            {
                groupBox5.Hide();
                textBox1.Text = "1";
                label1.Text = string.Format("{0} {1} {2}", _producto.Nombre, _producto.Modelo, _producto.Especificacion);
                label2.Text = string.Format("Codigo: " + " {0} " + "Descripcion: {1}", _producto.Codigo,
                    _producto.Descripcion);
                label3.Text = _producto.Precio;
                pictureBox1.Image = Helpers.Helpers.GetPathImagen(_producto.PathImagen);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
            var precio = _producto.Precio.Split('$');
            label3.Text = string.Format("${0}", (int.Parse(precio[1]) * int.Parse(textBox1.Text)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
            var precio = _producto.Precio.Split('$');
            label3.Text = string.Format("${0}", (int.Parse(precio[1]) * int.Parse(textBox1.Text)));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = textBox1.Text != "0";
        }

        private void CargarSugerencias()
        {
            var resList = new List<string>
            {
                "aspiradora.jpg","heladera.jpg", "lavarropas.jpg", "licuadora.jpg"
            };
            if (_producto != null)
            {
                resList.Remove(_producto.PathImagen);
            }
            pictureBox2.Image = Helpers.Helpers.GetPathImagen(resList[0]);
            pictureBox3.Image = Helpers.Helpers.GetPathImagen(resList[1]);
            pictureBox4.Image = Helpers.Helpers.GetPathImagen(resList[2]);
        }
    }
}
