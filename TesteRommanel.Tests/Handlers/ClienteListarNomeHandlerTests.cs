using Moq;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Tests.Handlers
{
    public class ClienteListarNomeHandlerTests
    {
        private readonly Mock<IRepository<Cliente>> _repoMock;
        private readonly ClienteListarNomeHandler _handler;

        public ClienteListarNomeHandlerTests()
        {
            _repoMock = new Mock<IRepository<Cliente>>();

            _repoMock.Setup(r => r.ListarPor(It.IsAny<string?>()))
                     .Returns([]);

            _handler = new ClienteListarNomeHandler(_repoMock.Object);
        }

        [Fact]
        public void TestarClienteListarNomeHandler()
        {
            ClienteListarNomeQuery query = new("André");

            int tamanho = _handler.Handle(query).Count;
            Assert.Equal(0, tamanho);
        }
    }
}
