using NeptunoNet2023.Entidades.Dtos;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;
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
    public partial class frmProductos : Form
    {
        private readonly ServicioProducto _serviciosProducto;
        private List<ProductoDto> listaProducto;
        
        public frmProductos()
        {
            InitializeComponent();
            _serviciosProducto = new ServicioProducto();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                listaProducto = _serviciosProducto.GetProductos();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in listaProducto)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }
    }
}
