using FotosCopias.BLL;
using FotosCopias.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotosCopias.UI.Registro
{
    public partial class rCliente : Form
    {
        public rCliente()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            Myerror.Clear();
            ClienteIDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            ApellidotextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            NombretextBox.Text = string.Empty;

        }

        private Clientes LlenaClase()
        {
            Clientes c = new Clientes();
            c.ClienteId = (int)ClienteIDnumericUpDown.Value;
            c.Nombre = NombretextBox.Text;
            c.Apellido = ApellidotextBox.Text;
            c.Cedula = CedulamaskedTextBox.Text;
            c.Telefono = TelefonomaskedTextBox.Text;
            c.Email = EmailtextBox.Text;
            c.Direccion = DirecciontextBox.Text;
            return c;
        }

        private void LlenaCampo(Clientes c)
        {
            ClienteIDnumericUpDown.Value = c.ClienteId;
            NombretextBox.Text = c.Nombre;
            ApellidotextBox.Text = c.Apellido;
            CedulamaskedTextBox.Text = c.Cedula;
            TelefonomaskedTextBox.Text = c.Telefono;
            EmailtextBox.Text = c.Email;
            DirecciontextBox.Text = c.Direccion;

        }

        private bool Validar()
        {
            bool paso = true;
            Myerror.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                Myerror.SetError(NombretextBox, "El campo nombre no debe estar vacio!");
                NombretextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ApellidotextBox.Text))
            {
                Myerror.SetError(ApellidotextBox, "El campo apellido no debe estar vacio!");
                ApellidotextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                Myerror.SetError(CedulamaskedTextBox, "El campo cedula no puede estar vacio!");
                CedulamaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text.Replace("-", "")))
            {
                Myerror.SetError(TelefonomaskedTextBox, "El campo teléfono no puede estar vacio!");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                Myerror.SetError(EmailtextBox, "El campo email no puede estar vacio!");
                EmailtextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                Myerror.SetError(DirecciontextBox, "El campo dirección no puede estar vacio!");
                DirecciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool Existe()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = repositorio.Buscar((int)ClienteIDnumericUpDown.Value);
            return (clientes != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();

            int id = (int)ClienteIDnumericUpDown.Value;

            clientes = repositorio.Buscar(id);

            if (clientes != null)
            {
                Limpiar();
                LlenaCampo(clientes);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();

            if (!Validar())
                return;

            clientes = LlenaClase();

            if (ClienteIDnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(clientes);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe este cliente en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(clientes);
            }

            if (paso)
            {
                MessageBox.Show("Cliente Guardar", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int id = ((int)ClienteIDnumericUpDown.Value);
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();

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

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Myerror.Clear();
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                Myerror.SetError(NombretextBox, "Solo se permiten letras");
                NombretextBox.Focus();
                e.Handled = true;
                return;
            }
        }

        private void ApellidotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Myerror.Clear();
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                Myerror.SetError(ApellidotextBox, "Solo se permiten letras");
                ApellidotextBox.Focus();
                e.Handled = true;
                return;
            }
        }

        private  bool ValidarEmail(string Email)
        {
            String Formato;
            Formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(Email, Formato))
            {
                if (Regex.Replace(Email, Formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void EmailtextBox_TextChanged(object sender, EventArgs e)
        {
            Myerror.Clear();
            if(ValidarEmail(EmailtextBox.Text))
            {

            }
            else
            {
                Myerror.SetError(EmailtextBox, "El formato del correo no es valido");
                EmailtextBox.Focus();
            }
        }
    }
}
