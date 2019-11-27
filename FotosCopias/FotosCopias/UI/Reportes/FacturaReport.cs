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
    public partial class FacturaReport : Form
    {

        public FacturaReport(List<DetalleFactura>lista)
        {
            InitializeComponent();
            FacturaCrystalReport reporte = new FacturaCrystalReport();
            reporte.SetDataSource(lista);
            Facturaview.ReportSource = reporte;
            Facturaview.Refresh();
        }
    }
}
