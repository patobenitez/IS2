﻿using System;
using System.Windows.Forms;

namespace ObligatorioIS2.View
{
    public partial class GestionarUsuarios : Form
    {
        public GestionarUsuarios()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            var venMenuPpal = new MenuPpal();
            venMenuPpal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var venNuevoUsu = new NuevoUsuario();
            venNuevoUsu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var venEditarUsu = new EditarUsuarios();
            venEditarUsu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var venEliminarUsu = new EliminarUsuario();
            venEliminarUsu.Show();
        }
    }
}
