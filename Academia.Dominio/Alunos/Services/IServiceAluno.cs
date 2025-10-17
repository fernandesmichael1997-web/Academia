using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Alunos.Dtos;

namespace Academia.Dominio.Alunos.Services
{
    public interface IServiceAluno
    {
        Task<int> AdicionarAluno(NovoAlunoDto aluno);
        Task<RetornoRelatorioAlunoDto> RecuperarPorAluno(int codigoAluno);
        Task<Aluno> RecuperarPorCodigoAluno(int codigoAluno);
    }
}
