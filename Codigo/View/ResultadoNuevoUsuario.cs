using System;
using System.Windows.Forms;

namespace ObligatorioIS2.View
{
    public partial class ResultadoNuevoUsuario : Form
    {
        public ResultadoNuevoUsuario(bool success, string message)
        {
            InitializeComponent();
            label1.Text = message;
            pictureBox1.Image = Helpers.Helpers.GetPathImagen(!success ? "forbidden.png" : "success.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var venEditarUsu = new EditarUsuarios();
            venEditarUsu.Show();
        }
    }
}
