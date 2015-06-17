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
            foreach (Usuario usu in Sistema.GetInstance().ListaUsuarios)
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
            try
            {
               DialogResult result = MessageBox.Show("Seguro que desea eliminar el usuario "+ Usuario.Nombre + "" + Usuario.Apellido , "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
               if (result == DialogResult.Yes)
               {
                   Sistema.GetInstance().ListaUsuarios.Remove(Usuario);
                   MessageBox.Show("Error usuario se elimino correctamente", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   cmbBoxUsuarios.Items.Clear();
                   foreach (Usuario usu in Sistema.GetInstance().ListaUsuarios)
                   {
                       cmbBoxUsuarios.Items.Add(usu);
                   }
               }
            }
            catch {
                MessageBox.Show("Error al eliminar el usuario seleccionado", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Hide();
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
