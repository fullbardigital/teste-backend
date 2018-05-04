using System.Collections.Generic;
using FullBar.Api.Models;
using FullBar.Api.Repository;

namespace FullBar.Api.Services
{

    public class AlunoService : IService<Aluno>
    {
        private IRepository<Aluno> _repository;

        public AlunoService(IRepository<Aluno> repository)
        {
            _repository = repository;
        }

        public string Delete(Aluno obj)
        {
            return _repository.Delete(obj);
        }

        public List<Aluno> Get(Aluno obj)
        {
            return _repository.Get(obj);
        }

        public Aluno GetFirst(Aluno obj)
        {
            return _repository.GetFirst(obj);
        }

        public string Insert(Aluno obj)
        {
            return _repository.Insert(obj);
        }

        public string Update(Aluno obj)
        {
            return _repository.Update(obj);
        }
    }
}
