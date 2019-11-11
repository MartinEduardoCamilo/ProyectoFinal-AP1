using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.Entidades
{
    public class Eventos
    {
        [Key]
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public string DescripcionEvento { get; set; }

        public Eventos(int eventoId, int clienteId, string descripcionEvento)
        {
            EventoId = eventoId;
            ClienteId = clienteId;
            DescripcionEvento = descripcionEvento;
        }
    }
}
