using Academia.Dominio.Agendamentos;
using Academia.Dominio.Alunos;
using Academia.Dominio.Aulas;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorio.Contexto
{
    public class AcademiaDbContext : DbContext
    {
        public AcademiaDbContext(DbContextOptions<AcademiaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            modelBuilder.Entity<Aula>().HasKey(a => a.Id);
            modelBuilder.Entity<Agendamento>().HasKey(a => a.Id);
        }
    }
}
