using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_Backend.Models;

namespace Teste_Backend.Controllers
{
    public class AlunosController : Controller
    {
        private readonly Context _context;
        public AlunosController(Context context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var alunos = await _context.TbAluno
                .Include(_ => _.IdCursoNavigation)
                .Include(_ => _.IdPeriodoNavigation)
                .ToListAsync();
            return View(alunos);
        }

        public IActionResult Create()
        {
            CarregarCursosPeriodos();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TbAluno tbAluno)
        {
            if (!ModelState.IsValid) return BadRequest();

            _context.Add(tbAluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var aluno = await _context.TbAluno.Where(_ => _.IdAluno == id).FirstOrDefaultAsync();

            CarregarCursosPeriodos();
            return View(aluno);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TbAluno tbAluno)
        {
            if (!ModelState.IsValid || id != tbAluno.IdAluno) return BadRequest();
            if (!_context.TbAluno.Any(_ => _.IdAluno == tbAluno.IdAluno)) return NotFound();

            _context.Update(tbAluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var aluno = await _context.TbAluno.Where(_ => _.IdAluno == id).FirstOrDefaultAsync();
            if (aluno == null) return NotFound();

            _context.TbAluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private void CarregarCursosPeriodos()
        {
            ViewData["Periodos"] = new SelectList(_context.TbPeriodo, "IdPeriodo", "Periodo");
            ViewData["Cursos"] = new SelectList(_context.TbCurso, "IdCurso", "Curso");
        }
    }
}
