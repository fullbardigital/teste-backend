using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullbarDigital.TESTE.Models;

namespace FullbarDigital.TESTE.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ModelContext _context;

        public AlunoController(ModelContext context)
        {
            _context = context;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.TbAluno.Include(a => a.IdPeriodoNavigation).Include(a => a.IdCursoNavigation);            
            ViewData["Curso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso");
            return View(await modelContext.ToListAsync());
        }        

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Nome", "RA", "IdCurso")] String nome, String ra, int idCurso)
        {
            var modelContext = _context.TbAluno.Include(a => a.IdPeriodoNavigation).Include(a => a.IdCursoNavigation);
            if (!string.IsNullOrEmpty(nome))
                modelContext = modelContext.Where(x => x.Nome.Contains(nome)).Include(a => a.IdPeriodoNavigation).Include(a => a.IdCursoNavigation);

            if(!string.IsNullOrEmpty(ra))
                modelContext = modelContext.Where(x => x.Ra == ra).Include(a => a.IdPeriodoNavigation).Include(a => a.IdCursoNavigation);

            if(idCurso > 0)
                modelContext = modelContext.Where(x => x.IdCurso == idCurso).Include(a => a.IdPeriodoNavigation).Include(a => a.IdCursoNavigation);


            ViewData["Curso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso");
            return View(await modelContext.ToListAsync());
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            ViewData["Periodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo");
            ViewData["Curso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAluno,Nome,Ra,IdPeriodo,IdCurso")] AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Periodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo", alunoViewModel.IdPeriodo);
            ViewData["Curso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso", alunoViewModel.IdCurso);
            return View(alunoViewModel);
        }

        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _context.TbAluno.FindAsync(id);
            if (alunoViewModel == null)
            {
                return NotFound();
            }
            ViewData["Periodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo", alunoViewModel.IdPeriodo);
            ViewData["Curso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso", alunoViewModel.IdCurso);
            return View(alunoViewModel);
        }

        // POST: Aluno/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAluno,Nome,Ra,IdPeriodo,IdCurso")] AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.IdAluno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoViewModelExists(alunoViewModel.IdAluno))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }            
            ViewData["Periodo"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo", alunoViewModel.IdPeriodo);
            ViewData["Curso"] = new SelectList(_context.TbCurso, "IdCurso", "Curso", alunoViewModel.IdCurso);
            return View(alunoViewModel);
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _context.TbAluno
                .Include(a => a.IdPeriodoNavigation)
                .Include(a => a.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.IdAluno == id);
            if (alunoViewModel == null)
            {
                return NotFound();
            }

            return View(alunoViewModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoViewModel = await _context.TbAluno.FindAsync(id);
            _context.TbAluno.Remove(alunoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoViewModelExists(int id)
        {
            return _context.TbAluno.Any(e => e.IdAluno == id);
        }
    }
}
