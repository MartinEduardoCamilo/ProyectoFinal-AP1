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
    public partial class ClientesReports : Form
    {
        public ClientesReports(List<Clientes>Lista)
        {
            InitializeComponent();
            ClientesCrystalReport1 reporte = new ClientesCrystalReport1();
            reporte.SetDataSource(Lista);
            ClienteView.ReportSource = reporte;
            ClienteView.Refresh();
        }
    }
}
