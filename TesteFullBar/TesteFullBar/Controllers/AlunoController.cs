using System.Collections.Generic;
using System.Linq;
using TesteFullBar.Models;
using TesteFullBar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace TesteFullBar.Controllers
{
    public class AlunoController : Controller
    {

        private readonly IService<Aluno> _aluno_service;
        private readonly IService<Periodo> _periodo_service;
        private readonly IService<Curso> _curso_service;

        public AlunoController(
            IService<Aluno> aluno_service,
            IService<Periodo> periodo_service,
            IService<Curso> curso_service
            )
        {
            _aluno_service = aluno_service;
            _periodo_service = periodo_service;
            _curso_service = curso_service;
        }

        public IActionResult Index()
        {
            var model = new Aluno();
            model.Alunos = _aluno_service.Get(new Aluno()).Result == null ? new List<Aluno>() : _aluno_service.Get(new Aluno()).Result.ToList();

            LoadDropDownsInfo();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Aluno obj)
        {
            var model = new Aluno();
            var Alunos = new List<Aluno>();

            Alunos = _aluno_service.Get(new Aluno()).Result == null ? new List<Aluno>() : _aluno_service.Get(new Aluno()).Result.ToList();

            if (Alunos.Any())
            {
                Alunos = Alunos.Where(x => x.idCurso == obj.idCurso || obj.idCurso == 0)
                               .Where(x => x.Nome == obj.Nome || string.IsNullOrEmpty(obj.Nome))
                               .Where(x => x.RA == obj.RA || string.IsNullOrEmpty(obj.RA))
                               .ToList();

            }
            model.Alunos = Alunos;

            LoadDropDownsInfo();
            return View(model);
        }


        private void LoadDropDownsInfo()
        {
            var periodos = new List<Periodo>();
            periodos = _periodo_service.Get(new Periodo()).Result.ToList();
            periodos.Insert(0, (new Periodo { idPeriodo = 0, nmPeriodo = " " }));

            var dropDownPers = new SelectList(periodos, "idPeriodo", "nmPeriodo");
            ViewBag.DropDownPeriodos = dropDownPers;

            var cursos = new List<Curso>();
            cursos = _curso_service.Get(new Curso()).Result.ToList();
            cursos.Insert(0, (new Curso { idCurso = 0, nmCurso = " " }));

            var dropDownCurs = new SelectList(cursos, "idCurso", "nmCurso");
            ViewBag.DropDownCursos = dropDownCurs;

        }

        public IActionResult Edit(int id)
        {
            var model = new Aluno();
            model = GetAluno(id);

            LoadDropDownsInfo();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Aluno model)
        {
            if (ModelState.IsValid)
            {
                _aluno_service.Update(model);
                return RedirectToAction("Index", "Aluno");
            }

            LoadDropDownsInfo();
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            var model = new Aluno();
            model = GetAluno(id);

            LoadDropDownsInfo();

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Aluno model)
        {
                _aluno_service.Delete(model);
                return RedirectToAction("Index", "Aluno");

        }

        public IActionResult Create()
        {
            var model = new Aluno();
            LoadDropDownsInfo();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno model)
        {
            if (ModelState.IsValid)
            {
                _aluno_service.Insert(model);
                return RedirectToAction("Index", "Aluno");
            }

            LoadDropDownsInfo();
            return View();
        }

        public Aluno GetAluno(int id)
        {
            var model = new Aluno();
            model = _aluno_service.GetFirst(new Aluno() { id = id }).Result;

            return model;
        }



    }
}