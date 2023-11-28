using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;
using NeptunoNet2023.Windows.Helpers;

namespace NeptunoNet2023.Windows
{
    public partial class frmCategorias : Form
    {
        private readonly ServiciosCategorias _serviciosCategorias;
        private List<Categoria> listaCategorias;
        public frmCategorias()
        {
            InitializeComponent();
            _serviciosCategorias = new ServiciosCategorias();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                listaCategorias = _serviciosCategorias.GetAll();
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
            foreach (var item in listaCategorias)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCategoriaAE frm = new frmCategoriaAE(_serviciosCategorias) { Text = "Agregar Categoria" };
            DialogResult dr = frm.ShowDialog(this);
            MostrarDatosEnGrilla();
            //frmCategoriaAE frm = new frmCategoriaAE(_serviciosCategorias);
            //DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            var categoria = frm.GetAll();

            _serviciosCategorias.Guardar(categoria);


            listaCategorias = _serviciosCategorias.GetAll();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {categoria.NombreCategoria} {categoria.Descripcion}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosCategorias.Borrar(categoria.CategoriaId);

            listaCategorias = _serviciosCategorias.GetAll();
            MostrarDatosEnGrilla();
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            Categoria categoriaCopia = (Categoria)categoria.Clone();
            try
            {
                frmCategoriaAE categoriaAE = new frmCategoriaAE(_serviciosCategorias);
                categoriaAE.SetCategoria(categoria);
                DialogResult dr = categoriaAE.ShowDialog();
                if (dr == DialogResult.No)
                {
                    return;
                }
                categoria = categoriaAE.GetAll();
                if (!_serviciosCategorias.Existe(categoria))
                {
                    _serviciosCategorias.Guardar(categoria);
                    GridHelper.SetearFila(r, categoria);
                    MessageBox.Show("Registro editado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GridHelper.SetearFila(r, categoriaCopia);
                    MessageBox.Show("Registro duplicado!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                _serviciosCategorias.Guardar(categoria);
                GridHelper.SetearFila(r, categoria);
               
                MessageBox.Show($"Se edito el cliente {categoria.NombreCategoria} {categoria.Descripcion}"
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                GridHelper.SetearFila(r, categoriaCopia);
                throw;
            }
            
            
        }

      
    }
}
