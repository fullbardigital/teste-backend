using FullBarDigital.Dominio.Entidades.Aluno;
using Microsoft.EntityFrameworkCore;

namespace FullBarDigital.Infraestrutura.Mapeadores.Aluno
{
    public class MapeadorDeCurso
    {
        public static void Mapear(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(c =>
            {
                c.HasKey(x => x.Codigo);
                c.Property(x => x.Codigo).HasColumnName("id_curso");
                c.Property(x => x.Nome).HasColumnName("nm_curso");
                c.ToTable("t_curso", "dbo");
            });
        }
    }
}