using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ObligatorioIS2.Business_Logic;

namespace ObligatorioIS2.View
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var venGestionUsuarios = new GestionarUsuarios();
            venGestionUsuarios.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateString(textBox1.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Nombre de usuario invalido!");
                venResultadoNuevoUsu.Show();
                return;
            }
            if (!ValidateString(textBox2.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Apellido de usuario invalido!");
                venResultadoNuevoUsu.Show();
                return;
            }
            if (!ValidPassword(textBox3.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Contraseña invalida. Muy corta o no cumple con los requisitos de seguridad.");
                venResultadoNuevoUsu.Show();
                return;
            }
            if (!MatchingPasswords(textBox3.Text, textBox4.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Confirmacion de contraseña invalida");
                venResultadoNuevoUsu.Show();
                return;
            }
            if (!ValidateAddress(textBox5.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Direccion invalida");
                venResultadoNuevoUsu.Show();
                return;
            }
            if (!ValidPhone(textBox6.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Telefono celular invalido");
                venResultadoNuevoUsu.Show();
                return;
            }
            if (!ValidEmailAddress(textBox7.Text))
            {
                Hide();
                var venResultadoNuevoUsu = new ResultadoNuevoUsuario(false, "Mail invalido");
                venResultadoNuevoUsu.Show();
                return;
            }

            var usuario = new Usuario
            {
                Apellido = textBox2.Text,
                Celular = textBox6.Text,
                Nombre = textBox1.Text,
                Direccion = textBox5.Text,
                Email = textBox7.Text,
                Password = textBox3.Text
            };

            Sistema.GetInstance().ListaUsuarios.Add(usuario);

            Hide();
            var venResultadoNuevoUsua = new ResultadoNuevoUsuario(true, "El usuario se ingreso correctamente!");
            venResultadoNuevoUsua.Show();
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
