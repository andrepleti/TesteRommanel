using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public List<TEntity> ListarPor(string? nome);

        TEntity ObterPor(long id);

        bool VerificarSeExiste(TEntity cliente);

        long Inserir(TEntity cliente);

        bool Atualizar(TEntity cliente);

        bool Deletar(TEntity cliente);
    }
}
