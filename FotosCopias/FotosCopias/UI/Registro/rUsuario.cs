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
    public partial class rUsuario : Form
    {
        
        public rUsuario()
        {
            InitializeComponent();
            
        }

        private void Limpiar()
        {
            Myerror.Clear();
            IDusuarionumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            ContraseñatextBox.Text = string.Empty;
            admincheckBox.Checked = false;
            almacencheckBox.Checked = false;
            FechadateTimePicker.Value = DateTime.Now;
        }

        private bool Validar()
        {
            Myerror.Clear();
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                Myerror.SetError(NombretextBox, "El campo nombre no debe estar vacio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ContraseñatextBox.Text))
            {
                Myerror.SetError(ContraseñatextBox, "El campo contraseña no debe estar Vacio");
                paso = false;
            }

            if (admincheckBox.Checked == false && FacturacheckBox.Checked == false && almacencheckBox.Checked == false)
            {
                Myerror.SetError(NivelflowLayoutPanel, "Se debe seleccionar un ragon");
                paso = false;
            }

            if (IDusuarionumericUpDown.Value == 0)
            {
                RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                var listado = new List<Usuarios>();
                listado = repositorio.GetList(p => true);
                string descripcion = NombretextBox.Text;
                foreach (var u in listado)
                {
                    if (descripcion == u.Nombre)
                    {
                        MessageBox.Show("Este Usuario ya está registrado", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        paso = false;
                    }
                }
            }

            return paso;
        }

        private string NivelAcceso()
        {
            string nivel = string.Empty;
            if (admincheckBox.Checked)
                nivel = "Administrador";

            if (FacturacheckBox.Checked)
                nivel = "Facturador";

            if (almacencheckBox.Checked)
                nivel = "Almacen";

            return nivel;
        }

        public string Encriptar(string cadenaEncriptada)
        {
            string resultado = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaEncriptada);
            resultado = Convert.ToBase64String(encryted);

            return resultado;
        }

        public string DesEncriptar(string cadenaDesencriptada)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = Convert.ToInt32(IDusuarionumericUpDown.Value);
            usuarios.Nombre = Convert.ToString(NombretextBox.Text.Trim());
            usuarios.Contraseña = Encriptar(ContraseñatextBox.Text.Trim());
            usuarios.Usuario = NivelAcceso();
            usuarios.FechaIngreso = FechadateTimePicker.Value;

            return usuarios;
        }

        private void LlenarCheckbox(Usuarios usuario)
        {
            if (usuario.Usuario == "Administrador")
                admincheckBox.Checked = true;

            if (usuario.Usuario == "Contador")
                FacturacheckBox.Checked = true;

            if (usuario.Usuario == "Almacen")
               almacencheckBox.Checked = true;
        }

        private void LlenarCampos(Usuarios usuarios)
        {
            IDusuarionumericUpDown.Value = usuarios.UsuarioId;
            NombretextBox.Text = usuarios.Nombre;
            ContraseñatextBox.Text = DesEncriptar(usuarios.Contraseña);
            FechadateTimePicker.Value = usuarios.FechaIngreso;
            LlenarCheckbox(usuarios);
        }


        private bool Existe()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios Usuario = repositorio.Buscar((int)IDusuarionumericUpDown.Value);
            return (Usuario != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios Usuario;
            int id = Convert.ToInt32(IDusuarionumericUpDown.Value);


            Limpiar();
            try
            {
                Usuario = repositorio.Buscar(id);

                if (Usuario != null)
                {
                    LlenarCampos(Usuario);
                    MessageBox.Show("Usuario Encontrado!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario No Encontrado!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo buscar!");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios Usuario;
            bool paso = false;

            if (!Validar())
            {
                return;
            }

            Usuario = LlenaClase();

            if (IDusuarionumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(Usuario);

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No fue posible guardar!!", "Fallo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede Modificar un usuario que no existe", "Fallo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paso = repositorio.Modificar(Usuario);
                Limpiar();
                MessageBox.Show("Se modifico con Exito!!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Eliminarbutton3_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = Convert.ToInt32(IDusuarionumericUpDown.Value);
            Myerror.Clear();

            if (IDusuarionumericUpDown.Value == 0)
            {
                MessageBox.Show("No se puede eliminar este usuario", "Fallo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            Limpiar();
            try
            {
                if (repositorio.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puede eliminar este usuario", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar!");
            }
        }
    }
}
