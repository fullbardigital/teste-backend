using Fullbar.API.Services.Interfaces;
using Fullbar.Core.Repositories;
using Fullbar.Core.Services;
using Fullbar.Entities;

namespace Fullbar.API.Services
{
    public class CursoService : ServiceBase<TbCurso>, ICursoService
    {
        public CursoService(IRepositoryBase<TbCurso> repository) : base(repository)
        {
        }
    }
}
