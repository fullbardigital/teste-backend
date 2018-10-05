using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace FullbarDigital.TESTE.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }        

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlunoViewModel> TbAluno { get; set; }
        public virtual DbSet<CursoViewModel> TbCurso { get; set; }
        public virtual DbSet<PeriodoViewModel> TbPeriodo { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoViewModel>(entity =>
            {
                entity.HasKey(e => e.IdAluno);

                entity.ToTable("TB_Aluno");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ra)
                    .HasColumnName("RA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.TbAluno)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("FK__TB_Aluno__idPeri__2B3F6F97");
            });

            modelBuilder.Entity<CursoViewModel>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("TB_Curso");

                entity.Property(e => e.IdCurso)
                    .HasColumnName("idCurso")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Curso)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithOne(p => p.InverseIdCursoNavigation)
                    .HasForeignKey<CursoViewModel>(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Curso__idCurs__286302EC");
            });

            modelBuilder.Entity<PeriodoViewModel>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo);

                entity.ToTable("TB_Periodo");

                entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

                entity.Property(e => e.Periodo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
