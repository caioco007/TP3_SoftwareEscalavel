using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Infrastructure.Persistence
{
    public class TP3MicrosservicoDbContext : DbContext
    {
        public TP3MicrosservicoDbContext(DbContextOptions<TP3MicrosservicoDbContext> options) : base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<AtividadeAluno> AtividadeAlunos { get; set; }
        public DbSet<Chamada> Chamadas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisciplinaAluno> DisciplinaAlunos { get; set; }
        public DbSet<Professor> Professores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
