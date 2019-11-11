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
        public int DetalleArticuloId { get; set; }
        public string DescripcionEvento { get; set; }


        public Eventos()
        {
            EventoId = 0;
            ClienteId = 0;
            DetalleArticuloId = 0;
            DescripcionEvento = string.Empty;
            
        }
    }
}
