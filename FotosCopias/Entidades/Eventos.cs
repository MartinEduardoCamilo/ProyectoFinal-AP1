﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Eventos
    {
        [Key]
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }

        public Eventos(int eventoId, int clienteId, string tipo, string direccion, DateTime fecha)
        {
            EventoId = eventoId;
            ClienteId = clienteId;
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Fecha = fecha;
        }

        public Eventos()
        {
        }
    }
}
