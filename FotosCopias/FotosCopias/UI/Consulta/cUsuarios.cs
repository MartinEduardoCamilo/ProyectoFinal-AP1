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
    public partial class cUsuarios : Form
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var lista = new List<Usuarios>();
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
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
                        lista = repositorio.GetList(p => p.UsuarioId == id);
                        break;
                    case 2:
                        lista = repositorio.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        break;

                }
                lista = lista.Where(p => p.FechaIngreso.Date <= desdedateTimePicker.Value && p.FechaIngreso.Date >= hastadateTimePicker.Value).ToList();
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
            List<Usuarios> listado = new List<Usuarios>();
            UsuarioReport reporte = new UsuarioReport(listado);
            reporte.ShowDialog();
        }
    }
}
