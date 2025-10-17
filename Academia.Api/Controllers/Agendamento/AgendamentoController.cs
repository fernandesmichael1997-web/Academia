using Academia.Dominio.Agendamentos.Dtos;
using Academia.Dominio.Agendamentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Api.Controllers.Agendamento
{
    [Route("api/agendamento")]
    public class AgendamentoController : ControllerBase
    {
        private readonly ISeviceAgendamento _seviceAgendamento;
        public AgendamentoController(ISeviceAgendamento seviceAgendamento) 
        {
            _seviceAgendamento = seviceAgendamento;
        }
        [Route("cadastrar")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] NovoAgendamentoDto agendamento)
        {
            var agendamentoGerado = await _seviceAgendamento.AdicionarAgendamento(agendamento);
            return Ok(new
            {
                Mensagem = "Agendamento cadastrado com sucesso",
                Agendamento = agendamentoGerado
            });
        }
    }
}
