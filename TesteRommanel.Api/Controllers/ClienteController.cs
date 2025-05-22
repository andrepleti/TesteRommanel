using Microsoft.AspNetCore.Mvc;
using TesteRommanel.Application.Commands;
using TesteRommanel.Application.Queries;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Handlers;
using static TesteRommanel.Domain.Entities.Cliente;

namespace TesteRommanel.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController(
        IClienteListarNomeHandler<ClienteListarNomeQuery> listarHandler,
        IClienteObterPorIdHandler<ClienteObterPorIdQuery> obterHandler,
        IClienteObterPorIdECpfCnpjHandler<ClienteObterPorIdECpfCnpjQuery> obterPorIdECpfCnpjHandler,
        ICommandHandler<ClienteInserirCommand> inserirHandler,
        ICommandHandler<ClienteAtualizarCommand> atualizarHandler,
        ICommandHandler<ClienteDeletarCommand> deletarHandler
        ) : BaseController
    {
        private readonly IClienteListarNomeHandler<ClienteListarNomeQuery> _listarHandler = listarHandler;
        private readonly IClienteObterPorIdHandler<ClienteObterPorIdQuery> _obterHandler = obterHandler;
        private readonly IClienteObterPorIdECpfCnpjHandler<ClienteObterPorIdECpfCnpjQuery> _obterPorIdECpfCnpjHandler = obterPorIdECpfCnpjHandler;
        private readonly ICommandHandler<ClienteInserirCommand> _inserirHandler = inserirHandler;
        private readonly ICommandHandler<ClienteAtualizarCommand> _atualizarHandler = atualizarHandler;
        private readonly ICommandHandler<ClienteDeletarCommand> _deletarHandler = deletarHandler;

        [HttpGet]
        public IActionResult ListarPor(string? nome)
        {
            try
            {
                var lista = _listarHandler.Handle(new ClienteListarNomeQuery(nome));
                return lista is null ? InformarSeNaoEncontrado("Lista de clientes") : Ok(lista);
            }
            catch
            {
                return InformarSeNaoEncontrado(nameof(Cliente));
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPor(long id)
        {
            try
            {
                if (id == 0)
                    return Ok(new Cliente());

                var cliente = _obterHandler.Handle(new ClienteObterPorIdQuery(id));
                return cliente is null ? InformarSeNaoEncontrado("Cliente") : Ok(cliente);
            }
            catch
            {
                return InformarSeNaoEncontrado(nameof(Cliente));
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ClienteInserirCommand command)
        {
            try
            {
                if (command == null)
                    return InformarSeNaoEncontrado(nameof(Cliente));

                if (_obterPorIdECpfCnpjHandler.Handle(new ClienteObterPorIdECpfCnpjQuery(0, command.CpfCnpj)))
                    return InformarSeJaExiste(nameof(Cliente), command.Tipo == (byte)ETipoPessoa.Fisica ? "CPF" : "CNPJ");

                if (_inserirHandler.Handle(command))
                    return InformarSeAcaoRealizadaSucesso("cadastrado", nameof(Cliente));
                else
                    return InformarSeNaoFoiPossivel("cadastrar", nameof(Cliente));
            }
            catch (Exception erro)
            {
                return BadRequest(new { Mensagem = erro.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ClienteAtualizarCommand command)
        {
            try
            {
                if (command == null)
                    return InformarSeNaoEncontrado(nameof(Cliente));

                if (_obterPorIdECpfCnpjHandler.Handle(new ClienteObterPorIdECpfCnpjQuery(command.Id, command.CpfCnpj)))
                    return InformarSeJaExiste(nameof(Cliente), command.Tipo == (byte)ETipoPessoa.Fisica ? "CPF" : "CNPJ");

                if (_atualizarHandler.Handle(command))
                    return InformarSeAcaoRealizadaSucesso("atualizado", nameof(Cliente));
                else
                    return InformarSeNaoFoiPossivel("atualizar", nameof(Cliente));
            }
            catch (Exception erro)
            {
                return BadRequest(new { Mensagem = erro.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            try
            {
                if (id == 0)
                    return InformarSeNaoEncontrado(nameof(Cliente));

                var retorno = _deletarHandler.Handle(new ClienteDeletarCommand(id));

                if (retorno)
                    return InformarSeAcaoRealizadaSucesso("deletado", nameof(Cliente));
                else
                    return InformarSeNaoFoiPossivel("deletar", nameof(Cliente));
            }
            catch (Exception erro)
            {
                return BadRequest(new { Mensagem = erro.Message });
            }
        }
    }
}
