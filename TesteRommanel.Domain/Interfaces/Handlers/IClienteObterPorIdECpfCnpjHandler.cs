namespace TesteRommanel.Domain.Interfaces.Handlers
{
    public interface IClienteObterPorIdECpfCnpjHandler<TEntity>
    {
        bool Handle(TEntity query);
    }
}
