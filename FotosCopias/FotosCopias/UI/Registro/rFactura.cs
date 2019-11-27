using BLL;
using Entidades;
//using FotoStudio.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FotoStudio.UI.Registro
{
    public partial class rFactura : Form
    {
        public List<DetalleFactura> Detalles { get; set; }
        public rFactura()
        {
            InitializeComponent();
            this.Detalles = new List<DetalleFactura>();
        }

        private void Limpiar()
        {
            Myerror.Clear();
            FacturaIDnumericUpDown.Value = 0;
            ClientescomboBox.Text = string.Empty;
            EventoscomboBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            ArticuloscomboBox.Text = string.Empty;
            TamañocomboBox.Text = string.Empty;
            CantidadtextBox.Text = string.Empty;
            PreciotextBox.Text = string.Empty;
            ImportetextBox.Text = string.Empty;
            TotaltextBox.Text = string.Empty;
            Myerror.Clear();
            CargarGrid();
        }

        private string GetCliente(int id)
        {
            string nombre;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();
            clientes = repositorio.Buscar(id);
            if (clientes == null)
                nombre = "";
            else
                nombre = clientes.Nombre;
            return nombre;
        }

        private string GetEvento(int id)
        {
            string nombre;
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = new Eventos();
            eventos = repositorio.Buscar(id);
            if (eventos == null)
                nombre = "";
            else
                nombre = eventos.Tipo;
            return nombre;
        }

        private string GetDescripcion(int id)
        {
            string nombre;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();
            articulos = repositorio.Buscar(id);
            if (articulos == null)
                nombre = "";
            else
                nombre = articulos.Descripcion;
            return nombre;
        }

        private int GetTotalArticulos(int id)
        {
            int cantidad = 0;
            foreach (var item in this.Detalles)
            {
                if (item.ArticulosId == id)
                {
                    cantidad += item.Cantidad;
                }
            }
            return cantidad;
        }

        private int GetCantidadArticulos(int id)
        {
            int cantidad = 0;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();
            articulos = repositorio.Buscar(id);
            if (articulos == null)
                cantidad = 0;
            else
                cantidad = articulos.Cantidad;

            return cantidad;
        }

        private bool ExisteCliente()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            var cliente = repositorio.Buscar((int)ClientescomboBox.SelectedValue);
            return (cliente != null);
        }

        private void CargarComboArticulos()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> lista = new List<Articulos>();
            lista = repositorio.GetList(p => true);
            ArticuloscomboBox.DataSource = lista;
            ArticuloscomboBox.ValueMember = "ArticulosId";
            ArticuloscomboBox.DisplayMember = "Descripcion";
        }

        private void CargarComboCliente()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            List<Clientes> lista = new List<Clientes>();
            lista = repositorio.GetList(p => true);
            ClientescomboBox.DataSource = lista;
            ClientescomboBox.ValueMember = "ClienteId";
            ClientescomboBox.DisplayMember = "Nombre";
        }

        private void CargarComboEventos()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            List<Eventos> lista = new List<Eventos>();
            lista = repositorio.GetList(p => true);
            EventoscomboBox.DataSource = lista;
            
            EventoscomboBox.ValueMember = "ClienteId";
            
            
            EventoscomboBox.DisplayMember = "Tipo";
        }

        private void LlenaCampos(Facturas facturas)
        {
            FacturaIDnumericUpDown.Value = facturas.FacturaId;
            FechadateTimePicker.Value = facturas.Fecha;
            ClientescomboBox.Text = GetCliente(facturas.ClienteId);
            EventoscomboBox.Text = GetEvento(facturas.EventoId);
            TotaltextBox.Text = facturas.Total.ToString();
            this.Detalles = facturas.Detalles;
            CargarGrid();
        }

        private Facturas LlenaClase()
        {
            Facturas facturas = new Facturas();
            facturas.FacturaId = Convert.ToInt32(FacturaIDnumericUpDown.Value);
            facturas.ClienteId = (int)ClientescomboBox.SelectedValue;
            facturas.Fecha = FechadateTimePicker.Value.Date;
            facturas.EventoId = (int)EventoscomboBox.SelectedValue;
            facturas.Total = Convert.ToDecimal(TotaltextBox.Text);

            return facturas;
        }

        private void CargarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = this.Detalles;
        }

        private bool Validar()
        {
            Myerror.Clear();
            bool paso = true;

            if (ClientescomboBox.Text == "" || ClientescomboBox.SelectedIndex == -1 || !ExisteCliente())
            {
                Myerror.SetError(ClientescomboBox, "Debe seleccionar un Cliente");
                paso = false;
            }

            if (this.Detalles.Count == 0)
            {
                Myerror.SetError(Agregarbutton, "Debe agregar al menos un producto.");
                paso = false;
            }

            if (paso)
            {
                foreach (var item in this.Detalles)
                {

                    int cantidad = GetCantidadArticulos(item.ArticulosId);
                    int cantidadDetalle = GetTotalArticulos(item.ArticulosId);
                    int resultado = cantidad - cantidadDetalle;
                    if (resultado < 0)
                    {
                        MessageBox.Show("La cantidad de " + GetDescripcion(item.ArticulosId) + " supera a la existente.", "Isurus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return paso = false;
                    }
                }
            }
            return paso;
        }

        private bool ValidarRemover()
        {
            bool paso = true;
            Myerror.Clear();
            if (dataGridView1.SelectedRows == null)
            {
                Myerror.SetError(Eliminarbutton, "Debe seleccionar al menos una fila.");
                paso = false;
            }

            return paso;
        }

        private bool ValidarAgregar()
        {
            bool paso = true;
            Myerror.Clear();

            if (ArticuloscomboBox.Text == "" || ArticuloscomboBox.SelectedIndex == -1)
            {
                Myerror.SetError(ArticuloscomboBox, "Debe elegir un producto");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                Myerror.SetError(PreciotextBox, "Este campo no puede estar vacio.");
                paso = false;
            }

            if (Convert.ToInt32(CantidadtextBox.Text) <= 0)
            {
                Myerror.SetError(CantidadtextBox, "La cantidad no puede ser cero ni menor que cero.");
                paso = false;
            }

            return paso;
        }

        private bool Existe()
        {
            RepositorioBase<Facturas> repositorio = new RepositorioBase<Facturas>();
            Facturas facturas = repositorio.Buscar((int)FacturaIDnumericUpDown.Value);
            return (facturas != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(FacturaIDnumericUpDown.Value);
            Facturas facturas = new Facturas();
            FacturaBLL repositorio = new FacturaBLL();
            facturas = repositorio.Buscar(ID);

            if (facturas != null)
            {
                Limpiar();
                LlenaCampos(facturas);
            }
            else
            {
                MessageBox.Show("Factura no encontrada.");
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {

            decimal total = 0;
            if (dataGridView1.DataSource != null)
                this.Detalles = (List<DetalleFactura>)dataGridView1.DataSource;
            if (!ValidarAgregar())
                return;
            Detalles.Add(new DetalleFactura(
                detalleFacturaId: 0,
                facturaId: Convert.ToInt32(FacturaIDnumericUpDown.Value),
                articulosId: Convert.ToInt32(ArticuloscomboBox.SelectedValue),
                tamaño: TamañocomboBox.Text,
                precio: Convert.ToDecimal(PreciotextBox.Text),
                importe: Convert.ToDecimal(ImportetextBox.Text)
                ));
            Myerror.Clear();
            CargarGrid();
            foreach (var item in this.Detalles)
            {
                total += Convert.ToDecimal(item.Importe);
            }

            TotaltextBox.Text = Convert.ToString(total);
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (ValidarRemover())
                return;
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                Detalles.RemoveAt(dataGridView1.CurrentRow.Index);

                CargarGrid();
            }
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
            Facturas facturas;
            FacturaBLL repositorio = new FacturaBLL();

            facturas = LlenaClase();

            if (FacturaIDnumericUpDown.Value == 0)
                paso = repositorio.Guardar(facturas);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede modificar porque no existe en la base de datos.",
                           "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(facturas);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!", "Isurus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Isurus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            int id = ((int)FacturaIDnumericUpDown.Value);
            FacturaBLL repositorio = new FacturaBLL();

            if (!Existe())
            {
                MessageBox.Show("No se puede eliminar porque no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                paso = repositorio.Eliminar(id);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo elimina", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {

        }

        private void PreciotextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TamañocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal precio = 0;
            if(TamañocomboBox.SelectedIndex == 0)
            {
               
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }else if(TamañocomboBox.SelectedIndex == 1)
            {
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
            else if (TamañocomboBox.SelectedIndex == 2)
            {
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
            else if (TamañocomboBox.SelectedIndex == 3)
            {
                
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
            else if (TamañocomboBox.SelectedIndex == 4)
            {
               
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
            else if (TamañocomboBox.SelectedIndex == 5)
            {
                
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
            else if (TamañocomboBox.SelectedIndex == 6)
            {
            
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
            else if (TamañocomboBox.SelectedIndex == 7)
            {
                
                PreciotextBox.Text = precio.ToString();
                precio = 0;
            }
        }

        private void rFactura_Load(object sender, EventArgs e)
        {
            CargarComboArticulos();
            CargarComboCliente();
            CargarComboEventos();
        }

        private void CantidadtextBox_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(PreciotextBox.Text) || string.IsNullOrWhiteSpace(CantidadtextBox.Text)))
            {
                if (!(PreciotextBox.Text == "-" || CantidadtextBox.Text == "-"))
                {
                    ImportetextBox.Text = Convert.ToString(Convert.ToDecimal(PreciotextBox.Text) *
                        Convert.ToDecimal(CantidadtextBox.Text));
                }
            }
            else
            {
                if(string.IsNullOrWhiteSpace(ImportetextBox.Text))
                         ImportetextBox.Text = string.Empty;
            }
            
        }
    }
}

