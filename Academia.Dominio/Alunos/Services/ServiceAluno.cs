using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Agendamentos;
using Academia.Dominio.Alunos.Dtos;
using Academia.Dominio.Alunos.Validador;
using Academia.Dominio.Aulas;
using Academia.Dominio.Aulas.Validador;

namespace Academia.Dominio.Alunos.Services
{
    public class ServiceAluno : IServiceAluno
    {
        private readonly IRepositorioAluno _repositorioAluno;
        private readonly IRepositorioAgendamento _repositorioAgendamento;

        public ServiceAluno(IRepositorioAluno repositorioAluno,
                            IRepositorioAgendamento repositorioAgendamento)
        {
            _repositorioAluno = repositorioAluno;
            _repositorioAgendamento = repositorioAgendamento;
        }
        public async Task<int> AdicionarAluno(NovoAlunoDto aluno)
        {
            ValidarCadastroAluno(aluno);
            try
            {
                var alunoNovo = new Aluno()
                {
                    Nome = aluno.Nome,
                    TipoPlano = aluno.TipoPlano,
                };

                await _repositorioAluno.Adicionar(alunoNovo);

                return alunoNovo.Id;
            }
            catch (Exception ex) 
            {
                throw new Exception("Falha ao cadastrar novo aluno. ", ex);
            }
        }
        public async Task<RetornoRelatorioAlunoDto> RecuperarPorAluno(int codigoAluno)
        {
            var aluno = await _repositorioAluno.RecuperarPorCodigoAluno(codigoAluno);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            var agendamentos = await _repositorioAgendamento.RecuperarPorAlunoNoMes(codigoAluno, DateTime.Now.Month);

            var totalAulas = agendamentos.Count();

            var tiposAulasMaisFrequentes = agendamentos
                                    .GroupBy(x => x.Aula.TipoAula.ToString())
                                    .OrderByDescending(y => y.Count())
                                    .Select(g => new TipoAulaFrequenteDto
                                    {
                                        TipoAula = g.Key,
                                        Total = g.Count()
                                    })
                                    .ToList();

            return new RetornoRelatorioAlunoDto
            {
                CodigoAluno = aluno.Id,
                Nome = aluno.Nome,
                TotalAulasNoMes = totalAulas,
                TiposDeAulaMaisFrequentes = tiposAulasMaisFrequentes
            };
        }
        public async Task<Aluno> RecuperarPorCodigoAluno(int codigoAluno)
        {
           return await _repositorioAluno.RecuperarPorCodigoAluno(codigoAluno);
        }
        private void ValidarCadastroAluno(NovoAlunoDto aluno)
        {
            var validar = new NovoAlunoValidacao();
            var retorno = validar.Validate(aluno);

            if (!retorno.IsValid)
            {
                throw new ArgumentException(string.Join(" | ", retorno.Errors.Select(e => e.ErrorMessage)));
            }
        }
    }
}
