namespace FarmaciaSalud.UI
{
    partial class VentaForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvMedicamentos;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.ComboBox cmbPago;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Label lblCarrito;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvMedicamentos = new System.Windows.Forms.DataGridView();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.cmbPago = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblLista = new System.Windows.Forms.Label();
            this.lblCarrito = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();

            this.SuspendLayout();

            // -------------------------------
            // dgvMedicamentos
            // -------------------------------
            this.dgvMedicamentos.Location = new System.Drawing.Point(20, 100);
            this.dgvMedicamentos.Name = "dgvMedicamentos";
            this.dgvMedicamentos.Size = new System.Drawing.Size(500, 300);
            this.dgvMedicamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicamentos.MultiSelect = false;
            this.dgvMedicamentos.ReadOnly = true;
            this.dgvMedicamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // -------------------------------
            // dgvCarrito
            // -------------------------------
            this.dgvCarrito.Location = new System.Drawing.Point(540, 100);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(450, 300);
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.MultiSelect = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // -------------------------------
            // txtBuscar
            // -------------------------------
            this.txtBuscar.Location = new System.Drawing.Point(90, 50);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 26);

            // -------------------------------
            // btnBuscar
            // -------------------------------
            this.btnBuscar.Location = new System.Drawing.Point(400, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 32);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // -------------------------------
            // btnAgregar
            // -------------------------------
            this.btnAgregar.Location = new System.Drawing.Point(20, 410);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 40);
            this.btnAgregar.Text = "Agregar →";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // -------------------------------
            // btnQuitar
            // -------------------------------
            this.btnQuitar.Location = new System.Drawing.Point(540, 410);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(120, 40);
            this.btnQuitar.Text = "← Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);

            // -------------------------------
            // btnFinalizar
            // -------------------------------
            this.btnFinalizar.Location = new System.Drawing.Point(870, 470);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(120, 45);
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);

            // -------------------------------
            // btnCancelar
            // -------------------------------
            this.btnCancelar.Location = new System.Drawing.Point(730, 470);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 45);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // -------------------------------
            // cmbClientes
            // -------------------------------
            this.cmbClientes.Location = new System.Drawing.Point(680, 20);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(200, 28);

            // -------------------------------
            // cmbPago
            // -------------------------------
            this.cmbPago.Location = new System.Drawing.Point(680, 60);
            this.cmbPago.Name = "cmbPago";
            this.cmbPago.Size = new System.Drawing.Size(200, 28);

            // -------------------------------
            // lblTotal
            // -------------------------------
            this.lblTotal.Location = new System.Drawing.Point(540, 470);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 45);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Text = "TOTAL: $0.00";

            // -------------------------------
            // Labels
            // -------------------------------
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Location = new System.Drawing.Point(20, 50);

            this.lblLista.Text = "Medicamentos:";
            this.lblLista.Location = new System.Drawing.Point(20, 80);

            this.lblCarrito.Text = "Carrito:";
            this.lblCarrito.Location = new System.Drawing.Point(540, 80);

            this.lblCliente.Text = "Cliente:";
            this.lblCliente.Location = new System.Drawing.Point(600, 22);

            this.lblPago.Text = "Pago:";
            this.lblPago.Location = new System.Drawing.Point(600, 62);

            // -------------------------------
            // VentaForm
            // -------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.dgvMedicamentos);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.cmbPago);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPago);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lblCarrito);
            this.Name = "VentaForm";
            this.Text = "Módulo de Ventas";
            this.Load += new System.EventHandler(this.VentaForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
