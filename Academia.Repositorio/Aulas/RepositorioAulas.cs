
using Academia.Dominio.Aulas;
using Academia.Repositorio.Contexto;

namespace Academia.Repositorio.Aulas
{
    public class RepositorioAulas : IRepositorioAulas
    {
        private readonly AcademiaDbContext _context;

        public RepositorioAulas(AcademiaDbContext context)
        {
            _context = context;
        }
        public async Task Adicionar(Aula aula)
        {
            _context.Aulas.Add(aula);
            await _context.SaveChangesAsync();
        }
        public async Task<Aula> RecuperarPorCodigoAula(int codigoAula)
        {
            return await _context.Aulas.FindAsync(codigoAula);
        }
    }
}
