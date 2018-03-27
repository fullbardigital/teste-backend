using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullbarDigital.Models;

namespace FullbarDigital.Controllers
{
    public class AlunosController : Controller
    {
        private readonly Context _context;

        public AlunosController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dB_TESTEContext = _context.TbAluno
                .Include(t => t.IdPeriodoNavigation)
                .Include(t => t.IdCursoNavigation);
            return View(await dB_TESTEContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var tbAluno = await _context.TbAluno
                .Include(t => t.IdPeriodoNavigation)
                .Include(t => t.IdCursoNavigation)
                .SingleOrDefaultAsync(m => m.IdAluno == id);
            if (tbAluno == null)
                return NotFound();

            return View(tbAluno);
        }

        public IActionResult Create()
        {
            ViewData["IdPeriodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo");
            ViewData["IdCurso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAluno,Nome,Ra,IdPeriodo,IdCurso")] TbAluno tbAluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPeriodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "IdPeriodo", tbAluno.IdPeriodo);
            ViewData["IdCurso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso", tbAluno.IdCurso);
            return View(tbAluno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var tbAluno = await _context.TbAluno.SingleOrDefaultAsync(m => m.IdAluno == id);

            if (tbAluno == null)
                return NotFound();

            ViewData["IdPeriodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo", tbAluno.IdPeriodo);
            ViewData["IdCurso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso", tbAluno.IdCurso);
            return View(tbAluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAluno,Nome,Ra,IdPeriodo,IdCurso")] TbAluno tbAluno)
        {
            if (id != tbAluno.IdAluno)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbAluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbAlunoExists(tbAluno.IdAluno))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPeriodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "IdPeriodo", tbAluno.IdPeriodo);
            ViewData["IdCurso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso", tbAluno.IdCurso);
            return View(tbAluno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var tbAluno = await _context.TbAluno
                .Include(t => t.IdPeriodoNavigation)
                .Include(t => t.IdCursoNavigation)
                .SingleOrDefaultAsync(m => m.IdAluno == id);
            if (tbAluno == null)
                return NotFound();

            return View(tbAluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbAluno = await _context.TbAluno.SingleOrDefaultAsync(m => m.IdAluno == id);
            _context.TbAluno.Remove(tbAluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbAlunoExists(int id)
        {
            return _context.TbAluno.Any(e => e.IdAluno == id);
        }
    }
}
