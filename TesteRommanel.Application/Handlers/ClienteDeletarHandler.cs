using TesteRommanel.Application.Commands;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;
using static TesteRommanel.Domain.Entities.BaseEntity;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteDeletarHandler(IRepository<Cliente> baseRepository,
                                       IEventoRepository<IEvento> eventoRepository,
                                       IFactory factory
                                       ) : ICommandHandler<ClienteDeletarCommand>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;
        private readonly IEventoRepository<IEvento> _eventoRepository = eventoRepository;
        private readonly IFactory _factory = factory;

        public bool Handle(ClienteDeletarCommand command)
        {
            var eventos = _eventoRepository.RetornarEventos(command.Id);
            var cliente = _factory.Recriar(eventos);

            cliente ??= _baseRepository.ObterPor(command.Id);

            cliente.Status = (byte)EStatus.Deletado;
            cliente.Id = command.Id;

            bool retorno = _baseRepository.Deletar(cliente);

            if (retorno)
                _eventoRepository.Inserir(cliente.Id, cliente.Events);

            return retorno;
        }
    }
}
