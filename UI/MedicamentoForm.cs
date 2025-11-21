using FarmaciaSalud.Models;
using FarmaciaSalud.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FarmaciaSalud.UI
{
    public partial class MedicamentoForm : Form
    {
        private int currentId = 0;
        public MedicamentoForm()
        {
            InitializeComponent();
        }

        private void MedicamentoForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
            EstadoInicial();
        }

        private void CargarCombos()
        {
            cmbCategoria.DataSource = CategoriaLookupService.GetAll();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.SelectedIndex = -1;

            cmbProveedor.DataSource = ProveedorService.GetAll();
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "Id";
            cmbProveedor.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            dgvMedicamentos.DataSource = MedicamentoService.GetAll();
            dgvMedicamentos.ClearSelection();
        }

        private void EstadoInicial()
        {
            currentId = 0;
            txtCodigoBarra.Clear();
            txtNombre.Clear();
            txtPrincipio.Clear();
            rbtnGen.Checked = true;
            numPrecioCompra.Value = 0;
            numPrecioVenta.Value = 0;
            numStock.Value = 0;
            dtpCaducidad.Value = DateTime.Today.AddMonths(1);
            chkActivo.Checked = true;

            txtCodigoBarra.Enabled = false;
            txtNombre.Enabled = false;
            txtPrincipio.Enabled = false;
            rbtnGen.Enabled = false;
            rbtnPat.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbProveedor.Enabled = false;
            numPrecioCompra.Enabled = false;
            numPrecioVenta.Enabled = false;
            numStock.Enabled = false;
            dtpCaducidad.Enabled = false;
            chkActivo.Enabled = false;

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            currentId = 0;
            txtCodigoBarra.Enabled = true;
            txtNombre.Enabled = true;
            txtPrincipio.Enabled = true;
            rbtnGen.Enabled = true;
            rbtnPat.Enabled = true;
            cmbCategoria.Enabled = true;
            cmbProveedor.Enabled = true;
            numPrecioCompra.Enabled = true;
            numPrecioVenta.Enabled = true;
            numStock.Enabled = true;
            dtpCaducidad.Enabled = true;
            chkActivo.Enabled = true;

            txtCodigoBarra.Focus();

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (currentId == 0) return;

            txtCodigoBarra.Enabled = true;
            txtNombre.Enabled = true;
            txtPrincipio.Enabled = true;
            rbtnGen.Enabled = true;
            rbtnPat.Enabled = true;
            cmbCategoria.Enabled = true;
            cmbProveedor.Enabled = true;
            numPrecioCompra.Enabled = true;
            numPrecioVenta.Enabled = true;
            numStock.Enabled = true;
            dtpCaducidad.Enabled = true;
            chkActivo.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtCodigoBarra.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                numPrecioVenta.Value <= 0)
            {
                MessageBox.Show("Complete código de barra, nombre y precio de venta.");
                return;
            }

            var m = new Medicamento
            {
                MedicamentoID = currentId,
                CodigoBarra = txtCodigoBarra.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                PrincipioActivo = txtPrincipio.Text.Trim(),
                Tipo = rbtnGen.Checked ? 'G' : 'P',
                CategoriaID = cmbCategoria.SelectedIndex >= 0 ? (int?)((dynamic)cmbCategoria.SelectedItem).Id : null,
                ProveedorID = cmbProveedor.SelectedIndex >= 0 ? (int?)((dynamic)cmbProveedor.SelectedItem).Id : null,
                PrecioCompra = numPrecioCompra.Value,
                PrecioVenta = numPrecioVenta.Value,
                Stock = (int)numStock.Value,
                FechaCaducidad = dtpCaducidad.Checked ? (DateTime?)dtpCaducidad.Value.Date : null,
                Activo = chkActivo.Checked
            };

            try
            {
                if (currentId == 0)
                {
                    MedicamentoService.Add(m);
                    MessageBox.Show("Medicamento registrado.");
                }
                else
                {
                    MedicamentoService.Update(m);
                    MessageBox.Show("Medicamento actualizado.");
                }

                CargarGrid();
                EstadoInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (currentId == 0) return;
            if (MessageBox.Show("¿Eliminar medicamento? (soft delete)", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MedicamentoService.Delete(currentId);
                CargarGrid();
                EstadoInicial();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMedicamentos.Rows[e.RowIndex];
            currentId = Convert.ToInt32(row.Cells["MedicamentoID"].Value);
            txtCodigoBarra.Text = row.Cells["CodigoBarra"].Value?.ToString();
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
            txtPrincipio.Text = row.Cells["PrincipioActivo"].Value?.ToString();
            var tipoStr = row.Cells["Tipo"].Value?.ToString();
            rbtnGen.Checked = tipoStr == "G";
            rbtnPat.Checked = tipoStr == "P";
            numPrecioCompra.Value = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);
            numPrecioVenta.Value = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
            numStock.Value = Convert.ToDecimal(row.Cells["Stock"].Value);
            chkActivo.Checked = Convert.ToBoolean(row.Cells["Activo"].Value);
            dtpCaducidad.Value = row.Cells["FechaCaducidad"].Value == DBNull.Value ? DateTime.Today.AddMonths(1) : Convert.ToDateTime(row.Cells["FechaCaducidad"].Value);

            // Categoria/Proveedor
            if (row.Cells["CategoriaID"].Value != DBNull.Value)
            {
                int catId = Convert.ToInt32(row.Cells["CategoriaID"].Value);
                cmbCategoria.SelectedItem = ((List<dynamic>)cmbCategoria.DataSource).Find(x => x.Id == catId);
            }
            else cmbCategoria.SelectedIndex = -1;

            if (row.Cells["ProveedorID"].Value != DBNull.Value)
            {
                int provId = Convert.ToInt32(row.Cells["ProveedorID"].Value);
                cmbProveedor.SelectedItem = ((List<dynamic>)cmbProveedor.DataSource).Find(x => x.Id == provId);
            }
            else cmbProveedor.SelectedIndex = -1;

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string code = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(code)) return;

            var m = MedicamentoService.GetByBarcode(code);
            if (m == null)
            {
                MessageBox.Show("No encontrado.");
                return;
            }

            // Si se quiere, agregar directamente al carrito — aquí sólo seleccionamos en grid
            // Buscar fila y seleccionarla:
            foreach (DataGridViewRow r in dgvMedicamentos.Rows)
            {
                if (r.Cells["CodigoBarra"].Value?.ToString() == code)
                {
                    r.Selected = true;
                    dgvMedicamentos.CurrentCell = r.Cells[0];
                    dgvMedicamentos_CellClick(this, new DataGridViewCellEventArgs(r.Index, 0));
                    break;
                }
            }
            txtBarcode.Clear();
            e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarGrid.Text.Trim();
            if (string.IsNullOrEmpty(texto)) CargarGrid();
            else dgvMedicamentos.DataSource = MedicamentoService.Search(texto);
        }
        private string placeholderBarcode = "Escanea o escribe código y presiona Enter";

        private void SetBarcodePlaceholder()
        {
            txtBarcode.Text = placeholderBarcode;
            txtBarcode.ForeColor = Color.Gray;
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            if (txtBarcode.Text == placeholderBarcode)
            {
                txtBarcode.Text = "";
                txtBarcode.ForeColor = Color.Black;
            }
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                SetBarcodePlaceholder();
            }
        }

    }
}
