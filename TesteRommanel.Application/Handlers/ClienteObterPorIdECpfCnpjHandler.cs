using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteObterPorIdECpfCnpjHandler(IRepository<Cliente> baseRepository) : IClienteObterPorIdECpfCnpjHandler<ClienteObterPorIdECpfCnpjQuery>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;

        public bool Handle(ClienteObterPorIdECpfCnpjQuery query)
        {
            Cliente cliente = new(query.CpfCnpj, query.Id);

            return _baseRepository.VerificarSeExiste(cliente);
        }
    }
}
