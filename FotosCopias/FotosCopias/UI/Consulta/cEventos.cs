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
    public partial class cEventos : Form
    {
        public cEventos()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {

            var lista = new List<Eventos>();
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
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
                        lista = repositorio.GetList(p => p.EventoId == id);
                        break;
                    case 2:
                        lista = repositorio.GetList(p => p.Tipo.Contains(CriteriotextBox.Text));
                        break;

                }
                lista = lista.Where(p => p.Fecha.Date <= desdedateTimePicker.Value && p.Fecha.Date >= hastadateTimePicker.Value).ToList();
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
            List<Eventos> listado = new List<Eventos>();
            EventoReport reporte = new EventoReport(listado);
            reporte.ShowDialog();
        }
    }
}
