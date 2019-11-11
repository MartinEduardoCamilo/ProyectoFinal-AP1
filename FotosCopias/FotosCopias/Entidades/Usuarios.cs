using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            FechaIngreso = DateTime.Now;
        }
    }
}
