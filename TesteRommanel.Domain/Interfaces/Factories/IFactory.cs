using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;

namespace TesteRommanel.Domain.Interfaces.Factories
{
    public interface IFactory
    {
        Cliente Recriar(List<IEvento> eventos);
    }
}
