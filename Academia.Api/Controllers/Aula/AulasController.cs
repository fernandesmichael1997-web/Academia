using Academia.Dominio.Aulas.Dtos;
using Academia.Dominio.Aulas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Api.Controllers.Aula
{
    [Route("api/aula")]
    public class AulasController : ControllerBase
    {
        private readonly IServiceAula _serviceAula;

        public AulasController(IServiceAula serviceAula)
        {
            _serviceAula = serviceAula;
        }

        [Route("cadastrar")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] NovaAulaDto aula)
        {
            var codigoAula = await _serviceAula.AdicionarAula(aula);
            return Ok(new
            {
                Mensagem = "Cadastro da aula gerado com sucesso",
                CodigoAula = codigoAula
            });
  
        }

        [Route("recuperarAula")]
        [HttpGet]
        public async Task<ActionResult> RecuperarAula(int codigoAula)
        {
            var aula = await _serviceAula.RecuperarPorCodigoAula(codigoAula);
            if (aula == null)
                return NotFound("Codigo sem registro");
            return Ok(aula);
        }
    }
}
