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
        public List<ArticuloDetalle> Detalle { get;  set; }

        public rDetalle()
        {
            InitializeComponent();
            this.Detalle = new List<ArticuloDetalle>();
            LLenarClienteCombobox();
            LLenaArticulosCombobox();
        }

        private void CargarGrid()
        {
            FacturadataGridView.DataSource = null;
            FacturadataGridView.DataSource = this.Detalle;
        }

        private void LLenarClienteCombobox()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            List<Clientes> lista = new List<Clientes>();
            lista = repositorio.GetList(p => true);
            NombrecomboBox.DataSource = lista;
            NombrecomboBox.ValueMember = "ClienteId";
            NombrecomboBox.DisplayMember = "Nombre";
        }

        private void LLenaArticulosCombobox()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> lista = new List<Articulos>();
            lista = repositorio.GetList(p => true);
            NombrecomboBox.DataSource = lista;
            NombrecomboBox.ValueMember = "ArticulosId";
            NombrecomboBox.DisplayMember = "Descripcion";
        }

        private string getCedula()
        {
            string cedula = string.Empty;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            cedula = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Cedula;
            return cedula;
        }

        private string getEvento()
        {
            string evento = string.Empty;
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            evento = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Tipo;
            return evento;
        }

        private DateTime getfecha()
        {
            DateTime fecha = DateTime.Now;
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            fecha = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Fecha;
            return fecha;
        }

        private void Limpiar()
        {
            Myerror.Clear();
            FactutaIDnumericUpDown.Value = 0;
            NombrecomboBox.ResetText();
            CedulatextBox.Text = string.Empty;
            EventotextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            FechaEventodateTimePicker.Value = DateTime.Now;
            TamañotextBox.Text = string.Empty;
            PreciotextBox.Text = string.Empty;
            CantidadtextBox.Text = string.Empty;
            ImportetextBox.Text = string.Empty;
            TotaltextBox.Text = string.Empty;
            this.Detalle = new List<ArticuloDetalle>();
            CargarGrid();
        }

        private void LlenaCampo(Articulos a)
        {
            FactutaIDnumericUpDown.Value = a.ArticulosId;
            CedulatextBox.Text = getCedula();
            EventotextBox.Text = getEvento();
            FechadateTimePicker.Value = getfecha();
            this.Detalle = a.ArticuloDetalles;
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

            if(NombrecomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(NombrecomboBox, "Debes de elegir un cliente");
                NombrecomboBox.Focus();
                paso = false;
            }

            if (ArticuloscomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(ArticuloscomboBox, "Debes de elegir un articulo");
                ArticuloscomboBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                Myerror.SetError(PreciotextBox, "El campo precio no debe estar vacio");
                PreciotextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CantidadtextBox.Text))
            {
                Myerror.SetError(CantidadtextBox, "El campo cantidad no debe estar vacio");
                CantidadtextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ImportetextBox.Text))
            {
                Myerror.SetError(ImportetextBox, "El campo importe no debe estar vacio");
                ImportetextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TamañotextBox.Text))
            {
                Myerror.SetError(TamañotextBox, "El campo tamaño no debe estar vacio");
                TamañotextBox.Focus();
                paso = false;
            }

            if (Convert.ToDecimal(PreciotextBox.Text) < 0)
            {
                Myerror.SetError(PreciotextBox, "El campo precio no debe ser menor que cero");
                PreciotextBox.Focus();
                paso = false;
            }

            if (Convert.ToInt32(CantidadtextBox.Text) < 0)
            {
                Myerror.SetError(CantidadtextBox, "El campo cantidad no debe ser menor que cero");
                CantidadtextBox.Focus();
                paso = false;
            }

            if (Convert.ToInt32(ImportetextBox.Text) < 0)
            {
                Myerror.SetError(ImportetextBox, "El campo importe no debe ser menor que cero");
                ImportetextBox.Focus();
                paso = false;
            }

            if (Convert.ToDecimal(TamañotextBox.Text) < 0)
            {
                Myerror.SetError(TamañotextBox, "El campo tamaño no debe ser menor que cero");
                TamañotextBox.Focus();
                paso = false;
            }

            if (this.Detalle.Count == 0)
            {
                Myerror.SetError(Agregarbutton, "Debe agregar por lo menos un cliente");
                Agregarbutton.Focus();
                paso = false;
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

        private void Clientebutton_Click(object sender, EventArgs e)
        {
            rCliente rcliente = new rCliente();
            rcliente.ShowDialog();
            LLenarClienteCombobox();
        }

        private void Eventobutton_Click(object sender, EventArgs e)
        {
            rEventos reventos = new rEventos();
            reventos.ShowDialog();
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            decimal total = 0;

            RepositorioBase<ArticuloDetalle> repositorio = new RepositorioBase<ArticuloDetalle>();
            int id = repositorio.Buscar((int)ArticuloscomboBox.SelectedValue).ArticulosId;

            int ID = repositorio.Buscar((int)ArticuloscomboBox.SelectedValue).EventoId;

            this.Detalle.Add(
                new ArticuloDetalle(
                    articulosId:id,
                    eventoId: ID,
                    descripcion: ArticuloscomboBox.Text,
                    tamaño: TamañotextBox.Text,
                    cantidad: CantidadtextBox.Text,
                    precio: PreciotextBox.Text,
                    importe: ImportetextBox.Text

                    )
                );
            CargarGrid();
            NombrecomboBox.Focus();
            NombrecomboBox.ResetText();
            ArticuloscomboBox.Focus();
            ArticuloscomboBox.ResetText();
            TamañotextBox.Text = string.Empty;
            PreciotextBox.Text = string.Empty;
            CantidadtextBox.Text = string.Empty;
            ImportetextBox.Text = string.Empty;

            foreach (var item in this.Detalle)
            {
                total += Convert.ToDecimal(item.Importe);
            }

            TotaltextBox.Text = Convert.ToString(total);
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
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
    }
}
