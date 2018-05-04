using System.Collections.Generic;
using FullBar.Api.Models;
using FullBar.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fullbar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("PolicyFree")]
    public class AlunoController : Controller
    {
        private readonly IService<Aluno> _aluno_service;

        public AlunoController(IService<Aluno> aluno_service)
        {
            _aluno_service = aluno_service;

        }

        [HttpPost]
        public string Insert([FromBody] Aluno obj)
        {
            return _aluno_service.Insert(obj);
        }

        [HttpPost]
        public string Update([FromBody] Aluno obj)
        {
            return _aluno_service.Update(obj);
        }

        [HttpPost]
        public string Delete([FromBody] Aluno obj)
        {
            return _aluno_service.Delete(obj);
        }

        public List<Aluno> Get(Aluno obj)
        {
            return _aluno_service.Get(obj);
        }

        [HttpGet("{id}")]
        public Aluno GetFirst([FromRoute] Aluno obj)
        {
            return _aluno_service.GetFirst(obj);
        }


    }
}