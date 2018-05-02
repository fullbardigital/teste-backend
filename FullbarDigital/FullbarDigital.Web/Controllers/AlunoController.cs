using FullbarDigital.Web.Models;
using FullBarDigital.Dominio.Entidades.Aluno;
using FullBarDigital.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FullbarDigital.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IDominioCurso _dominioCurso;
        private readonly IDominioPeriodo _dominioPeriodo;
        private readonly IDominioAluno _dominioAluno;

        public AlunoController(
            IDominioAluno dominioAluno,
            IDominioCurso dominioCurso,
            IDominioPeriodo dominioPeriodo)
        {
            _dominioCurso = dominioCurso;
            _dominioAluno = dominioAluno;
            _dominioPeriodo = dominioPeriodo;
        }

        public IActionResult Index()
        {
            var model = new AlunoViewModel()
            {
                Alunos = _dominioAluno.ListarAlunos()
            };

            model = CarregarDropDownList(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(AlunoViewModel model)
        {
            var consulta = _dominioAluno.ListarAlunos();

            if (!string.IsNullOrEmpty(model.Nome))
                consulta = consulta.Where(x => x.Nome.ToLower().Contains(model.Nome.ToLower())).ToList();

            if (!string.IsNullOrEmpty(model.RA))
                consulta = consulta.Where(x => x.RA == model.RA).ToList();

            if (model.CodigoDoCurso > 0)
                consulta = consulta.Where(x => x.CodigoDoCurso == model.CodigoDoCurso).ToList();

            model.Alunos = consulta;
            model = CarregarDropDownList(model);

            return View(model);
        }

        public IActionResult Aluno(int? id = null)
        {
            var model = new AlunoViewModel();

            if (!id.HasValue)
            {
                model = CarregarDropDownList(model);

                return View(model);
            }

            var aluno = _dominioAluno.ObterPorCodigo((int)id);

            model.Codigo = aluno.Codigo;
            model.Nome = aluno.Nome;
            model.RA = aluno.RA;
            model.CodigoDoPeriodo = aluno.CodigoDoPeriodo;
            model.CodigoDoCurso = aluno.CodigoDoCurso;
            model = CarregarDropDownList(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aluno(AlunoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = CarregarDropDownList(model);

                return View(model);
            }

            var aluno = new Aluno
            {
                Codigo = model.Codigo,
                Nome = model.Nome,
                RA = model.RA,
                CodigoDoPeriodo = model.CodigoDoPeriodo,
                CodigoDoCurso = model.CodigoDoCurso
            };

            _dominioAluno.Salvar(aluno);
            _dominioAluno.SalvarAlteracoes();

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                _dominioAluno.DeletarPorCodigo(id);
                _dominioAluno.SalvarAlteracoes();
            }

            return View("Index");
        }

        private AlunoViewModel CarregarDropDownList(AlunoViewModel model)
        {
            model.Periodos = new SelectList(_dominioPeriodo.Listar(), "Codigo", "Nome");
            model.Cursos = new SelectList(_dominioCurso.Listar(), "Codigo", "Nome");

            return model;
        }
    }
}