using System;
using System.Windows.Forms;

namespace ObligatorioIS2
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUsu = txtUsuario.Text;
            string contraseñaUsu = txtContraseña.Text;
            bool usuarioAuth = false;
            foreach (Usuario usu in Sistema.GetInstance().ListaUsuarios) {
                if (nombreUsu.ToUpper() == usu.Nombre.ToUpper() && contraseñaUsu.ToUpper() == usu.Password.ToUpper()) {
                    usuarioAuth = true;
                }
            }
            if (usuarioAuth)
            {
                var venGestUsu = new GestionarUsuarios();
                venGestUsu.Show();
                Hide();
            }
            else {
                MessageBox.Show("Usuario o clave incorrectas", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
