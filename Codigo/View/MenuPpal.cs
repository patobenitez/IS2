﻿using System.Windows.Forms;

namespace ObligatorioIS2.View
{
    public partial class MenuPpal : Form
    {
        public MenuPpal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Hide();
            var venBuscarProd = new BuscarProducto();
            venBuscarProd.Show();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Hide();
            var venLogin = new Login();
            venLogin.Show();         
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
