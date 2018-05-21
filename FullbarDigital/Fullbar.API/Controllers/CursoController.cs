using Fullbar.API.Services.Interfaces;
using Fullbar.Core.UnitOfWork;
using Fullbar.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Fullbar.API.Controllers
{
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly ICursoService _cursoService;

        public CursoController(IUnitOfWork context,
                               ICursoService cursoService)
        {
            _context = context;
            _cursoService = cursoService;
        }

        // GET api/curso
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cursos = (await _cursoService.GetAll()).ToList();
            return Json(cursos);
        }

        // GET api/curso/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await _cursoService.GetAll(a => a.IdCurso == id));
        }

        // POST api/curso
        [HttpPost]
        public async Task Post([FromBody]TbCurso value)
        {
            using (_context)
            {
                await _cursoService.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/curso/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]TbCurso value)
        {
            using (_context)
            {
                _cursoService.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var curso = await _cursoService.GetById(id);

                if (curso == null)
                    return BadRequest();

                using (_context)
                {
                    _cursoService.Remove(curso);
                    await _context.SaveChangesAsync();
                }

                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
