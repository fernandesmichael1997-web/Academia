using Academia.Dominio.Alunos;
using Academia.Dominio.Aulas;

namespace Academia.Dominio.Agendamentos
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int AulaId { get; set; }
        public DateTime DataAgendamento { get; set; }

        public Aluno Aluno { get; set; }
        public Aula Aula { get; set; }
    }
}
