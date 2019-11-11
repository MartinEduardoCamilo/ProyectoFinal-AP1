using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        public int DetalleEventoId { get; set; }
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public int ArticulosId { get; set; }
        public int DetalleArticuloId { get; set; }
        public decimal Precio { get; set; }
        public decimal IVA { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public Factura(int facturaId, int detalleEventoId, int eventoId, int clienteId, int articulosId, int detalleArticuloId, decimal precio, decimal iVA, int cantidad, decimal total, DateTime fecha)
        {
            FacturaId = facturaId;
            DetalleEventoId = detalleEventoId;
            EventoId = eventoId;
            ClienteId = clienteId;
            ArticulosId = articulosId;
            DetalleArticuloId = detalleArticuloId;
            Precio = precio;
            IVA = iVA;
            Cantidad = cantidad;
            Total = total;
            Fecha = fecha;
        }
    }
}
