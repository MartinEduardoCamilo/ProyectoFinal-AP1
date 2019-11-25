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
    public partial class ArticulosReports : Form
    {
        public ArticulosReports(List<Articulos>lista)
        {
            InitializeComponent();
            ArticulosCrystalReport reporte = new ArticulosCrystalReport();
            reporte.SetDataSource(lista);
            ArticuloView.ReportSource = reporte;
            ArticuloView.Refresh();
        }
    }
}
