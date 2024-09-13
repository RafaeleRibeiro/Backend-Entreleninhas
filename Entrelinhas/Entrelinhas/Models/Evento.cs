using System;
using System.Collections.Generic;

namespace Entrelinhas.Models
{
    public class Evento
    {
        public Guid EventoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset Data { get; set; }

        // Navigation property
        public ICollection<Participacao> Participacoes { get; set; }
    }
}