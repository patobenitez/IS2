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
    public partial class EliminarUsuario : Form
    {
        public Usuario usuario { get; set; }
        public EliminarUsuario()
        {
            InitializeComponent();
            foreach (Usuario usu in Sistema.GetInstance().ListaUsuarios)
            {
                cmbBoxUsuarios.Items.Add(usu);
            }
            usuario = new Usuario();
        }


        private void cmbBoxUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            usuario = (Usuario)cmbBoxUsuarios.SelectedItem;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
               DialogResult result = MessageBox.Show("Seguro que desea eliminar el usuario "+ usuario.Nombre + "" + usuario.Apellido , "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
               if (result == DialogResult.Yes)
               {
                   Sistema.GetInstance().ListaUsuarios.Remove(usuario);
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
