using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Domain.Interfaces.Factories
{
    public interface IFactory
    {
        Cliente Recriar(List<Evento> eventos);
    }
}
