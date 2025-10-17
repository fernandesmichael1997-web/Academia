using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Dominio.Alunos
{
    public interface IRepositorioAluno
    {
        Task Adicionar(Aluno aluno);
        Task<Aluno> RecuperarPorCodigoAluno(int codigoAluno);
    }
}
