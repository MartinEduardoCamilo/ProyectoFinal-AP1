using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {
       
        [Key]
        public int DetalleFacturaId { get; set; }
        public int FacturaId { get; set; }
        public int ArticulosId { get; set; }
        public string Tamaño { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public virtual Articulos Articulos { get; set; }

        public DetalleFactura()
        {

        }

        public DetalleFactura(int detalleFacturaId, int facturaId, int articulosId, string tamaño, int cantidad, decimal precio, decimal importe, Articulos articulos)
        {
            DetalleFacturaId = detalleFacturaId;
            FacturaId = facturaId;
            ArticulosId = articulosId;
            Tamaño = tamaño ?? throw new ArgumentNullException(nameof(tamaño));
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Articulos = articulos ?? throw new ArgumentNullException(nameof(articulos));
        }

        public DetalleFactura(int detalleFacturaId, int facturaId, int articulosId, string tamaño, decimal precio, decimal importe)
        {
            DetalleFacturaId = detalleFacturaId;
            FacturaId = facturaId;
            ArticulosId = articulosId;
            Tamaño = tamaño;
            Precio = precio;
            Importe = importe;
        }
    }
}
