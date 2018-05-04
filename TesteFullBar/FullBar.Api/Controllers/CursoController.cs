using System.Collections.Generic;
using FullBar.Api.Models;
using FullBar.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fullbar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("PolicyFree")]
    public class CursoController : Controller
    {
        private readonly IService<Curso> _curso_service;

        public CursoController(IService<Curso> curso_service)
        {
            _curso_service = curso_service;
        }

        [HttpPost]
        public string Insert([FromBody] Curso obj)
        {
            return _curso_service.Insert(obj);
        }

        [HttpPost]
        public string Update([FromBody] Curso obj)
        {
            return _curso_service.Update(obj);
        }

        public List<Curso> Get(Curso obj)
        {
            return _curso_service.Get(obj);
        }

        [HttpGet("{id}")]
        public Curso GetFirst([FromRoute] Curso obj)
        {
            return _curso_service.GetFirst(obj);
        }


    }
}