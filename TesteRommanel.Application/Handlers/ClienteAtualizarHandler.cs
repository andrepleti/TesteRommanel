using FluentValidation;
using TesteRommanel.Application.Commands;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteAtualizarHandler(IRepository<Cliente> baseRepository,
                                         IEventoRepository<Evento> eventoRepository,
                                         IValidator<Cliente> validator,
                                         IFactory factory) : ICommandHandler<ClienteAtualizarCommand>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;
        private readonly IEventoRepository<Evento> _eventoRepository = eventoRepository;
        private readonly IValidator<Cliente> _validator = validator;
        private readonly IFactory _factory = factory;

        public bool Handle(ClienteAtualizarCommand command)
        {
            var eventos = _eventoRepository.RetornarEventos(command.Id);
            Cliente cliente = _factory.Recriar(eventos);

            cliente ??= _baseRepository.ObterPor(command.Id);

            cliente = new Cliente(command.NomeRazaoSocial, command.CpfCnpj, command.InscricaoEstadual, command.Isento, command.DataNascimento, command.Telefone, command.Email, command.Tipo,
                                      command.Cep, command.Logradouro, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Id);

            _validator.ValidateAndThrow(cliente);

            bool retorno = _baseRepository.Atualizar(cliente);

            if (retorno)
                _eventoRepository.Inserir("tualizar", cliente);

            return retorno;
        }
    }
}
