using FotosCopias.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotosCopias
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registroDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rArticulos articulos = new rArticulos();
            articulos.MdiParent = this;
            articulos.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rDetalle detalle = new rDetalle();
            detalle.MdiParent = this;
            detalle.Focus();
        }
    }
}
