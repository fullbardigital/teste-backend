using Fullbar.API.ViewModel;
using Fullbar.Core.Repositories;
using Fullbar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.API.Repositories.Interfaces
{
    public interface IAlunoRepository : IRepositoryBase<TbAluno>
    {
        Task<IEnumerable<AlunoViewModel>> GetAlunosDetalhado();
    }
}
