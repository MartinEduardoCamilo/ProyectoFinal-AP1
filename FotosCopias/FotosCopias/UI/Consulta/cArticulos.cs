using BLL;
using Entidades;
using FotosCopias.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotosCopias.UI.Consulta
{
    public partial class cArticulos : Form
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void cArticulos_Load(object sender, EventArgs e)
        {

        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var lista = new List<Articulos>();
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        lista = repositorio.GetList(p => true);
                        break;
                    case 1:
                        int id = 0;
                        id = Convert.ToInt32(CriteriotextBox.Text);
                        lista = repositorio.GetList(p => p.ArticulosId == id);
                        break;
                    case 2:
                        lista = repositorio.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                }
            }
            else
            {
                lista = repositorio.GetList(p => true);
            }
            dataGridView.DataSource = null;
            dataGridView.DataSource = lista;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            List<Articulos> listado = new List<Articulos>();
            ArticuloReport reporte = new ArticuloReport(listado);
            reporte.ShowDialog();
        }
    }
}
