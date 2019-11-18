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
        public ArticuloDetalle(int detalleArticuloId, int articulosId, int eventoId, string descripcion, decimal tamaño, int cantidad, decimal precio, decimal importe)
        {
            DetalleArticuloId = detalleArticuloId;
            ArticulosId = articulosId;
            EventoId = eventoId;
            Descripcion = descripcion;
            Tamaño = tamaño;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

        [Key]
        public int DetalleArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public int ArticulosId { get; set; }
        public string Descripcion { get; set; }
        public decimal Tamaño { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Importe { get; set; }

        
    }
}
