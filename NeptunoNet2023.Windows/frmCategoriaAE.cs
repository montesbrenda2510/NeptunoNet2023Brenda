using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeptunoNet2023.Windows
{
    public partial class frmCategoriaAE : Form
    {
        private readonly IServicioCategoria _servicio;

        private bool esEdicion = false;
        public frmCategoriaAE(IServicioCategoria servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Categoria categoria;
        internal Categoria GetAll()
        {
            return categoria;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                txtDescripcion.Text = categoria.Descripcion;
                esEdicion = true;
            }
        }

        private void frmCategoriaAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();

                }
                categoria.NombreCategoria = txtCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;
                try
                {

                    if (!_servicio.Existe(categoria))
                    {
                        _servicio.Guardar(categoria);

                        if (!esEdicion)
                        {
                            MessageBox.Show("Registro agregado",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                                "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;

                            }
                            categoria = null;
                            InicializarControles();

                        }
                        else
                        {
                            MessageBox.Show("Registro editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        categoria = null;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            //if (ValidarDatos())
            //{
            //    if (categoria == null)
            //    {
            //        categoria = new Categoria();

            //    }
            //    categoria.NombreCategoria = txtCategoria.Text;
            //    categoria.Descripcion = txtDescripcion.Text;


            //    DialogResult = DialogResult.OK;
            //}
        }
        private void InicializarControles()
        {
            txtCategoria.Clear();
            txtDescripcion.Clear();
            txtCategoria.Focus();
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Debe ingresar una categoria");
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe colocar una descripcion para la categoria ");
            }

            return valido;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void SetCategoria(Categoria categoria)
        {
           this.categoria= categoria;   
        }
    }
}
