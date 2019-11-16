using FotosCopias.BLL;
using FotosCopias.Entidades;
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
    public partial class rCliente : Form
    {
        RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
        public rCliente()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            Myerror.Clear();
            ClienteIDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            ApellidotextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;

        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
