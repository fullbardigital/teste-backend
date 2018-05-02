using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces;
using FullBarDigital.Dominio.Interfaces.Repositorios;

namespace FullBarDigital.Dominio.Dominios
{
    public class DominioCurso : DominioBase<Curso>, IDominioCurso
    {
        private readonly IRepositorioCurso _repositorioCurso;

        public DominioCurso(IRepositorioCurso repositorioCurso) : base(repositorioCurso)
        {
            _repositorioCurso = repositorioCurso;
        }
    }
}