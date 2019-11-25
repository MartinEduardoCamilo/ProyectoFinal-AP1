using FotosCopias.BLL;
using FotosCopias.Entidades;
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
        private List<Clientes> Listado;
        public cClientes()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            var listado = new List<Clientes>();


            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        listado = repositorio.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = repositorio.GetList(p => p.ClienteId == id);
                        break;
                    case 2:
                        listado = repositorio.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 3:
                        listado = repositorio.GetList(p => p.Apellido.Contains(CriteriotextBox.Text));
                        break;
                    case 4:
                        listado = repositorio.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                        break;
                    case 5:
                        listado = repositorio.GetList(p => p.Email.Contains(CriteriotextBox.Text));
                        break;
                }

            }
            else
            {
                listado = repositorio.GetList(p => true);
            }

            ClientedataGridView.DataSource = null;
            ClientedataGridView.DataSource = listado;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            //if (Listado == null || Listado.Count <= 0)
            //{
            //   errorProvider1.Clear();
            //    errorProvider1.SetError(Imprimirbutton, "No hay datos para imprimir.");
            //    return;
            //}
            //else
            //{
            //    if (Listado.Count > 0)
            //    {
                    ClienteReports reporte = new ClienteReports(Listado);
                    reporte.ShowDialog();
            //    }
            //    else
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(Imprimirbutton, "No hay datos para imprimir.");
            //        return;
            //    }

            //}
        }
    }
}
