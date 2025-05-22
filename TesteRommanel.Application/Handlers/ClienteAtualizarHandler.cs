using FluentValidation;
using TesteRommanel.Application.Commands;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Application.Handlers
{
    public class ClienteAtualizarHandler(IRepository<Cliente> baseRepository,
                                         IEventoRepository<IEvento> eventoRepository,
                                         IValidator<Cliente> validator,
                                         IFactory factory) : ICommandHandler<ClienteAtualizarCommand>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;
        private readonly IEventoRepository<IEvento> _eventoRepository = eventoRepository;
        private readonly IValidator<Cliente> _validator = validator;
        private readonly IFactory _factory = factory;

        public bool Handle(ClienteAtualizarCommand command)
        {
            var eventos = _eventoRepository.RetornarEventos(command.Id);
            Cliente cliente = _factory.Recriar(eventos);

            cliente ??= _baseRepository.ObterPor(command.Id);

            cliente.NomeRazaoSocial = command.NomeRazaoSocial;
            cliente.CpfCnpj = command.CpfCnpj;
            cliente.InscricaoEstadual = command.InscricaoEstadual;
            cliente.Isento = command.Isento;
            cliente.DataNascimento = command.DataNascimento;
            cliente.Telefone = command.Telefone;
            cliente.Email = command.Email;
            cliente.Tipo = command.Tipo;
            cliente.Cep = command.Cep;
            cliente.Logradouro = command.Logradouro;
            cliente.Numero = command.Numero;
            cliente.Bairro = command.Bairro;
            cliente.Cidade = command.Cidade;
            cliente.Estado = command.Estado;
            cliente.Id = command.Id;

            _validator.ValidateAndThrow(cliente);

            bool retorno = _baseRepository.Atualizar(cliente);

            if (retorno)
                _eventoRepository.Inserir(cliente.Id, cliente.Events);

            return retorno;
        }
    }
}
