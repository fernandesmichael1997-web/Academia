using Academia.Dominio.Agendamentos.Dtos;
using Academia.Dominio.Alunos;
using Academia.Dominio.Aulas;
using Academia.Dominio.Extension;

namespace Academia.Dominio.Agendamentos.Services
{
    public class SeviceAgendamento : ISeviceAgendamento
    {
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        private readonly IRepositorioAluno _repositorioAluno;
        private readonly IRepositorioAulas _repositorioAulas;
        public SeviceAgendamento(IRepositorioAgendamento repositorioAgendamento,
                                 IRepositorioAluno repositorioAluno,
                                 IRepositorioAulas repositorioAulas)
        {
            _repositorioAgendamento = repositorioAgendamento;
            _repositorioAluno = repositorioAluno;
            _repositorioAulas = repositorioAulas;

        }
        public async Task<Agendamento> AdicionarAgendamento(NovoAgendamentoDto agendamentoNovo)
        {
            if (agendamentoNovo == null)
                throw new Exception("Código do aluno e da aula são obrigatórios.");

            var aluno = await _repositorioAluno.RecuperarPorCodigoAluno(agendamentoNovo.CodigoAluno) ?? throw new Exception("Aluno não encontrado");
            var aula = await _repositorioAulas.RecuperarPorCodigoAula(agendamentoNovo.CodigoAula) ?? throw new Exception("Aula não encontrada");

            var totalAgendado = await _repositorioAgendamento.RecuperarTotalAgendamentoMes(aluno.Id, DateTime.Now.Month, DateTime.Now.Year);

            var limite = aluno.TipoPlano.LimiteMensal();

            if (totalAgendado >= limite)
            {
                throw new Exception(
                    $"Limite de aulas mensais atingido para o plano {aluno.TipoPlano}. O máximo permitido é {limite} aulas.");
            }

            var vagas = await _repositorioAgendamento.RecuperarCapaxidadeMaxima(aula.Id);
            if (vagas >= aula.CapacidadeMaxima)
            {
                throw new Exception("A aula está lotada");
            }

            try
            {
                var agendamento = new Agendamento
                {
                    AlunoId = aluno.Id,      
                    AulaId = aula.Id,  
                    DataAgendamento = DateTime.Now
                };

                await _repositorioAgendamento.Adicionar(agendamento);

                return agendamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar agendamento. ", ex);
            }
        }

    }
}
