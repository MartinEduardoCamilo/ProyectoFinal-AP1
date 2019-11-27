using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticulosId { get; set; }
        public string Descripcion { get; set; }       
        public int Cantidad { get; set; }
        public Articulos()
        {
            ArticulosId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
        }

        public Articulos(int articulosId, string descripcion, int cantidad)
        {
            ArticulosId = articulosId;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Cantidad = cantidad;
        }
    }
}
