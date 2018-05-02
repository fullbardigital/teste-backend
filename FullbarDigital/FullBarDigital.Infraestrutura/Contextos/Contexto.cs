using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Infraestrutura.Mapeadores.Aluno;
using Microsoft.EntityFrameworkCore;

namespace FullBarDigital.Infraestrutura.Contextos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapeadorDePeriodo.Mapear(modelBuilder);
            MapeadorDeCurso.Mapear(modelBuilder);
            MapeadorDeAluno.Mapear(modelBuilder);
        }

        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}