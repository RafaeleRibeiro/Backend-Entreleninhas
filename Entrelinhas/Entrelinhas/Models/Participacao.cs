namespace Entrelinhas.Models
{
    public class Participacao
    {
        public Guid ParticipacaoId { get; set; }

        // Foreign keys
        public Guid UsuariosId { get; set; }
        public Guid EventosId { get; set; }

        // Navigation properties
        public Usuario? Usuario { get; set; }
        public Evento? Evento { get; set; }
    }
}
