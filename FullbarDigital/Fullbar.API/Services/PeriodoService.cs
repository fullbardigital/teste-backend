using Fullbar.API.Services.Interfaces;
using Fullbar.Core.Repositories;
using Fullbar.Core.Services;
using Fullbar.Entities;

namespace Fullbar.API.Services
{
    public class PeriodoService : ServiceBase<TbPeriodo>, IPeriodoService
    {
        public PeriodoService(IRepositoryBase<TbPeriodo> repository) : base(repository)
        {
        }
    }
}
