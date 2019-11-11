using FotosCopias.BLL;
using FotosCopias.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
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

        private bool Validar()
        {
            bool paso = true;
            Myerror.Clear();
            if (string.IsNullOrWhiteSpace(NametextBox.Text))
            {
                Myerror.SetError(NametextBox, "El campo nombre no debe estar vació");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ConstaseñatextBox.Text))
            {
                Myerror.SetError(ConstaseñatextBox, "El campo contraseña no debe estar vació");
                paso = false;
            }
            return paso;
        }

        private void Ingresarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            Limpiar();
            RepositorioBase<Usuarios> repositorioBase = new  RepositorioBase<Usuarios>();
            Expression<Func<Usuarios, bool>> restriccion = x => true;
            string contraseña = ConstaseñatextBox.Text;
            string Nombre = NametextBox.Text;
            restriccion = x => x.NombreUsuario.Equals(Nombre);
            List<Usuarios> usuarios = repositorioBase.GetList(restriccion);
            
            if(usuarios.Count > 0)
            {
                if (usuarios.Exists(x => x.NombreUsuario.Equals(Nombre))){
                    if(usuarios.Exists(x=>x.Contraseña.Equals(contraseña)))
                    {
                        this.Close();
                        Form main = new MainForm();
                        main.Show();
                    }
                    else
                    {
                        Limpiar();
                        MessageBox.Show("Contraseña incorrecta!! o Usuario incorrecto","Foto Estudio" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                repositorioBase.Guardar(
                    new Usuarios()
                    {
                        NombreUsuario = "Admin",
                        Contraseña = "123456",
                        FechaIngreso = DateTime.Now.Date
                    }
                    ) ; ;
            }
        }

        private void Limpiar()
        {
            NametextBox.Text = string.Empty;
            ConstaseñatextBox.Text = string.Empty;
        }
    }
}
