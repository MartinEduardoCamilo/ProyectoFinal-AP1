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

namespace FotosCopias.UI.Reportes
{
    public partial class ClienteReports : Form
    {
        public ClienteReports(List<Clientes> lista)
        {
            InitializeComponent();
            ClienteReport reporte = new ClienteReport();
            reporte.SetDataSource(lista);
            ClienteView.ReportSource = reporte;
            ClienteView.Refresh();
        }

    }
}
