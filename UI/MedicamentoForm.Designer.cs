namespace FarmaciaSalud.UI
{
    partial class MedicamentoForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrincipio;
        private System.Windows.Forms.RadioButton rbtnGen;
        private System.Windows.Forms.RadioButton rbtnPat;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.NumericUpDown numPrecioCompra;
        private System.Windows.Forms.NumericUpDown numPrecioVenta;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.DateTimePicker dtpCaducidad;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.DataGridView dgvMedicamentos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.TextBox txtBuscarGrid;
        private System.Windows.Forms.Button btnBuscar;

        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrincipio;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblCaducidad;
        private System.Windows.Forms.Label lblActivo;
        private System.Windows.Forms.Label lblBuscar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrincipio = new System.Windows.Forms.TextBox();
            this.rbtnGen = new System.Windows.Forms.RadioButton();
            this.rbtnPat = new System.Windows.Forms.RadioButton();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.numPrecioCompra = new System.Windows.Forms.NumericUpDown();
            this.numPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.dtpCaducidad = new System.Windows.Forms.DateTimePicker();
            this.chkActivo = new System.Windows.Forms.CheckBox();

            this.dgvMedicamentos = new System.Windows.Forms.DataGridView();

            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.txtBuscarGrid = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();

            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrincipio = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblCaducidad = new System.Windows.Forms.Label();
            this.lblActivo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).BeginInit();
            this.SuspendLayout();


            // -------------------------
            // Barcode text (buscador)
            // -------------------------
            this.lblBarcode.Text = "Buscar por código:";
            this.lblBarcode.Location = new System.Drawing.Point(20, 10);

            this.txtBarcode.Location = new System.Drawing.Point(150, 8);
            this.txtBarcode.Size = new System.Drawing.Size(250, 20);
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);


            // -------------------------
            // Código de barras
            // -------------------------
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.Location = new System.Drawing.Point(20, 50);

            this.txtCodigoBarra.Location = new System.Drawing.Point(150, 47);
            this.txtCodigoBarra.Size = new System.Drawing.Size(250, 20);


            // -------------------------
            // Nombre
            // -------------------------
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(20, 90);

            this.txtNombre.Location = new System.Drawing.Point(150, 87);
            this.txtNombre.Size = new System.Drawing.Size(250, 20);


            // -------------------------
            // Principio Activo
            // -------------------------
            this.lblPrincipio.Text = "Principio activo:";
            this.lblPrincipio.Location = new System.Drawing.Point(20, 130);

            this.txtPrincipio.Location = new System.Drawing.Point(150, 127);
            this.txtPrincipio.Size = new System.Drawing.Size(250, 20);


            // -------------------------
            // Tipo (G/P)
            // -------------------------
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new System.Drawing.Point(20, 170);

            this.rbtnGen.Text = "Genérico";
            this.rbtnGen.Location = new System.Drawing.Point(150, 168);

            this.rbtnPat.Text = "Patente";
            this.rbtnPat.Location = new System.Drawing.Point(250, 168);


            // -------------------------
            // Categoría y proveedor
            // -------------------------
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.Location = new System.Drawing.Point(20, 210);

            this.cmbCategoria.Location = new System.Drawing.Point(150, 207);
            this.cmbCategoria.Size = new System.Drawing.Size(250, 21);

            this.lblProveedor.Text = "Proveedor:";
            this.lblProveedor.Location = new System.Drawing.Point(20, 250);

            this.cmbProveedor.Location = new System.Drawing.Point(150, 247);
            this.cmbProveedor.Size = new System.Drawing.Size(250, 21);


            // -------------------------
            // Precios
            // -------------------------
            this.lblPrecioCompra.Text = "Precio compra:";
            this.lblPrecioCompra.Location = new System.Drawing.Point(450, 50);

            this.numPrecioCompra.DecimalPlaces = 2;
            this.numPrecioCompra.Maximum = 1000000;
            this.numPrecioCompra.Location = new System.Drawing.Point(580, 47);

            this.lblPrecioVenta.Text = "Precio venta:";
            this.lblPrecioVenta.Location = new System.Drawing.Point(450, 90);

            this.numPrecioVenta.DecimalPlaces = 2;
            this.numPrecioVenta.Maximum = 1000000;
            this.numPrecioVenta.Location = new System.Drawing.Point(580, 87);


            // -------------------------
            // Stock
            // -------------------------
            this.lblStock.Text = "Stock:";
            this.lblStock.Location = new System.Drawing.Point(450, 130);

            this.numStock.Maximum = 1000000;
            this.numStock.Location = new System.Drawing.Point(580, 127);


            // -------------------------
            // Caducidad
            // -------------------------
            this.lblCaducidad.Text = "Caducidad:";
            this.lblCaducidad.Location = new System.Drawing.Point(450, 170);

            this.dtpCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaducidad.Location = new System.Drawing.Point(580, 167);


            // -------------------------
            // Activo
            // -------------------------
            this.lblActivo.Text = "Activo:";
            this.lblActivo.Location = new System.Drawing.Point(450, 210);

            this.chkActivo.Location = new System.Drawing.Point(580, 210);


            // -------------------------
            // GRID
            // -------------------------
            this.dgvMedicamentos.Location = new System.Drawing.Point(20, 350);
            this.dgvMedicamentos.Size = new System.Drawing.Size(850, 220);
            this.dgvMedicamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicamentos_CellClick);


            // -------------------------
            // Botones
            // -------------------------
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(20, 300);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(120, 300);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(220, 300);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(320, 300);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(420, 300);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);


            // -------------------------
            // Buscador del grid
            // -------------------------
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Location = new System.Drawing.Point(20, 320);

            this.txtBuscarGrid.Location = new System.Drawing.Point(80, 317);
            this.txtBuscarGrid.Size = new System.Drawing.Size(200, 20);

            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.Location = new System.Drawing.Point(290, 315);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);


            // -------------------------
            // Form
            // -------------------------
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcode);

            this.Controls.Add(this.txtCodigoBarra);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtPrincipio);
            this.Controls.Add(this.rbtnGen);
            this.Controls.Add(this.rbtnPat);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.numPrecioCompra);
            this.Controls.Add(this.numPrecioVenta);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.dtpCaducidad);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.dgvMedicamentos);

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);

            this.Controls.Add(this.txtBuscarGrid);
            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblPrincipio);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.lblPrecioCompra);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblCaducidad);
            this.Controls.Add(this.lblActivo);
            this.Controls.Add(this.lblBuscar);

            this.Name = "MedicamentoForm";
            this.Text = "Gestión de Medicamentos";
            this.Load += new System.EventHandler(this.MedicamentoForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
