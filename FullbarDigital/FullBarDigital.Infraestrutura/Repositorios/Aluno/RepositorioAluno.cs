using FullBarDigital.Dominio.DataTransferObjects;
using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FullBarDigital.Infraestrutura.Repositorios
{
    public class RepositorioAluno : RepositorioBase<Aluno>, IRepositorioAluno
    {
        public RepositorioAluno(DbContext contexto) : base(contexto) { }

        public IList<AlunoDTO> ListarAlunos()
        {
            var query = (from aluno in Queryable()
                         select new AlunoDTO
                         {
                             Codigo = aluno.Codigo,
                             Nome = aluno.Nome,
                             RA = aluno.RA,
                             CodigoDoCurso = aluno.CodigoDoCurso,
                             NomeDoCurso = aluno.Curso.Nome,
                             CodigoDoPeriodo = aluno.CodigoDoPeriodo,
                             NomeDoPeriodo = aluno.Periodo.Nome
                         }).ToList();

            return query;
        }
    }
}