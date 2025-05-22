using Microsoft.EntityFrameworkCore;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Repositories;
using TesteRommanel.Infra.Data.Context;
using static TesteRommanel.Domain.Entities.BaseEntity;

namespace TesteRommanel.Infra.Data.Repositories
{
    public class ClienteRepository(DataBaseContext db) : IRepository<Cliente>
    {
        protected readonly DataBaseContext _db = db;

        public List<Cliente> ListarPor(string? nome)
        {
            return [.. _db.Set<Cliente>().Where(x => (string.IsNullOrWhiteSpace(nome) ||
                                           x.NomeRazaoSocial.Trim().ToLower().Contains(nome.Trim().ToLower()))
                                        && x.Status == (byte)EStatus.Ativo).OrderBy(x => x.NomeRazaoSocial)];
        }

        public Cliente ObterPor(long id) =>
        _db.Set<Cliente>().Where(x => x.Id == id && x.Status == (byte)EStatus.Ativo)
        .FirstOrDefault()!;

        public bool VerificarSeExiste(Cliente cliente) =>
        _db.Set<Cliente>().Any(x => x.CpfCnpj == cliente.CpfCnpj && x.Id != cliente.Id && x.Status == (byte)EStatus.Ativo);

        public long Inserir(Cliente cliente)
        {
            try
            {
                _db.Entry(cliente).State = EntityState.Added;
                _db.SaveChanges();
                return cliente.Id;
            }
            catch
            {
                return 0;
            }
        }

        public bool Atualizar(Cliente cliente)
        {
            try
            {
                _db.Entry(cliente).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deletar(Cliente cliente)
        {
            Cliente obj = ObterPor(cliente.Id);
            obj.Status = cliente.Status;
            return Atualizar(obj);
        }
    }
}
