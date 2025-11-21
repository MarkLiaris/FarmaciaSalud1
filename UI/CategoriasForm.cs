using FarmaciaSalud.Services;
using System;
using System.Windows.Forms;

namespace FarmaciaSalud.UI
{
    public partial class CategoriasForm : Form
    {
        private int categoriaID = 0;
        private bool editando = false;

        public CategoriasForm()
        {
            InitializeComponent();
        }

        private void CategoriasForm_Load(object sender, EventArgs e)
        {
            CargarTabla();
            EstadoInicial();
        }

        private void CargarTabla()
        {
            dgvCategorias.DataSource = CategoriaService.Listar();
            dgvCategorias.ClearSelection();
        }

        private void EstadoInicial()
        {
            categoriaID = 0;
            editando = false;

            txtNombre.Clear();
            txtDescripcion.Clear();
            txtBuscar.Clear();

            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;

            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;

            txtNombre.Clear();
            txtDescripcion.Clear();

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            dgvCategorias.ClearSelection();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            editando = true;

            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            if (editando)
                CategoriaService.Actualizar(categoriaID, txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
            else
                CategoriaService.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());

            CargarTabla();
            EstadoInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            if (MessageBox.Show("¿Eliminar categoría?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CategoriaService.Eliminar(categoriaID);
                CargarTabla();
                EstadoInicial();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            categoriaID = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["CategoriaID"].Value);
            txtNombre.Text = dgvCategorias.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = dgvCategorias.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (filtro == "")
            {
                CargarTabla();
                return;
            }

            var lista = CategoriaService.Listar();
            dgvCategorias.DataSource = lista.FindAll(c =>
                c.Nombre.ToLower().Contains(filtro) ||
                c.Descripcion.ToLower().Contains(filtro)
            );
        }
    }
}
