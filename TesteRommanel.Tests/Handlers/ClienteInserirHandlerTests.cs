using FluentValidation;
using Moq;
using TesteRommanel.Application.Commands;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Repositories;
using static TesteRommanel.Domain.Entities.Cliente;

namespace TesteRommanel.Tests.Handlers
{
    public class ClienteInserirHandlerTests
    {
        private readonly Mock<IRepository<Cliente>> _repoMock;
        private readonly Mock<IEventoRepository<IEvento>> _repoEventoMock;
        private readonly Mock<IValidator<Cliente>> _validatorMock;
        private readonly ClienteInserirHandler _handler;

        public ClienteInserirHandlerTests()
        {
            _repoMock = new Mock<IRepository<Cliente>>();
            _repoEventoMock = new Mock<IEventoRepository<IEvento>>();
            _validatorMock = new Mock<IValidator<Cliente>>();

            _validatorMock.Setup(v => v.Validate(It.IsAny<Cliente>()))
                          .Returns(new FluentValidation.Results.ValidationResult());

            _repoMock.Setup(r => r.Inserir(It.IsAny<Cliente>()))
                     .Returns(1);

            _repoEventoMock.Setup(r => r.Inserir(It.IsAny<long>(), It.IsAny<List<IEvento>>()));

            _handler = new ClienteInserirHandler(_repoMock.Object, _repoEventoMock.Object, _validatorMock.Object);
        }

        [Fact]
        public void TestarClienteInserirHandler_DeveRetornarTrue()
        {
            var command = new ClienteInserirCommand(
                "André",
                "00993564062",
                string.Empty,
                false,
                new DateTime(1990, 4, 9),
                "14999999999",
                "andre@email.com",
                (byte)ETipoPessoa.Fisica,
                "11111111",
                "Rua Um",
                "11",
                "Centro",
                "Bauru",
                "SP");

            var resultado = _handler.Handle(command);

            Assert.True(resultado);
        }
    }
}
