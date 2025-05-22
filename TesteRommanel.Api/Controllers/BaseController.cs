using Microsoft.AspNetCore.Mvc;
using TesteRommanel.Domain.DTOs;

namespace TesteRommanel.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult InformarSeNaoEncontrado(string descricaoObjeto)
        {
            return NotFound(new RetornoAPI()
            {
                Sucesso = false,
                Mensagem = $"{descricaoObjeto} não encontrado(a)."
            });
        }

        public IActionResult InformarSeNaoFoiPossivel(string acao, string descricaoObjeto)
        {
            return BadRequest(new RetornoAPI()
            {
                Sucesso = false,
                Mensagem = $"Não foi possível {acao} o {descricaoObjeto}."
            });
        }

        public IActionResult InformarSeAcaoRealizadaSucesso(string acao, string descricaoObjeto)
        {
            return Ok(new RetornoAPI()
            {
                Sucesso = true,
                Mensagem = $"{descricaoObjeto} {acao} com sucesso."
            });
        }

        public IActionResult InformarSeJaExiste(string tipo, string campo)
        {
            return Conflict(new RetornoAPI()
            {
                Sucesso = false,
                Mensagem = $"Já existe {tipo} cadastrado com esse {campo}."
            });
        }
    }
}
