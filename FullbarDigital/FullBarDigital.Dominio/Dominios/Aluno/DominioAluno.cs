using FullBarDigital.Dominio.DataTransferObjects;
using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces;
using FullBarDigital.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;

namespace FullBarDigital.Dominio.Dominios
{
    public class DominioAluno : DominioBase<Aluno>, IDominioAluno
    {
        private readonly IRepositorioAluno _repositorioAluno;

        public DominioAluno(IRepositorioAluno repositorioAluno) : base(repositorioAluno)
        {
            _repositorioAluno = repositorioAluno;
        }

        public IList<AlunoDTO> ListarAlunos()
        {
            return _repositorioAluno.ListarAlunos();
        }
    }
}