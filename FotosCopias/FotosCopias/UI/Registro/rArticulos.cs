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
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            Myerror.Clear();
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CantidadtextBox.Text = string.Empty;
        }

        private Articulos LlenaClase()
        {
            Articulos a = new Articulos();
            a.ArticulosId = (int)IDnumericUpDown.Value;
            a.Descripcion = DescripciontextBox.Text;
            a.Cantidad = Convert.ToInt32(CantidadtextBox.Text);
            return a;
        }

        private void LlenaCampo(Articulos a)
        {
            IDnumericUpDown.Value = a.ArticulosId;
            DescripciontextBox.Text = a.Descripcion;
            CantidadtextBox.Text = a.Cantidad.ToString();
        }

        private bool Validar()
        {
            bool paso = true;

      

            if (string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                Myerror.SetError(DescripciontextBox, "El campo descripción no debe estar vacio");
                DescripciontextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(CantidadtextBox.Text))
            {
                Myerror.SetError(CantidadtextBox, "El campo cantidad no debe estar vació");
                CantidadtextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool Existe()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = repositorio.Buscar((int)IDnumericUpDown.Value);
            return (articulos != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            int id = (int)IDnumericUpDown.Value;

            articulos = repositorio.Buscar(id);

            if (articulos != null)
            {
                Limpiar();
                LlenaCampo(articulos);

            }
            else
            {
                MessageBox.Show("Articulo no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            bool paso;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            if (!Validar())
                return;

            articulos = LlenaClase();

            if (IDnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(articulos);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe este articulo en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(articulos);
            }

            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int id = ((int)IDnumericUpDown.Value);
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();

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
    }
}
