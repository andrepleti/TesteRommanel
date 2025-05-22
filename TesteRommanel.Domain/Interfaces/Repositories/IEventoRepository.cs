namespace TesteRommanel.Domain.Interfaces.Repositories
{
    public interface IEventoRepository<TEntity>
    {
        void Inserir(long clienteId, List<TEntity> eventos);

        List<TEntity> RetornarEventos(long clienteId);
    }
}
