using FullBarDigital.Dominio.Entidades.Aluno;
using Microsoft.EntityFrameworkCore;

namespace FullBarDigital.Infraestrutura.Mapeadores.Aluno
{
    public class MapeadorDePeriodo
    {
        public static void Mapear(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Periodo>(p => 
            {
                p.HasKey(x => x.Codigo);
                p.Property(x => x.Codigo).HasColumnName("id_periodo");
                p.Property(x => x.Nome).HasColumnName("nm_periodo");
                p.ToTable("t_periodo", "dbo");
            });
        }
    }
}