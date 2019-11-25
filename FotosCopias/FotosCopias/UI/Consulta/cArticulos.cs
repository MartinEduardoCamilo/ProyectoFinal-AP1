using FotosCopias.BLL;
using FotosCopias.Entidades;
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
        private List<Articulos> listado;
        public cArticulos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            var listado = new List<Articulos>();


            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        listado = repositorio.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = repositorio.GetList(p => p.ArticulosId == id);
                        break;
                    case 2:
                        listado = repositorio.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                    
                }

            }
            else
            {
                listado = repositorio.GetList(p => true);
            }

            ArticulodataGridView.DataSource = null;
            ArticulodataGridView.DataSource = listado;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            ArticulosReports reporte = new ArticulosReports(listado);
            reporte.ShowDialog();
        }
    }
}
