namespace Entrelinhas.Models
{
    public class Participacao
    {
        public Guid ParticipacaoId { get; set; }

        // Foreign keys
        public long UsuariosId { get; set; }
        public long EventosId { get; set; }

        // Navigation properties
        public Usuario? Usuario { get; set; }
        public Evento? Evento { get; set; }
    }
}
