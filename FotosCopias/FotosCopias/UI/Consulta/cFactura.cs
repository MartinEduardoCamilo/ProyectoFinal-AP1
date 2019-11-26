
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
    public partial class cFactura : Form
    {
        //private List<ArticuloDetalle> Listado;
        public cFactura()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            RepositorioBase<ArticuloDetalle> repositorio = new RepositorioBase<ArticuloDetalle>();
            var listado = new List<ArticuloDetalle>();


            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        listado = repositorio.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = repositorio.GetList(p => p.EventoId == id);
                        break;
                    

                }
                //listado = listado.Where(c => c.).ToList();
            }
            else
            {
                listado = repositorio.GetList(p => true);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listado;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            List<ArticuloDetalle> listado = new List<ArticuloDetalle>();
            FacturaReports reporte = new FacturaReports(listado);
            reporte.ShowDialog();
        }
    }
}
