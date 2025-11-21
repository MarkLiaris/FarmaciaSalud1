// VentaForm.cs completo y funcional
using FarmaciaSalud.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FarmaciaSalud.UI
{
    public partial class VentaForm : Form
    {
        public VentaForm()
        {
            InitializeComponent();
        }

        private void VentaForm_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarMedicamentos();
            CrearCarrito();
            ActualizarTotal();
        }

        // -----------------------------------------------------
        // Cargar lista de clientes
        // -----------------------------------------------------
        private void CargarClientes()
        {
            try
            {
                cmbClientes.DataSource = ClienteService.GetAll();
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "ClienteID";
                cmbClientes.SelectedIndex = -1;

                // Tipos de pago
                cmbPago.Items.Add("EFECTIVO");
                cmbPago.Items.Add("TARJETA");
                cmbPago.Items.Add("TRANSFERENCIA");
                cmbPago.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        // -----------------------------------------------------
        // Cargar Medicamentos al grid
        // -----------------------------------------------------
        private void CargarMedicamentos()
        {
            dgvMedicamentos.DataSource = MedicamentoService.GetAll();
            dgvMedicamentos.ClearSelection();
        }

        // -----------------------------------------------------
        // Crear columnas del carrito
        // -----------------------------------------------------
        private void CrearCarrito()
        {
            dgvCarrito.Columns.Clear();

            dgvCarrito.Columns.Add("MedicamentoID", "ID");
            dgvCarrito.Columns.Add("Nombre", "Medicamento");
            dgvCarrito.Columns.Add("Cantidad", "Cant.");
            dgvCarrito.Columns.Add("PrecioUnitario", "P. Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            dgvCarrito.Columns["Subtotal"].ReadOnly = true;
        }

        // -----------------------------------------------------
        // Botón BUSCAR
        // -----------------------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                CargarMedicamentos();
                return;
            }

            dgvMedicamentos.DataSource = MedicamentoService.Search(texto);
        }

        // -----------------------------------------------------
        // AGREGAR PRODUCTO AL CARRITO
        // -----------------------------------------------------
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un medicamento.");
                return;
            }

            var row = dgvMedicamentos.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["MedicamentoID"].Value);
            string nombre = row.Cells["Nombre"].Value.ToString();
            decimal precio = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);

            int cantidad = 1; // cantidad por defecto

            // Verificar si ya existe en carrito
            foreach (DataGridViewRow r in dgvCarrito.Rows)
            {
                if (!r.IsNewRow && Convert.ToInt32(r.Cells["MedicamentoID"].Value) == id)
                {
                    r.Cells["Cantidad"].Value = Convert.ToInt32(r.Cells["Cantidad"].Value) + 1;
                    r.Cells["Subtotal"].Value = Convert.ToInt32(r.Cells["Cantidad"].Value) * precio;
                    ActualizarTotal();
                    return;
                }
            }

            // Agregar nuevo
            dgvCarrito.Rows.Add(id, nombre, cantidad, precio, cantidad * precio);
            ActualizarTotal();
        }

        // -----------------------------------------------------
        // QUITAR DEL CARRITO
        // -----------------------------------------------------
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto del carrito.");
                return;
            }

            dgvCarrito.Rows.Remove(dgvCarrito.SelectedRows[0]);
            ActualizarTotal();
        }

        // -----------------------------------------------------
        // CALCULAR TOTAL
        // -----------------------------------------------------
        private void ActualizarTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow r in dgvCarrito.Rows)
            {
                if (!r.IsNewRow)
                    total += Convert.ToDecimal(r.Cells["Subtotal"].Value);
            }

            lblTotal.Text = "TOTAL: $" + total.ToString("0.00");
        }

        // -----------------------------------------------------
        // FINALIZAR VENTA
        // -----------------------------------------------------
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("Agrega productos primero.");
                return;
            }

            try
            {
                int empleadoID = Sesion.EmpleadoID;
                int? clienteID = (cmbClientes.SelectedIndex != -1) ? (int?)cmbClientes.SelectedValue : null;
                int? recetaID = null;
                string tipoPago = cmbPago.Text;

                DataTable dtItems = VentaService.CrearTablaItems();

                foreach (DataGridViewRow r in dgvCarrito.Rows)
                {
                    if (r.IsNewRow) continue;
                    dtItems.Rows.Add(
                        Convert.ToInt32(r.Cells["MedicamentoID"].Value),
                        Convert.ToInt32(r.Cells["Cantidad"].Value),
                        Convert.ToDecimal(r.Cells["PrecioUnitario"].Value)
                    );
                }

                int nuevaVentaID = VentaService.RegistrarVenta(
                    empleadoID,
                    clienteID,
                    tipoPago,
                    recetaID,
                    dtItems
                );

                MessageBox.Show("Venta registrada. ID = " + nuevaVentaID);
                LimpiarVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // -----------------------------------------------------
        // LIMPIAR VENTA
        // -----------------------------------------------------
        private void LimpiarVenta()
        {
            dgvCarrito.Rows.Clear();
            cmbClientes.SelectedIndex = -1;
            cmbPago.SelectedIndex = 0;
            ActualizarTotal();
        }

        // -----------------------------------------------------
        // CANCELAR
        // -----------------------------------------------------
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }
    }
}

