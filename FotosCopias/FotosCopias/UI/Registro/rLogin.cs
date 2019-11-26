using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotosCopias.UI.Registro
{
    public partial class rLogin : Form
    {
        public rLogin()
        {
            InitializeComponent();
        }

        private void Limpiarbutton_Click(object sender, EventArgs e)
        {
            usuariotextBox.Text = string.Empty;
            contraseñatextBox.Text = string.Empty;
        }

        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(usuariotextBox.Text))
            {
                Myerror.SetError(usuariotextBox, "El campo Usuario no puede estar vacío");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(contraseñatextBox.Text))
            {
                Myerror.SetError(contraseñatextBox, "El campo Clave no puede estar vacío");
                paso = false;
            }

            return paso;
        }

        public string DesEncriptar(string cadenaDesencriptada)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }
        int IdUsuario;
        private bool ValidarLogin()
        {
            bool paso = false;

            if (usuariotextBox.Text == "Admin" && contraseñatextBox.Text == "1234")
            {
                paso = true;
            }
            else
            {

                RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                var listado = new List<Usuarios>();
                listado = repositorio.GetList(p => true);
                foreach (var item in listado)
                {
                    if (usuariotextBox.Text == item.Usuario && contraseñatextBox.Text == DesEncriptar(item.Contraseña))
                    {
                        IdUsuario = item.UsuarioId;
                        paso = true;
                        break;
                    }
                }
            }

            return paso;
        }

        private void Ingresarbutton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            if (!ValidarLogin())
            {
                MessageBox.Show("Usuario No Valido", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MainForm main = new MainForm(IdUsuario);
            Hide();
            main.ShowDialog();
            Dispose();
        }
    }
}
