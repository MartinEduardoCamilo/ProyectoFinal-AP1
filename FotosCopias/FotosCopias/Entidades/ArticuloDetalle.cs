using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class ArticuloDetalle
    {
        [Key]
        public int DetalleArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public int ArticulosId { get; set; }
        public string Descripcion { get; set; }
        public decimal Tamaño { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public ArticuloDetalle(int detalleArticuloId, int usuarioId, int eventoId, int articulosId, string descripcion, decimal tamaño, int cantidad, int precio)
        {
            DetalleArticuloId = detalleArticuloId;
            UsuarioId = usuarioId;
            EventoId = eventoId;
            ArticulosId = articulosId;
            Descripcion = descripcion;
            Tamaño = tamaño;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
