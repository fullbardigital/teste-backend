using Fullbar.API.Services.Interfaces;
using Fullbar.Core.UnitOfWork;
using Fullbar.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fullbar.API.Controllers
{
    [Route("api/[controller]")]
    public class PeriodoController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IPeriodoService _periodoService;

        public PeriodoController(IUnitOfWork context,
                                 IPeriodoService periodoService)
        {
            _context = context;
            _periodoService = periodoService;
        }

        // GET api/periodo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _periodoService.GetAll());
        }

        // GET api/periodo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await _periodoService.GetAll(a => a.IdPeriodo == id));
        }

        // POST api/periodo
        [HttpPost]
        public async Task Post([FromBody]TbPeriodo value)
        {
            using (_context)
            {
                await _periodoService.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/periodo/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]TbPeriodo value)
        {
            using (_context)
            {
                _periodoService.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/periodo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var periodo = await _periodoService.GetById(id);

                if (periodo == null)
                    return BadRequest();

                using (_context)
                {
                    _periodoService.Remove(periodo);
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
