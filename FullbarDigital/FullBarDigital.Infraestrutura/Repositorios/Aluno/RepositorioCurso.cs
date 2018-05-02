using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace FullBarDigital.Infraestrutura.Repositorios
{
    public class RepositorioCurso : RepositorioBase<Curso>, IRepositorioCurso
    {
        public RepositorioCurso(DbContext context) : base(context) { }
    }
}