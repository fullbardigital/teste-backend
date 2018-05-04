using System.Collections.Generic;
using FullBar.Api.Models;
using FullBar.Api.Repository;

namespace FullBar.Api.Services
{

    public class PeriodoService : IService<Periodo>
    {
        private IRepository<Periodo> _repository;

        public PeriodoService(IRepository<Periodo> repository)
        {
            _repository = repository;
        }

        public string Delete(Periodo obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Periodo> Get(Periodo obj)
        {
            return _repository.Get(obj);
        }

        public Periodo GetFirst(Periodo obj)
        {
            throw new System.NotImplementedException();
        }

        public string Insert(Periodo obj)
        {
            throw new System.NotImplementedException();
        }

        public string Update(Periodo obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
