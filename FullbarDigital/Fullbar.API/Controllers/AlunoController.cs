using Fullbar.API.Services.Interfaces;
using Fullbar.Core.UnitOfWork;
using Fullbar.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fullbar.API.Controllers
{
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IAlunoService _alunoService;

        public AlunoController(IUnitOfWork context,
                               IAlunoService alunoService)
        {
            _context      = context;
            _alunoService = alunoService;
        }

        // GET api/aluno
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _alunoService.GetAlunosDetalhado());
        }

        // GET api/aluno/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json((await _alunoService.GetAll(a => a.IdAluno == id)).FirstOrDefault());
        }

        //// GET api/aluno/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string nome = null, string ra = null, int? idCurso = null)
        //{
        //    return Json(await _alunoService.GetAll(a => a.Nome.ToUpper().Contains(nome.ToUpper()) ||
        //                                                a.Ra == ra || 
        //                                                a.IdCurso == idCurso));
        //}

        // POST api/aluno
        [HttpPost]
        public async Task Post([FromBody]TbAluno value)
        {
            using (_context)
            {
                await _alunoService.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/aluno/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]TbAluno value)
        {
            using (_context)
            {
                _alunoService.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetById(id);

                if (aluno == null)
                    return BadRequest();

                using (_context)
                {
                    _alunoService.Remove(aluno);
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
