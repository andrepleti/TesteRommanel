using FluentValidation;
using TesteRommanel.Application.Commands;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteInserirHandler(IRepository<Cliente> baseRepository,
                                       IEventoRepository<IEvento> eventoRepository,
                                         IValidator<Cliente> validator) : ICommandHandler<ClienteInserirCommand>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;
        private readonly IEventoRepository<IEvento> _eventoRepository = eventoRepository;
        private readonly IValidator<Cliente> _validator = validator;

        public bool Handle(ClienteInserirCommand command)
        {
            var cliente = new Cliente(command.NomeRazaoSocial, command.CpfCnpj, command.InscricaoEstadual, command.Isento, command.DataNascimento, command.Telefone, command.Email, command.Tipo,
                                      command.Cep, command.Logradouro, command.Numero, command.Bairro, command.Cidade, command.Estado);

            _validator.ValidateAndThrow(cliente);

            var id = _baseRepository.Inserir(cliente);

            if (id > 0)
            {
                _eventoRepository.Inserir(id, cliente.Events);
                return true;
            }

            return false;
        }
    }
}
