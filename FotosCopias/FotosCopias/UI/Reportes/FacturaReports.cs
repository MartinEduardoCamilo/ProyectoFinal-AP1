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
    public partial class FacturaReports : Form
    {    
        public FacturaReports(List<ArticuloDetalle> lista)
        {
           InitializeComponent();
           FacturaCrystalReport reporte = new FacturaCrystalReport();
           reporte.SetDataSource(lista);
           FacturaView.ReportSource = reporte;
           FacturaView.Refresh();
        }
    }
}
