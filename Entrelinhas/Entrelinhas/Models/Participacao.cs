using Entrelinhas.Models;

namespace Entrelinhas.Models
{
    public class Participacao
    {
        public Guid ParticipacaoId { get; set; }

        // Foreign keys
        public Guid UsuarioId { get; set; }
        public Guid EventoId { get; set; }

        // Navigation properties
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
    }
}