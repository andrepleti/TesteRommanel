using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteObterPorIdHandler(IEventoRepository<Evento> eventoRepository, 
                                          IFactory factory) : IClienteObterPorIdHandler<ClienteObterPorIdQuery>
    {
        private readonly IEventoRepository<Evento> _eventoRepository = eventoRepository;
        private readonly IFactory _factory = factory;

        public Cliente Handle(ClienteObterPorIdQuery query)
        {
            var eventos = _eventoRepository.RetornarEventos(query.Id);
            Cliente cliente = _factory.Recriar(eventos);

            if (cliente is null)
                cliente = new Cliente();

            return cliente;
        }
    }
}
