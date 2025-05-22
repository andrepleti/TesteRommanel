using Moq;
using TesteRommanel.Application.Commands;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Repositories;

namespace TesteRommanel.Tests.Handlers
{
    public class ClienteDeletarHandlerTests
    {
        private readonly Mock<IRepository<Cliente>> _repoMock;
        private readonly Mock<IEventoRepository<Evento>> _repoEventoMock;
        private readonly Mock<IFactory> _factoryMock;
        private readonly ClienteDeletarHandler _handler;

        public ClienteDeletarHandlerTests()
        {
            _repoMock = new Mock<IRepository<Cliente>>();
            _repoEventoMock = new Mock<IEventoRepository<Evento>>();
            _factoryMock = new Mock<IFactory>();

            _repoMock.Setup(r => r.Deletar(It.IsAny<Cliente>()))
                     .Returns(true);

            _repoMock.Setup(r => r.ObterPor(It.IsAny<long>()))
                     .Returns(new Cliente());

            _repoEventoMock.Setup(r => r.Inserir(It.IsAny<string>(), It.IsAny<Cliente>()));

            _repoEventoMock.Setup(r => r.RetornarEventos(It.IsAny<long>()));

            _factoryMock.Setup(r => r.Recriar(It.IsAny<List<Evento>>()));

            _handler = new ClienteDeletarHandler(_repoMock.Object, _repoEventoMock.Object, _factoryMock.Object);
        }

        [Fact]
        public void TestarClienteInserirHandler()
        {
            ClienteDeletarCommand command = new(1);

            bool resultado = _handler.Handle(command);
            Assert.True(resultado);
        }
    }
}
