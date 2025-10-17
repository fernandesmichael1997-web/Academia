using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Alunos;
using Academia.Repositorio.Contexto;

namespace Academia.Repositorio.Alunos
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private readonly AcademiaDbContext _context;

        public RepositorioAluno(AcademiaDbContext context)
        {
            _context = context;
        }
        public async Task Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task<Aluno> RecuperarPorCodigoAluno(int codigoAluno)
        {
            return await _context.Alunos.FindAsync(codigoAluno);
        }
    }
}
