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
    public partial class rEventos : Form
    {
        public rEventos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            Myerror.Clear();
            EventoIdnumericUpDown.Value = 0;
            ClienteidnumericUpDown.Value = 0;
            TipotextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
        }
        private Eventos LlenaClase()
        {
            Eventos e = new Eventos();
            e.EventoId = (int)EventoIdnumericUpDown.Value;
            e.ClienteId = (int)ClienteidnumericUpDown.Value;
            e.Tipo = TipotextBox.Text;
            e.Direccion = DirecciontextBox.Text;
            e.Fecha = FechadateTimePicker.Value;
            
            return e;
        }

        private void LlenaCampo(Eventos e)
        {
            EventoIdnumericUpDown.Value = e.EventoId;
            ClienteidnumericUpDown.Value = e.ClienteId;
            TipotextBox.Text = e.Tipo;
            DirecciontextBox.Text = e.Direccion;
            FechadateTimePicker.Value = e.Fecha;
        }

        private bool Validar()
        {
            bool paso = true;

           

            if (string.IsNullOrEmpty(TipotextBox.Text))
            {
                Myerror.SetError(TipotextBox, "El campo tipo no debe estar vacio");
                TipotextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(DirecciontextBox.Text))
            {
                Myerror.SetError(DirecciontextBox, "El campo dirección no debe estar vació");
                DirecciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool Existe()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = repositorio.Buscar((int)EventoIdnumericUpDown.Value);
            return (eventos != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = new Eventos();

            int id = (int)EventoIdnumericUpDown.Value;

            eventos = repositorio.Buscar(id);

            if (eventos != null)
            {
                Limpiar();
                LlenaCampo(eventos);
                
            }
            else
            {
                MessageBox.Show("Evento no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = new Eventos();

            if (!Validar())
                return;

            eventos = LlenaClase();

            if (EventoIdnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(eventos);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe este evento en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(eventos);
            }

            if (paso)
            {
                MessageBox.Show("Evento Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            int id = ((int)EventoIdnumericUpDown.Value);
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();

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

        private void ClienteidnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
   
            int id = (int)ClienteidnumericUpDown.Value;

            if(id > 0)
            {
                ClientetextBox.Text = repositorio.Buscar(id).Nombre;
            }
            else
            {
                ClientetextBox.Text = string.Empty;
            }

            
        }
    }
}
