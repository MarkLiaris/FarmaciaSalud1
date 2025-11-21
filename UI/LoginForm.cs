using FarmaciaSalud.Services;
using System;
using System.Windows.Forms;

namespace FarmaciaSalud.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (usuario == "" || pass == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }

            var result = AuthService.LoginAndGetRole(usuario, pass);

            if (result.EmpleadoID > 0)
            {
                // Guardar sesión
                Sesion.EmpleadoID = result.EmpleadoID;
                Sesion.Usuario = usuario;
                Sesion.Puesto = result.Puesto;

                // Abrir menú
                MenuForm menu = new MenuForm(result.EmpleadoID, usuario, result.Puesto);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
