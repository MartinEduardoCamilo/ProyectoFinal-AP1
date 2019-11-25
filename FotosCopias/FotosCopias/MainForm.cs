﻿using FotosCopias.BLL;
using FotosCopias.Entidades;
using FotosCopias.UI.Consulta;
using FotosCopias.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotosCopias
{
    public partial class MainForm : Form
    {
        public int iduser;
        public MainForm(int iduser)
        {
            InitializeComponent();
            this.iduser = iduser;
            MostrarUsuario(iduser);
        }
        public void MostrarUsuario(int id)
        {


            if (id > 0)
            {
                RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                Usuarios usuario = repositorio.Buscar(id);

                
                Nivellabel.Text = usuario.Usuario.ToString();
            }
            else
            {
                
                Nivellabel.Text = "Prueba";
            }

        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registroDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if(Nivellabel.Text == "Almacen")
            rArticulos articulos = new rArticulos();
            articulos.MdiParent = this;
            articulos.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rFactura detalle = new rFactura();
            detalle.MdiParent = this;
            detalle.Show();
        }

        private void registroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCliente cliente = new rCliente();
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void registroEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEventos eventos = new rEventos();
            eventos.MdiParent = this;
            eventos.Show();
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cClientes clientes = new cClientes();
            clientes.MdiParent = this;
            clientes.Show();
        }

        private void consultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cArticulos articulos = new cArticulos();
            articulos.MdiParent = this;
            articulos.Show();
        }

        private void consultarEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEventos eventos = new cEventos();
            eventos.MdiParent = this;
            eventos.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario usuario = new rUsuario();
            usuario.MdiParent = this;
            usuario.Show();
        }
    }
}
