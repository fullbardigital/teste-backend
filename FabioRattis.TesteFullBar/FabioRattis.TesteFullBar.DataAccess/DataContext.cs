using FabioRattis.TesteFullBar.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using System.Data.Entity.ModelConfiguration.Conventions;

namespace FabioRattis.TesteFullBar.DataAccess
{
    public class DataContext : DbContext
    {
        string _connectionString;
        public DataContext(string connectionString)
        { _connectionString = connectionString; }

        public DataContext(DbContextOptions<DataContext> opcoes)
            : base(opcoes)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<TB_Aluno> Alunos { get; set; }
        public DbSet<TB_Curso> Cursos { get; set; }
        public DbSet<TB_Periodo> Periodos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TB_Aluno>(config =>
            {
                config.ToTable("TB_Aluno");
                config.HasKey(x => x.idAluno);
                config.Property(x => x.Nome).HasMaxLength(100);
                config.Property(x => x.RA).HasMaxLength(10);

                config.HasOne(x => x.Curso)
                    .WithMany(x => x.Alunos)
                    .HasPrincipalKey(m => m.idCurso)
                    .HasForeignKey(m => m.idCurso);

                config.HasOne(x => x.Periodo)
                    .WithMany(x => x.Alunos)
                    .HasPrincipalKey(m => m.idPeriodo)
                    .HasForeignKey(m => m.idPeriodo);
            });

            builder.Entity<TB_Curso>(config =>
            {
                config.ToTable("TB_Curso");
                config.HasKey(x => x.idCurso);
                config.HasMany(x => x.Alunos)
                    .WithOne(x => x.Curso)
                    .HasPrincipalKey(m => m.idCurso)
                    .HasForeignKey(m => m.idCurso);

                config.Property(x => x.Curso).HasMaxLength(100);
            });

            builder.Entity<TB_Periodo>(config =>
            {
                config.ToTable("TB_Periodo");
                config.HasKey(x => x.idPeriodo);
                config.HasMany(x => x.Alunos)
                    .WithOne(x => x.Periodo)
                    .HasPrincipalKey(m => m.idPeriodo)
                    .HasForeignKey(m => m.idPeriodo);
                config.Property(x => x.Periodo).HasMaxLength(20);
            });

            base.OnModelCreating(builder);
        }
    }
}
