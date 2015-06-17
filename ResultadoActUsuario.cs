using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioIS2
{
    public partial class ResultadoActUsuario : Form
    {
        public ResultadoActUsuario(bool success, string message)
        {
            InitializeComponent();
            label1.Text = message;
            pictureBox1.Image = Helpers.GetPathImagen(!success ? "forbidden.png" : "success.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var venActualizoUsu = new EditarUsuarios();
            venActualizoUsu.Show();
        }
    }
}
