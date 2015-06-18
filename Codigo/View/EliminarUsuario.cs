using System;
using System.Windows.Forms;
using ObligatorioIS2.Business_Logic;

namespace ObligatorioIS2.View
{
    public partial class EliminarUsuario : Form
    {
        public Usuario Usuario { get; set; }
        public EliminarUsuario()
        {
            InitializeComponent();
            foreach (var usu in Sistema.GetInstance().ListaUsuarios)
            {
                cmbBoxUsuarios.Items.Add(usu);
            }
            Usuario = new Usuario();
        }


        private void cmbBoxUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Usuario = (Usuario)cmbBoxUsuarios.SelectedItem;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbBoxUsuarios.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario para eliminar");
            }
            else
            {
                try
                {
                    var result =
                        MessageBox.Show(
                            string.Format("Seguro que desea eliminar el usuario {0}{1}", Usuario.Nombre,
                                Usuario.Apellido), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                    Sistema.GetInstance().ListaUsuarios.Remove(Usuario);
                    MessageBox.Show("Error usuario se elimino correctamente", "Eliminar usuario", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    cmbBoxUsuarios.Items.Clear();
                    foreach (var usu in Sistema.GetInstance().ListaUsuarios)
                    {
                        cmbBoxUsuarios.Items.Add(usu);
                    }
                }
                catch
                {
                    MessageBox.Show("Error al eliminar el usuario seleccionado", "Eliminar usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Hide();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
            var ventGestionUsu = new GestionarUsuarios();
            ventGestionUsu.Show();
        }      
    }
}
