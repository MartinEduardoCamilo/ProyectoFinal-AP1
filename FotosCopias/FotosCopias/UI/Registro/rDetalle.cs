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
    public partial class rDetalle : Form
    {
        public List<ArticuloDetalle> Detalle { get; set; }

        public rDetalle()
        {
            InitializeComponent();
            this.Detalle = new List<ArticuloDetalle>();
        }


        private void LlenarClienteCombobox()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            List<Clientes> lista = new List<Clientes>();
            lista = repositorio.GetList(p => true);
            NombrecomboBox.DataSource = lista;
            NombrecomboBox.ValueMember = "ClienteId";
            NombrecomboBox.DisplayMember = "Nombre";
            
        }

        private void LlenarArticuloCombobox()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> lista = new List<Articulos>();
            lista = repositorio.GetList(p => true);
            ArticuloscomboBox.DataSource = lista;
            ArticuloscomboBox.ValueMember = "ArticulosId";
            ArticuloscomboBox.DisplayMember = "Descripcion";
        }

        private void LlenarEventoCombobox()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            List<Eventos> lista = new List<Eventos>();
            lista = repositorio.GetList(p => true);
            EventocomboBox.DataSource = lista;
            EventocomboBox.ValueMember = "ClienteId";
            EventocomboBox.DisplayMember = "Tipo";
        }

        private void CargarGrid()
        {
            FacturadataGridView.Rows.Clear();
            var listado = new List<ArticuloDetalle>();
            foreach(var item in listado)
            {
                FacturadataGridView.Rows.Add(item.Descripcion, item.Tamaño, item.Cantidad, item.Precio, item.Importe);
            }
        }

        private void Limpiar()
        {
            Myerror.Clear();
            NombrecomboBox.Text = string.Empty;
            EventocomboBox.Text = string.Empty;
            this.Detalle = new List<ArticuloDetalle>();
            CargarGrid();
        }

        private void LlenaCampo(Articulos a)
        {
            FactutaIDnumericUpDown.Value = a.ArticulosId;
            Detalle = a.ArticuloDetalles;
            CargarGrid();
        }

        private Articulos Llenaclase()
        {
            Articulos articulos = new Articulos();
            articulos.ArticulosId = (int)FactutaIDnumericUpDown.Value;
            articulos.ArticuloDetalles = this.Detalle;
            return articulos;
        }

        private bool Validar()
        {
            bool paso = true;
            Myerror.Clear();

            if (NombrecomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(NombrecomboBox, "Debes de elegir un cliente");
                paso = false;
            }

            if (ArticuloscomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(ArticuloscomboBox, "Debes de elegir un articulo");
                paso = false;
            }

            if(this.Detalle.Count == 0)
            {
               // Myerror.SetError(Agregarbutton, "Debes de agregar un articulo");
                //paso = false;
            }

            return paso;
        }

        private bool validarAgregar()
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

            if(Convert.ToInt32(PreciotextBox.Text) < 0)
            {
                Myerror.SetError(PreciotextBox, "El campo precio no debe ser negativo");
            }

            if (Convert.ToInt32(CantidadtextBox.Text) < 0)
            {
                Myerror.SetError(CantidadtextBox, "El campo cantidad no debe ser negativo");
            }

            return paso;
        }

        private bool ValidaRemover()
        {
            bool paso = true;

            if (FacturadataGridView.SelectedRows == null)
            {
                Myerror.SetError(Removerbutton, "Debe seleccionar al menos una fila.");
                paso = false;
            }

            return paso;
        }

        private bool Existe()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos a = repositorio.Buscar((int)FactutaIDnumericUpDown.Value);
            return (a != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();

            int ID = Convert.ToInt32(FactutaIDnumericUpDown.Value);
            Articulos articulos;

            articulos = repositorio.Buscar(ID);

            Limpiar();

            if (articulos != null)
            {

                LlenaCampo(articulos);
            }
            else
            {
                MessageBox.Show("articulo no encontrada");
            }
        }

        private decimal CalcularImporte()
        {
            int cantidad = Convert.ToInt32(CantidadtextBox.Text);
            decimal precio = Convert.ToDecimal(PreciotextBox.Text);
            decimal importe = cantidad * precio;
            return importe;
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if (FacturadataGridView.DataSource != null)
                this.Detalle = (List<ArticuloDetalle>)FacturadataGridView.DataSource;

            if (!validarAgregar())
                return;

            Myerror.Clear();

            decimal total = 0;
       
            this.Detalle.Add(
                item: new ArticuloDetalle(
                    detalleArticuloId: 0,
                    articulosId: (int)ArticuloscomboBox.SelectedValue,
                    descripcion: ArticuloscomboBox.Text,
                    tamaño: TamañotextBox.Text,
                    cantidad: Convert.ToInt32(CantidadtextBox.Text),
                    precio: Convert.ToDecimal(PreciotextBox.Text),
                    importe: Convert.ToDecimal(ImportetextBox.Text))
                );
            CargarGrid();
            ImportetextBox.Text = CalcularImporte().ToString();
            NombrecomboBox.Focus();
            NombrecomboBox.ResetText();
            ArticuloscomboBox.Focus();
            ArticuloscomboBox.ResetText();
         
            foreach (var item in this.Detalle)
            {
                total += Convert.ToDecimal(item.Importe);
            }

            TotaltextBox.Text = Convert.ToString(total);
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (!ValidaRemover())
                return;
            if (FacturadataGridView.Rows.Count > 0 && FacturadataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(FacturadataGridView.CurrentRow.Index);

                CargarGrid();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();

            bool paso = false;
            Myerror.Clear();

            if (!Validar())
                return;

            Articulos articulos = Llenaclase();

            if (FactutaIDnumericUpDown.Value == 0)
                paso = repositorio.Guardar(articulos);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se encuentra en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paso = repositorio.Modificar(articulos);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Articulo guardada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No fue posible guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();

            int id;
            int.TryParse(Convert.ToString(FactutaIDnumericUpDown.Value), out id);

            Articulos articulos = repositorio.Buscar(id);

            Limpiar();

            if (articulos != null)
                repositorio.Eliminar(id);
            else
            {
                Myerror.SetError(FactutaIDnumericUpDown, "No se puede eliminar un articulo que no existe");
            }
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {

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

        private void CantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool paso = false;
            decimal numero = 0;

            for (int i = 0; i < CantidadtextBox.Text.Length; i++)
            {
                if (CantidadtextBox.Text[i] == '.')
                    paso = true;
                if (paso && numero++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (paso) ? true : false;
            else
                e.Handled = true;
        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool paso = false;
            decimal numero = 0;

            for (int i = 0; i < PreciotextBox.Text.Length; i++)
            {
                if (PreciotextBox.Text[i] == '.')
                    paso = true;
                if (paso && numero++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (paso) ? true : false;
            else
                e.Handled = true;
        }

        private void rDetalle_Load(object sender, EventArgs e)
        {
            LlenarArticuloCombobox();
            LlenarClienteCombobox();
            LlenarEventoCombobox();
        }
    }
   
}
