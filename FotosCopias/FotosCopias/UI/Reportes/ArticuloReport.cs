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
    public partial class ArticuloReport : Form
    {
        public ArticuloReport(List<Articulos>lista)
        {
            InitializeComponent();
            ArticuloCrystalReport reporte = new ArticuloCrystalReport();
            reporte.SetDataSource(lista);
            ArticuloView.ReportSource = reporte;
            ArticuloView.Refresh();
        }
    }
}
