using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteListarNomeHandler(IRepository<Cliente> baseRepository) : IClienteListarNomeHandler<ClienteListarNomeQuery>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;
        
        public List<Cliente> Handle(ClienteListarNomeQuery query)
        {
            return _baseRepository.ListarPor(query.NomeRazaoSocial);
        }
    }
}
