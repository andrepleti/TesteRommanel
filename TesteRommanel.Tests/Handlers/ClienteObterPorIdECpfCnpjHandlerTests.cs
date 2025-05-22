using Moq;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Tests.Handlers
{
    public class ClienteObterPorIdECpfCnpjHandlerTests
    {
        private readonly Mock<IRepository<Cliente>> _repoMock;
        private readonly ClienteObterPorIdECpfCnpjHandler _handler;

        public ClienteObterPorIdECpfCnpjHandlerTests()
        {
            _repoMock = new Mock<IRepository<Cliente>>();

            _repoMock.Setup(r => r.VerificarSeExiste(It.IsAny<Cliente>()))
                     .Returns(true);

            _handler = new ClienteObterPorIdECpfCnpjHandler(_repoMock.Object);
        }

        [Fact]
        public void TestarClienteObterPorIdECpfCnpjHandler()
        {
            ClienteObterPorIdECpfCnpjQuery query = new(0, "00993564062");

            bool retorno = _handler.Handle(query);
            Assert.True(retorno);
        }
    }
}
