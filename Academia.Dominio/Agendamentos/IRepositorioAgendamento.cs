using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Dominio.Agendamentos
{
    public interface IRepositorioAgendamento
    {
        Task Adicionar(Agendamento agendamento);
        Task<int> RecuperarTotalAgendamentoMes(int codigoAluno, int mes, int ano);
        Task<int> RecuperarCapaxidadeMaxima(int codigoAula);
        Task<List<Agendamento>> RecuperarPorAlunoNoMes(int codigoAluno, int mes);
    }
}
