using System.Collections.Generic;
using FullBar.Api.Models;
using FullBar.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fullbar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("PolicyFree")]
    public class PeriodoController : Controller
    {
        private readonly IService<Periodo> _periodo_service;

        public PeriodoController(IService<Periodo> periodo_service)
        {
            _periodo_service = periodo_service;

        }

        [HttpPost]
        public string Insert([FromBody] Periodo obj)
        {
            return _periodo_service.Insert(obj);
        }

        [HttpPost]
        public string Update([FromBody] Periodo obj)
        {
            return _periodo_service.Update(obj);
        }

        public List<Periodo> Get(Periodo obj)
        {
            return _periodo_service.Get(obj);
        }


        [HttpGet("{id}")]
        public Periodo GetFirst([FromRoute] Periodo obj)
        {
            return _periodo_service.GetFirst(obj);
        }


    }
}