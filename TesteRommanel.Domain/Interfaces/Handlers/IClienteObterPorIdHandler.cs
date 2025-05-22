using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Domain.Interfaces.Handlers
{
    public interface IClienteObterPorIdHandler<TEntity>
    {
        Cliente Handle(TEntity query);
    }
}
