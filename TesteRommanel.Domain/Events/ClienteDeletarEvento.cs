using TesteRommanel.Domain.Interfaces.Events;
using static TesteRommanel.Domain.Entities.BaseEntity;

namespace TesteRommanel.Domain.Events
{
    public class ClienteDeletarEvento(EStatus status, long id) : IEvento
    {
        public long Id { get; set; } = id;
        public EStatus Status { get; set; } = status;
        public DateTime Data { get; } = DateTime.Now;
    }
}
