using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces;
using FullBarDigital.Dominio.Interfaces.Repositorios;

namespace FullBarDigital.Dominio.Dominios
{
    public class DominioPeriodo : DominioBase<Periodo>, IDominioPeriodo
    {
        private readonly IRepositorioPeriodo _repositorioPeriodo;

        public DominioPeriodo(IRepositorioPeriodo repositorioPeriodo) : base(repositorioPeriodo)
        {
            _repositorioPeriodo = repositorioPeriodo;
        }
    }
}