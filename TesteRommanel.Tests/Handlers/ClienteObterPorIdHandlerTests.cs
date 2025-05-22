using Moq;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Tests.Handlers
{
    public class ClienteObterPorIdHandlerTests
    {
        private readonly Mock<IEventoRepository<Evento>> _repoMock;
        private readonly Mock<IFactory> _factoryMock;
        private readonly ClienteObterPorIdHandler _handler;

        public ClienteObterPorIdHandlerTests()
        {
            _repoMock = new Mock<IEventoRepository<Evento>>();

            _repoMock.Setup(r => r.RetornarEventos(It.IsAny<long>()));

            _factoryMock = new Mock<IFactory>();

            _factoryMock.Setup(r => r.Recriar(It.IsAny<List<Evento>>()));

            _handler = new ClienteObterPorIdHandler(_repoMock.Object, _factoryMock.Object);
        }

        [Fact]
        public void TestarClienteObterPorIdHandler()
        {
            ClienteObterPorIdQuery query = new(1);

            Cliente cliente = _handler.Handle(query);
            Assert.Equal(string.Empty, cliente.CpfCnpj);
        }
    }
}
