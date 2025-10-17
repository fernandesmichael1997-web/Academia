using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Agendamentos.Dtos;

namespace Academia.Dominio.Agendamentos.Services
{
    public interface ISeviceAgendamento
    {
        Task<Agendamento> AdicionarAgendamento(NovoAgendamentoDto agendamentoNovo);
    }
}
