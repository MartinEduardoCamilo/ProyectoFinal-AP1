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
    public partial class UsuarioReport : Form
    {
        public UsuarioReport(List<Usuarios>lista)
        {
            InitializeComponent();
            UsuarioCrystalReport reporte = new UsuarioCrystalReport();
            reporte.SetDataSource(lista);
            UsuarioView.ReportSource = reporte;
            UsuarioView.Refresh();
        }
    }
}
