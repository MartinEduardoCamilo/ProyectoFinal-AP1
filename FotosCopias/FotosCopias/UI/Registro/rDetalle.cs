﻿using FotosCopias.BLL;
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
            LlenarClienteCombobox();
            LlenarEventoCombobox();
            LlenarArticuloCombobox();
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
            EventocomboBox.ValueMember = "EventoId";
            EventocomboBox.DisplayMember = "Tipo";
            if(NombrecomboBox.SelectedIndex > 0)
            {
                DateTime fecha = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Fecha;
                FechadateTimePicker.Value = fecha;
            }
            

        }

        private string getCedula()
        {
            string cedula = string.Empty;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            cedula = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Cedula;
            return cedula;
        }

        private DateTime getFecha()
        {
            DateTime fecha = DateTime.Now;
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            fecha = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Fecha;
            return fecha;
        }


        private string getCliente()
        {
            string cliente = string.Empty;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            cliente = repositorio.Buscar((int)NombrecomboBox.SelectedValue).Nombre;
            return cliente;
        }


        private string getEvento()
        {
            string evento = string.Empty;
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            evento = repositorio.Buscar((int)EventocomboBox.SelectedValue).Tipo;
            return evento;
        }



        private void CargarGrid()
        {
            FacturadataGridView.DataSource = null;
            FacturadataGridView.DataSource = this.Detalle;
        }

        private void Limpiar()
        {
            Myerror.Clear();
            FactutaIDnumericUpDown.Value = 0;
            NombrecomboBox.ResetText();
            EventocomboBox.ResetText();
            FechadateTimePicker.Value = DateTime.Now;
            FechaEventodateTimePicker.Value = DateTime.Now;
            this.Detalle = new List<ArticuloDetalle>();
            CargarGrid();
        }

        private void LlenaCampo(Articulos a)
        {
            FactutaIDnumericUpDown.Value = a.ArticulosId;
            NombrecomboBox.Text = getCliente();
            EventocomboBox.Text = getEvento();
            FechaEventodateTimePicker.Value = getFecha();
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

            if (NombrecomboBox.SelectedIndex == -1)
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


            if (string.IsNullOrWhiteSpace(TamañotextBox.Text))
            {
                Myerror.SetError(TamañotextBox, "El campo tamaño no debe estar vacio");
                TamañotextBox.Focus();
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
            LlenarClienteCombobox();
        }  

        private void Eventobutton_Click(object sender, EventArgs e)
        {
            rEventos reventos = new rEventos();
            reventos.ShowDialog();
            LlenarEventoCombobox();
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

            Myerror.Clear();

            if (!Validar())
                return;

            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            int id = repositorio.Buscar((int)ArticuloscomboBox.SelectedValue).ArticulosId;

            RepositorioBase<Eventos> Base = new RepositorioBase<Eventos>();
            int ID = Base.Buscar((int)EventocomboBox.SelectedValue).EventoId;

            decimal total = 0;

       
            this.Detalle.Add(
                new ArticuloDetalle(
                    detalleArticuloId: 0,
                    articulosId: id,
                    eventoId: ID,
                    descripcion: ArticuloscomboBox.Text,
                    tamaño: Convert.ToDecimal(TamañotextBox.Text),
                    cantidad: Convert.ToInt32(CantidadtextBox.Text),
                    precio: Convert.ToDecimal(PreciotextBox.Text),
                    importe: CalcularImporte()

                    )
                );
            CargarGrid();
            ImportetextBox.Text = CalcularImporte().ToString();
            NombrecomboBox.Focus();
            NombrecomboBox.ResetText();
            ArticuloscomboBox.Focus();
            ArticuloscomboBox.ResetText();
            TamañotextBox.Text = Convert.ToString(0);
            PreciotextBox.Text = Convert.ToString(0);
            CantidadtextBox.Text = Convert.ToString(0);
            ImportetextBox.Text = Convert.ToString(0);

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
    }
   
}
