using FotosCopias.BLL;
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
    public partial class rFactura : Form
    {
        public List<ArticuloDetalle> Detalles { get; set; }
        public rFactura()
        {
           
            InitializeComponent();
            this.Detalles = new List<ArticuloDetalle>();
        }

        private void ClienteCombo()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            List<Clientes> lista = new List<Clientes>();
            lista = repositorio.GetList(p => true);
            ClientecomboBox.DataSource = lista;
            ClientecomboBox.ValueMember = "ClienteId";
            ClientecomboBox.DisplayMember = "Nombre";
        }

        private void EventoCombo()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            List<Eventos> lista = new List<Eventos>();
            lista = repositorio.GetList(p => true);
            EventocomboBox.DataSource = lista;
            EventocomboBox.ValueMember = "ClienteId";
            EventocomboBox.DisplayMember = "Tipo";
        }

        private void ArticuloCombo()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> lista = new List<Articulos>();
            lista = repositorio.GetList(p => true);
            ArticuloscomboBox.DataSource = lista;
            ArticuloscomboBox.ValueMember = "ArticulosId";
            ArticuloscomboBox.DisplayMember = "Descripcion";
        }

        private void CargarGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = this.Detalles;
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Visible = false;
            dataGridView.Columns[2].Visible = false;
            dataGridView.Columns[3].Visible = false;

        }

        private void Limpiar()
        {
            Myerror.Clear();
            FacturaIDnumericUpDown.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            ClientecomboBox.Text = string.Empty;
            EventocomboBox.Text = string.Empty;
            ArticuloscomboBox.Text = string.Empty;
            TamañotextBox.Text = string.Empty;
            CantidadtextBox.Text = string.Empty;
            PreciotextBox.Text = string.Empty;
            ImportetextBox.Text = string.Empty;
            TotaltextBox.Text = string.Empty;
            this.Detalles = new List<ArticuloDetalle>();
            CargarGrid();
        }

        public List<ArticuloDetalle> getDetalle(int id)
        {
            id = Convert.ToInt32(FacturaIDnumericUpDown.Value);
            RepositorioBase<ArticuloDetalle> repositorio = new RepositorioBase<ArticuloDetalle>();
            List<ArticuloDetalle> articulos = repositorio.GetList(d => d.DetalleArticuloId == id );
            this.Detalles = articulos;
            CargarGrid();
            return articulos;
        }

        private void LlenaCampo(Articulos a, ArticuloDetalle ad)
        {
            FacturaIDnumericUpDown.Value = a.ArticulosId;
            this.Detalles = a.DetalleArticulos;
            TamañotextBox.Text = ad.Tamaño;
            CantidadtextBox.Text = ad.Cantidad.ToString();
            PreciotextBox.Text = ad.Precio.ToString();
            ImportetextBox.Text = ad.Importe.ToString();
            dateTimePicker1.Value = ad.Fecha;
            CargarGrid();
        }
        private Articulos LlenaClase()
        {
            Articulos a = new Articulos();
            a.ArticulosId = (int)FacturaIDnumericUpDown.Value;
            a.DetalleArticulos = this.Detalles;
            return a;
        }

        private bool Validar()
        {
            bool paso = true;
            Myerror.Clear();
            if (string.IsNullOrWhiteSpace(TamañotextBox.Text))
            {
                Myerror.SetError(TamañotextBox, "No puede estar vacio el campo Tamaño");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CantidadtextBox.Text))
            {
                Myerror.SetError(CantidadtextBox, "No puede estar vacio el campo Cantidad");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                Myerror.SetError(PreciotextBox, "No puede estar vacio el campo Precio");
                paso = false;
            }

            if (this.Detalles.Count == 0)
            {
                Myerror.SetError(dataGridView, "Debe agregar al menos un producto.");
                paso = false;
            }

            if (ClientecomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(ClientecomboBox, "Debes de elegir un cliente");
                paso = false;
            }

            if (ArticuloscomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(ArticuloscomboBox, "Debes de elegir un articulo");
                paso = false;
            }

            if (EventocomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(EventocomboBox, "Debes de elegir un evento");
                paso = false;
            }

            return paso;
        }

        private bool ValidarAgregar()
        {
            Myerror.Clear();
            bool paso = true;

            if (string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                Myerror.SetError(PreciotextBox, "El campo precio no debe estar Vacio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CantidadtextBox.Text))
            {
                Myerror.SetError(CantidadtextBox, "El campo cantidad no debe estar Vacio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TamañotextBox.Text))
            {
                Myerror.SetError(PreciotextBox, "El campo tamaño no debe estar Vacio");
                paso = false;
            }

            if (Convert.ToInt32(PreciotextBox.Text) < 0)
            {
                Myerror.SetError(PreciotextBox, "El campo precio no debe ser negativo");
            }

            if (Convert.ToInt32(CantidadtextBox.Text) < 0)
            {
                Myerror.SetError(CantidadtextBox, "El campo cantidad no debe ser negativo");
            }

            //if (paso)
            //{
            //    foreach (var objeto in this.Detalles)
            //    {
            //        if (objeto.DetalleArticuloId == (int)(ArticuloscomboBox.SelectedValue))
            //        {
            //            Myerror.SetError(ArticuloscomboBox, "Ya existe un articulo");
            //            ArticuloscomboBox.Focus();
            //            return paso = false;
            //        }
            //    }
            //}

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(FacturaIDnumericUpDown.Value);
            Articulos entrada = new Articulos();
            FacturaBLL repositorio = new FacturaBLL();
            entrada = repositorio.Buscar(ID);
            ArticuloDetalle articuloDetalle = new ArticuloDetalle();

            if (entrada != null)
            {
                Limpiar();
                LlenaCampo(entrada,articuloDetalle);
                //getDetalle(ID);
            }
            else
            {
                MessageBox.Show("no encontrada.");
            }
        }

        private Decimal Importe()
        {
            int cantidad = Convert.ToInt32(CantidadtextBox.Text);
            decimal precio = Convert.ToDecimal(PreciotextBox.Text);
            decimal importe = cantidad * precio;
            return importe;
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {

            decimal total = 0;

            if (dataGridView.DataSource != null)
                this.Detalles = (List<ArticuloDetalle>)dataGridView.DataSource;

            if (!ValidarAgregar())
                return;

            

            this.Detalles.Add(new ArticuloDetalle(
                detalleArticuloId: 0,
                clienteId: Convert.ToInt32(ClientecomboBox.SelectedValue),
                articulosId: Convert.ToInt32(FacturaIDnumericUpDown.Value),
                eventoId: Convert.ToInt32(EventocomboBox.SelectedValue), 
                descripcion: ArticuloscomboBox.Text,
                tamaño: TamañotextBox.Text,
                cantidad: Convert.ToInt32(CantidadtextBox.Text),
                precio: Convert.ToDecimal(PreciotextBox.Text),
                importe: Importe()

                ));
            CargarGrid();
            
            foreach (var item in this.Detalles)
            {
                total += Convert.ToDecimal(item.Importe);
            }
            TotaltextBox.Text = Convert.ToString(total);
        }

        private bool ValidaRemover()
        {
            bool paso = true;

            if (dataGridView.SelectedRows == null)
            {
                Myerror.SetError(Removerbutton, "Debe seleccionar al menos una fila.");
                paso = false;
            }

            return paso;
        }

        private void PreciotextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            int cantidad = Convert.ToInt32(CantidadtextBox.Text);
            decimal precio = Convert.ToDecimal(PreciotextBox.Text);
            decimal importe = cantidad * precio;
            ImportetextBox.Text = importe.ToString();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
                return;
            bool paso;
            Articulos entrada;
            FacturaBLL repositorio = new FacturaBLL();

            entrada = LlenaClase();

            if (FacturaIDnumericUpDown.Value == 0)
                paso = repositorio.Guardar(entrada);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede modificar porque no existe en la base de datos",
                           "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(entrada);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "photoStudio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "photoStudio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();

            int id;
            int.TryParse(Convert.ToString(FacturaIDnumericUpDown.Value), out id);

            Articulos articulos = repositorio.Buscar(id);

            Limpiar();

            if (articulos != null)
                repositorio.Eliminar(id);
            else
            {
                Myerror.SetError(FacturaIDnumericUpDown, "No se puede eliminar un articulo que no existe");
            }
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {

        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (!ValidaRemover())
                return;
            if (dataGridView.Rows.Count > 0 && dataGridView.CurrentRow != null)
            {
                Detalles.RemoveAt(dataGridView.CurrentRow.Index);

                CargarGrid();
            }
        }

        private bool Existe()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos a = repositorio.Buscar((int)FacturaIDnumericUpDown.Value);
            return (a != null);
        }

        

        private void rFactura_Load(object sender, EventArgs e)
        {
            ClienteCombo();
            EventoCombo();
            ArticuloCombo();
        }
    }
}
