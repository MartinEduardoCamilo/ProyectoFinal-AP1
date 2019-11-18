using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("EventoId")]
        public virtual Eventos eventos { get; set; }
     
        public int ArticulosId { get; set; }
        [ForeignKey("ArticulosId")]
        public virtual Articulos articulos { get; set; }
        public string Descripcion { get; set; }
        public string Tamaño { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public ArticuloDetalle(int detalleArticuloId, int eventoId, Eventos eventos, int articulosId, Articulos articulos, string descripcion, string tamaño, int cantidad, decimal precio, decimal importe)
        {
            DetalleArticuloId = detalleArticuloId;
            EventoId = eventoId;
            this.eventos = eventos;
            ArticulosId = articulosId;
            this.articulos = articulos;
            Descripcion = descripcion;
            Tamaño = tamaño;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }y

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
