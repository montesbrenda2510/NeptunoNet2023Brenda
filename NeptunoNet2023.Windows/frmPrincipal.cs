﻿namespace NeptunoNet2023.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            frmPaises frm = new frmPaises();
            frm.ShowDialog(this);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias frm = new frmCategorias();
            frm.ShowDialog(this);
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            frmCiudades frm = new frmCiudades();
            frm.ShowDialog(this);
        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog(this);
        }
    }
}
