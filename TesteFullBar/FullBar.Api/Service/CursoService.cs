using System.Collections.Generic;
using FullBar.Api.Models;
using FullBar.Api.Repository;

namespace FullBar.Api.Services
{

    public class CursoService : IService<Curso>
    {
        private IRepository<Curso> _repository;

        public CursoService(IRepository<Curso> repository)
        {
            _repository = repository;
        }

        public string Delete(Curso obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Curso> Get(Curso obj)
        {
            return _repository.Get(obj);
        }

        public Curso GetFirst(Curso obj)
        {
            throw new System.NotImplementedException();
        }

        public string Insert(Curso obj)
        {
            throw new System.NotImplementedException();
        }

        public string Update(Curso obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
