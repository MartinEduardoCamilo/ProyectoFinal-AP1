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
    public partial class cEventos : Form
    {
        private List<Eventos> Listado;
        public cEventos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            var listado = new List<Eventos>();


            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        listado = repositorio.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = repositorio.GetList(p => p.EventoId == id);
                        break;
                    case 2:
                        listado = repositorio.GetList(p => p.Tipo.Contains(CriteriotextBox.Text));
                        break;

                }
                listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = repositorio.GetList(p => true);
            }

            EventodataGridView.DataSource = null;
            EventodataGridView.DataSource = listado;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            EventoReports reporte = new EventoReports(Listado);
            reporte.ShowDialog();
        }
    }
}
