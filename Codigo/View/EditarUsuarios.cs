using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ObligatorioIS2.Business_Logic;

namespace ObligatorioIS2.View
{
    public partial class EditarUsuarios : Form
    {
        public Usuario Usuario { get; set; }

        public EditarUsuarios()
        {
            InitializeComponent();
            foreach (var usu in Sistema.GetInstance().ListaUsuarios) {
                cmbBoxUsuarios.Items.Add(usu);
            }
            
        } 

        private void cmbBoxUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Usuario = (Usuario)cmbBoxUsuarios.SelectedItem;

            txtNombre.Text = Usuario.Nombre;
            txtApellido.Text = Usuario.Apellido;
            txtCelular.Text = Usuario.Celular;
            txtDireccion.Text = Usuario.Direccion;
            txtMail.Text = Usuario.Email;
            txtPass.Text = Usuario.Password;
            txtPassConfir.Text = Usuario.Password;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
            var venGestionUsuarios = new GestionarUsuarios();
            venGestionUsuarios.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbBoxUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario para modificar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!ValidateString(txtNombre.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Nombre de usuario invalido!");
                    venResultadoNuevoUsu.Show();
                    return;
                }
                if (!ValidateString(txtApellido.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Apellido de usuario invalido!");
                    venResultadoNuevoUsu.Show();
                    return;
                }
                if (!ValidPassword(txtPass.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false,
                        "Contraseña invalida. Muy corta o no cumple con los requisitos de seguridad.");
                    venResultadoNuevoUsu.Show();
                    return;
                }
                if (!MatchingPasswords(txtPass.Text, txtPassConfir.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Confirmacion de contraseña invalida");
                    venResultadoNuevoUsu.Show();
                    return;
                }
                if (!ValidateAddress(txtDireccion.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Direccion invalida");
                    venResultadoNuevoUsu.Show();
                    return;
                }
                if (!ValidPhone(txtCelular.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Telefono celular invalido");
                    venResultadoNuevoUsu.Show();
                    return;
                }
                if (!ValidEmailAddress(txtMail.Text))
                {
                    Hide();
                    var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Mail invalido");
                    venResultadoNuevoUsu.Show();
                    return;
                }

                foreach (var usu in Sistema.GetInstance().ListaUsuarios
                    .Where(usu => Usuario.Nombre == usu.Nombre && Usuario.Apellido == usu.Apellido))
                {
                    usu.Nombre = txtNombre.Text;
                    usu.Apellido = txtApellido.Text;
                    usu.Celular = txtCelular.Text;
                    usu.Direccion = txtDireccion.Text;
                    usu.Email = txtMail.Text;
                    usu.Password = txtPass.Text;
                }

                Hide();
                var venResultadoActuUsua = new ResultadoActUsuario(true, "El usuario se actualizo correctamente!");
                venResultadoActuUsua.Show();
            }
        }

        private static bool ValidPhone(string phone)
        {
            return phone.Length == 9 && Regex.IsMatch(phone, "^[0-9]+$");
        }

        private static bool ValidateAddress(string address)
        {
            return Regex.IsMatch(address, "^(?=.*[A-Za-z0-9])[A-Za-z0-9 _]+$");
        }

        private static bool ValidPassword(string password)
        {
            if (password.Length > 7 && password.Length < 15)
            {
                return Regex.IsMatch(password, "^(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$");
            }
            return false;
        }

        private static bool MatchingPasswords(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        private static bool ValidateString(string stringToValidate)
        {
            return Regex.IsMatch(stringToValidate, "^[a-zA-Z _]+$");
        }

        private static bool ValidEmailAddress(string emailAddress)
        {
            if (emailAddress.Length == 0)
            {
                return false;
            }
            if (emailAddress.IndexOf("@", StringComparison.Ordinal) <= -1)
            {
                return false;
            }
            return emailAddress.IndexOf(".", emailAddress.IndexOf("@", StringComparison.Ordinal), StringComparison.Ordinal) > emailAddress.IndexOf("@", StringComparison.Ordinal);
        }

    }
}
