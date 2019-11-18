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
        public int EventoId { get; set; }
        public int ArticulosId { get; set; }
        public string Descripcion { get; set; }
        public string Tamaño { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Importe { get; set; }

        public ArticuloDetalle(int detalleArticuloId, int eventoId, int articulosId, string descripcion, string tamaño, int cantidad, decimal precio, decimal importe)
        {
            DetalleArticuloId = detalleArticuloId;
            EventoId = eventoId;
            ArticulosId = articulosId;
            Descripcion = descripcion;
            Tamaño = tamaño;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
