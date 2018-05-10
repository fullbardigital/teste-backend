using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FabioRattis.TesteFullBar.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FabioRattis.TesteFullBar.Web.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _IConfiguration;


        public HomeController(IConfiguration IConfiguration)
        {
            _IConfiguration = IConfiguration;
            VariaveisGlobais.connectionString = _IConfiguration.GetSection("ConnectionStrings").GetSection("DataContext").Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            AlunoViewModel model = new AlunoViewModel();
            DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);

            var Alunos = db.Alunos
                    .Include(x => x.Curso)
                    .Include(x => x.Periodo)
                    .ToList();
            model.Alunos = Alunos;
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(AlunoViewModel model)
        {
            DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);

            var Alunos = db.Alunos
                    .Include(x => x.Curso)
                    .Include(x => x.Periodo)
                    .ToList();

            if (!string.IsNullOrEmpty(model.Aluno.RA))
            {
                Alunos = Alunos.Where(x => x.RA == model.Aluno.RA).ToList();
            }
            if (!string.IsNullOrEmpty(model.Aluno.Nome))
            {
                Alunos = Alunos.Where(x => x.Nome.ToUpper().Contains(model.Aluno.Nome.ToUpper())).ToList();
            }
            if (model.Aluno.idCurso > 0)
            {
                Alunos = Alunos.Where(x => x.idCurso == model.Aluno.idCurso).ToList();
            }

            model.Alunos = Alunos;
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Models.AlunoViewModel());
        }
        [HttpPost]
        public IActionResult Create(AlunoViewModel model)
        {
            model.Erro = model.Aluno.Validar();

            if (!string.IsNullOrEmpty(model.Erro))
            {
                return View(model);
            }

            try
            {
                DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);

                db.Alunos.Add(model.Aluno);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                model.Erro = ex.Message;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = new Models.AlunoViewModel();
            DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);
            model.Aluno = db.Alunos.FirstOrDefault(x => x.idAluno == Id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(AlunoViewModel model)
        {
            model.Erro = model.Aluno.Validar();

            if (!string.IsNullOrEmpty(model.Erro))
            {
                return View(model);
            }

            try
            {
                DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);
                var Alunos = db.Alunos.FirstOrDefault(x => x.idAluno == model.Aluno.idAluno);

                Alunos.Nome = model.Aluno.Nome;
                Alunos.RA = model.Aluno.RA;
                Alunos.idCurso = model.Aluno.idCurso;
                Alunos.idPeriodo = model.Aluno.idPeriodo;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                model.Erro = ex.Message;
                return View(model);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);

            var Alunos = db.Alunos.FirstOrDefault(x => x.idAluno == Id);

            db.Alunos.Remove(Alunos);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
