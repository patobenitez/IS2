using System;
using System.Linq;
using System.Windows.Forms;

namespace ObligatorioIS2
{
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var venMenuPpal = new MenuPpal();
            venMenuPpal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Producto productoBuscado = null;
            string condicionDeBusqueda = null;

            if (radioButton1.Checked)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    productoBuscado = Sistema.GetInstance()
                        .ListaProductos
                        .FirstOrDefault(p => p.Nombre.ToUpper().StartsWith(textBox1.Text.ToUpper()));
                }
                condicionDeBusqueda = "nombre";
            }
            else if (radioButton2.Checked)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    productoBuscado = Sistema.GetInstance()
                        .ListaProductos
                        .FirstOrDefault(p => p.Codigo.ToUpper().StartsWith(textBox1.Text.ToUpper()));
                }
                condicionDeBusqueda = "codigo";
            }
            else if (radioButton3.Checked)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    productoBuscado = Sistema.GetInstance()
                        .ListaProductos
                        .FirstOrDefault(p => p.Rubro.ToUpper().StartsWith(textBox1.Text.ToUpper()));
                }
                condicionDeBusqueda = "rubro";
            }
            else if (radioButton4.Checked)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    productoBuscado = Sistema.GetInstance()
                        .ListaProductos
                        .FirstOrDefault(p => p.Tipo.ToUpper().StartsWith(textBox1.Text.ToUpper()));
                }
                condicionDeBusqueda = "tipo";
            }

            Hide();
            var venDetalleProd = new DetalleDeProducto(productoBuscado, condicionDeBusqueda);
            venDetalleProd.Show();
        }
    }
}
