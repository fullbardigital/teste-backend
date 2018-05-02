using FullBarDigital.Dominio.DataTransferObjects;
using FullBarDigital.Dominio.Entidades.Aluno;
using System.Collections.Generic;

namespace FullBarDigital.Dominio.Interfaces
{
    public interface IDominioAluno : IDominioBase<Aluno>
    {
        IList<AlunoDTO> ListarAlunos();
    }
}