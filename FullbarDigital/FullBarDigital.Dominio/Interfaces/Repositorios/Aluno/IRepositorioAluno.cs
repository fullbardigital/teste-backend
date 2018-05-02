using FullBarDigital.Dominio.DataTransferObjects;
using FullBarDigital.Dominio.Entidades.Aluno;
using System.Collections.Generic;

namespace FullBarDigital.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAluno : IRepositorioBase<Aluno>
    {
        IList<AlunoDTO> ListarAlunos();
    }
}