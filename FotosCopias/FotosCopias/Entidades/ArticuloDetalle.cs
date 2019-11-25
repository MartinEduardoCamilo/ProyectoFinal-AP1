﻿using System;
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
        public int ClienteId { get; set; }        
        public int ArticulosId { get; set; }
        public int EventoId { get; set; }
        public string Descripcion { get; set; }
        public string Tamaño { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }

        public ArticuloDetalle(int detalleArticuloId, int clienteId, int articulosId, int eventoId, string descripcion, string tamaño, int cantidad, decimal precio, decimal importe, DateTime fecha)
        {
            DetalleArticuloId = detalleArticuloId;
            ClienteId = clienteId;
            ArticulosId = articulosId;
            EventoId = eventoId;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Tamaño = tamaño ?? throw new ArgumentNullException(nameof(tamaño));
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Fecha = fecha;
        }

        public ArticuloDetalle()
        {
        }

        public ArticuloDetalle(int detalleArticuloId, int clienteId, int articulosId, int eventoId, string descripcion, string tamaño, int cantidad, decimal precio, decimal importe)
        {
            DetalleArticuloId = detalleArticuloId;
            ClienteId = clienteId;
            ArticulosId = articulosId;
            EventoId = eventoId;
            Descripcion = descripcion;
            Tamaño = tamaño;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
