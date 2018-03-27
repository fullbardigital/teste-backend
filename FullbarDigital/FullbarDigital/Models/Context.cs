using Microsoft.EntityFrameworkCore;

namespace FullbarDigital.Models
{
    public partial class Context : DbContext
    {
        public virtual DbSet<TbAluno> TbAluno { get; set; }
        public virtual DbSet<TbCurso> TbCurso { get; set; }
        public virtual DbSet<TbPeriodo> TbPeriodo { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAluno>(entity =>
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
                    .HasConstraintName("FK__TB_Aluno__idPeri__19DFD96B");
            });

            modelBuilder.Entity<TbCurso>(entity =>
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
                    .HasForeignKey<TbCurso>(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TB_Curso__idCurs__1AD3FDA4");
            });

            modelBuilder.Entity<TbPeriodo>(entity =>
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
