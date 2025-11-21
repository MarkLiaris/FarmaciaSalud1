using System;
using System.Windows.Forms;

namespace FarmaciaSalud.UI
{
    public partial class MenuForm : Form
    {
        private int empleadoID;
        private string usuario;
        private string puesto;

        public MenuForm(int empleadoID, string usuario, string puesto)
        {
            InitializeComponent();

            this.empleadoID = empleadoID;
            this.usuario = usuario;
            this.puesto = puesto;

            lblUsuario.Text = $"Usuario: {usuario}";
            lblRol.Text = $"Rol: {puesto}";
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            MedicamentoForm form = new MedicamentoForm();
            form.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            CategoriasForm form = new CategoriasForm();
            form.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresForm form = new ProveedoresForm();
            form.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesForm form = new ClientesForm();
            form.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            VentaForm vf = new VentaForm();
            vf.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.EmpleadoID = 0;
            Sesion.Usuario = null;
            Sesion.Puesto = null;

            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
