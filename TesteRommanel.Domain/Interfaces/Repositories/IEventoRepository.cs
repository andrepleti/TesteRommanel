using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Domain.Interfaces.Repositories
{
    public interface IEventoRepository<TEntity>
    {
        void Inserir(string tipo, Cliente cliente);

        List<TEntity> RetornarEventos(long clienteId);
    }
}
