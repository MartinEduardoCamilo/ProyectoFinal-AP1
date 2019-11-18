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
        private string tamaño;
        private string cantidad;
        private string precio;
        private string importe;

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

        public ArticuloDetalle(int detalleArticuloId, int usuarioId, int eventoId, int articulosId, string descripcion, decimal tamaño, int cantidad, decimal precio, decimal importe)
        {
            DetalleArticuloId = detalleArticuloId;
            UsuarioId = usuarioId;
            EventoId = eventoId;
            ArticulosId = articulosId;
            Descripcion = descripcion;
            Tamaño = tamaño;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

        public ArticuloDetalle(int articulosId, int eventoId, string descripcion, string tamaño, string cantidad, string precio, string importe)
        {
            ArticulosId = articulosId;
            EventoId = eventoId;
            Descripcion = descripcion;
            this.tamaño = tamaño;
            this.cantidad = cantidad;
            this.precio = precio;
            this.importe = importe;
        }
    }
}
