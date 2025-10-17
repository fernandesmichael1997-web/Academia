using Academia.Dominio.Agendamentos;
using Academia.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorio.Agendamentos
{
    public class RepositorioAgendamento : IRepositorioAgendamento
    {
        private readonly AcademiaDbContext _context;

        public RepositorioAgendamento(AcademiaDbContext context)
        {
            _context = context;
        }
        public async Task Adicionar(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
        }
        public async Task<int> RecuperarTotalAgendamentoMes(int codigoAluno, int mes, int ano)
        {
            return await _context.Agendamentos
                .Where(x => x.AlunoId == codigoAluno
                         && x.DataAgendamento.Month == mes
                         && x.DataAgendamento.Year == ano)
                .CountAsync();
        }
        public async Task<int> RecuperarCapaxidadeMaxima(int codigoAula)
        {
            return await _context.Agendamentos
                .Where(x => x.AulaId == codigoAula)
                .CountAsync();
        }
        public async Task<List<Agendamento>> RecuperarPorAlunoNoMes(int codigoAluno, int mes)
        {
            return await _context.Agendamentos
                .Include(x => x.Aula)
                .Where(x => x.AlunoId == codigoAluno && x.DataAgendamento.Month == mes)
                .ToListAsync();
        }
    }
}
