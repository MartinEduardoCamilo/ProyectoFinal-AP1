using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class DetalleArticulos
    {
        [Key]
        public int DetalleArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public int ArticulosId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Costo { get; set; }
        public int Precio { get; set; }
        public decimal Tamaño { get; set; }

        public DetalleArticulos(int detalleArticuloId, int usuarioId, int articulosId, string descripcion, int cantidad, int costo, int precio, decimal tamaño)
        {
            DetalleArticuloId = detalleArticuloId;
            UsuarioId = usuarioId;
            ArticulosId = articulosId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Costo = costo;
            Precio = precio;
            Tamaño = tamaño;
        }
    }
}
