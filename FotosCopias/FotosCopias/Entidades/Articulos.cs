﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticulosId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }       
        public int Cantidad { get; set; }
        public virtual List<DetalleArticulos> ArticuloDetalle { get; set; }

        public Articulos()
        {
            ArticulosId = 0;
            UsuarioId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            ArticuloDetalle = new List<DetalleArticulos>();
        }
    }
}
