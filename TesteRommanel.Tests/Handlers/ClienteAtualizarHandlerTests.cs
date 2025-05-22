using FluentValidation;
using Moq;
using TesteRommanel.Application.Commands;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Repositories;
using static TesteRommanel.Domain.Entities.Cliente;

namespace TesteRommanel.Tests.Handlers
{
    public class ClienteAtualizarHandlerTests
    {
        private readonly Mock<IRepository<Cliente>> _repoMock;
        private readonly Mock<IEventoRepository<IEvento>> _repoEventoMock;
        private readonly Mock<IValidator<Cliente>> _validatorMock;
        private readonly Mock<IFactory> _factoryMock;
        private readonly ClienteAtualizarHandler _handler;

        public ClienteAtualizarHandlerTests()
        {
            _repoMock = new Mock<IRepository<Cliente>>();
            _repoEventoMock = new Mock<IEventoRepository<IEvento>>();
            _validatorMock = new Mock<IValidator<Cliente>>();
            _factoryMock = new Mock<IFactory>();

            _validatorMock.Setup(v => v.Validate(It.IsAny<Cliente>()))
                          .Returns(new FluentValidation.Results.ValidationResult());

            _repoMock.Setup(r => r.Atualizar(It.IsAny<Cliente>()))
                     .Returns(true);

            _repoMock.Setup(r => r.ObterPor(It.IsAny<long>()))
                     .Returns(new Cliente());

            _repoEventoMock.Setup(r => r.Inserir(It.IsAny<long>(), It.IsAny<List<IEvento>>()));

            _repoEventoMock.Setup(r => r.RetornarEventos(It.IsAny<long>()));

            _factoryMock.Setup(r => r.Recriar(It.IsAny<List<IEvento>>()));

            _handler = new ClienteAtualizarHandler(_repoMock.Object, _repoEventoMock.Object, _validatorMock.Object, _factoryMock.Object);
        }

        [Fact]
        public void TestarClienteAtualizarHandler()
        {
            ClienteAtualizarCommand command = new(1, "André", "00993564062", string.Empty, false, Convert.ToDateTime("09/04/1990"), "14999999999",
                                  "andre@email.com", (byte)ETipoPessoa.Fisica, "11111111", "Rua Um", "11", "Centro", "Bauru", "SP");

            bool resultado = _handler.Handle(command);
            Assert.True(resultado);
        }
    }
}
