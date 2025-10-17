using Academia.Dominio.Alunos.Dtos;
using Academia.Dominio.Alunos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Api.Controllers.Aluno
{
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IServiceAluno _serviceAluno;

        public AlunoController(IServiceAluno serviceAluno)
        {
            _serviceAluno = serviceAluno;
        }

        [Route("cadastrar")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] NovoAlunoDto aluno)
        {
            var codigoAluno = await _serviceAluno.AdicionarAluno(aluno);
            return Ok(new
            {
                Mensagem = "Cadastro do aluno gerado com sucesso",
                CodigoAluno = codigoAluno
            });
        }

        [Route("recuperarAluno")]
        [HttpGet]
        public async Task<ActionResult> RecuperarAluno(int codigoAluno)
        {
            var aluno = await _serviceAluno.RecuperarPorCodigoAluno(codigoAluno);
            if (aluno == null)
                return NotFound("Codigo sem registro: ");
            return Ok(aluno);
        }

        [Route("relatorio")]
        [HttpGet]
        public async Task<IActionResult> RelatorioPorAluno(int codigoAluno)
        {
            var relatorio = await _serviceAluno.RecuperarPorAluno(codigoAluno);
            return Ok(relatorio);
        }
    }
}
