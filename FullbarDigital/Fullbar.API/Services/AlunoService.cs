using Fullbar.API.Repositories.Interfaces;
using Fullbar.API.Services.Interfaces;
using Fullbar.API.ViewModel;
using Fullbar.Core.Services;
using Fullbar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.API.Services
{
    public class AlunoService : ServiceBase<TbAluno>, IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AlunoViewModel>> GetAlunosDetalhado()
        {
            return await _repository.GetAlunosDetalhado();
        }
    }
}
