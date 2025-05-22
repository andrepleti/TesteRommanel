using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Domain.Interfaces.Handlers
{
    public interface IClienteListarNomeHandler<TEntity>
    {
        List<Cliente> Handle(TEntity query);
    }
}
