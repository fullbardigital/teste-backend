using Microsoft.EntityFrameworkCore;
using Entidade = FullBarDigital.Dominio.Entidades.Aluno;

namespace FullBarDigital.Infraestrutura.Mapeadores.Aluno
{
    public class MapeadorDeAluno
    {
        public static void Mapear(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Aluno>(a =>
            {
                a.HasKey(x => x.Codigo);
                a.Property(x => x.Codigo).HasColumnName("id_aluno");
                a.Property(x => x.Nome).HasColumnName("nm_aluno");
                a.Property(x => x.RA).HasColumnName("nr_registro_academico");
                a.Property(x => x.CodigoDoPeriodo).HasColumnName("id_periodo");
                a.Property(x => x.CodigoDoCurso).HasColumnName("id_curso");
                a.HasOne(x => x.Periodo).WithMany().HasForeignKey(x => x.CodigoDoPeriodo);
                a.HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.CodigoDoCurso);
                a.ToTable("t_aluno", "dbo");
            });
        }
    }
}