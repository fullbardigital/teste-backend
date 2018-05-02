using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace FullBarDigital.Infraestrutura.Repositorios
{
    public class RepositorioPeriodo : RepositorioBase<Periodo>, IRepositorioPeriodo
    {
        public RepositorioPeriodo(DbContext context) : base(context) { }
    }
}