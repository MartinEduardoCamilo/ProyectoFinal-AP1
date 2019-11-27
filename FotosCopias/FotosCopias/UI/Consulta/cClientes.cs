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
    public partial class cClientes : Form
    {
        public cClientes()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var lista = new List<Clientes>();
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
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
                        lista = repositorio.GetList(p => p.ClienteId == id);
                        break;
                    case 2:
                        lista = repositorio.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 3:
                        lista = repositorio.GetList(p => p.Apellido.Contains(CriteriotextBox.Text));
                        break;
                    case 4:
                        lista = repositorio.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                        break;
                    case 5:
                        lista = repositorio.GetList(p => p.Email.Contains(CriteriotextBox.Text));
                        break;
                }
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
            List<Clientes> listado = new List<Clientes>();
            ClientesReports reporte = new ClientesReports(listado);
            reporte.ShowDialog();
             
        }
    }
}
