using Fullbar.API.ViewModel;
using Fullbar.Core.Services;
using Fullbar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.API.Services.Interfaces
{
    public interface IAlunoService : IServiceBase<TbAluno>
    {
        Task<IEnumerable<AlunoViewModel>> GetAlunosDetalhado();
    }
}
