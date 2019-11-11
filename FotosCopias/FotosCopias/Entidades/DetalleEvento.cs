using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class DetalleEvento
    {
        [Key]
        public int DetalleEventoId { get; set; }
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public string DescripcionEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public string DireccionEvento { get; set; }

        public DetalleEvento(int detalleEventoId, int eventoId, int clienteId, string descripcionEvento, DateTime fechaEvento, string direccionEvento)
        {
            DetalleEventoId = detalleEventoId;
            EventoId = eventoId;
            ClienteId = clienteId;
            DescripcionEvento = descripcionEvento;
            FechaEvento = fechaEvento;
            DireccionEvento = direccionEvento;
        }
    }
}
