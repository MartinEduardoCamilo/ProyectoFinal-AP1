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

namespace FotosCopias.UI.Registro
{
    public partial class rDetalle : Form
    {
        public List<ArticuloDetalle> detalle { get;  set; }

        public rDetalle()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarGrid()
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = detalle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            this.detalle.Add(
                new ArticuloDetalle(

                    DetalleArticuloId: 1,
                    UsuarioId: 2,
                    EventoId: 3,
                    ArticulosId: 4,
                    Descripcion: 0,
                    Tamaño: 0,
                    Cantidad: 0,
                    Precio: 0
                    
                    ));
            CargarGrid();
        }
    }
}
