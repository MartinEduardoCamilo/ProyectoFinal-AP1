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

namespace FotosCopias.UI.Reportes
{
    public partial class EventoReports : Form
    {
        public EventoReports(List<Eventos>lista)
        {
            InitializeComponent();
            EventoCrystalReport reporte = new EventoCrystalReport();
            reporte.SetDataSource(lista);
            Eventoview.ReportSource = reporte;
            Eventoview.Refresh();
        }
    }
}
