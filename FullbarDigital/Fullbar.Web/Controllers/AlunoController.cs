using Fullbar.Entities;
using Fullbar.Web.Common;
using Fullbar.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Fullbar.Web.Controllers
{
    public class AlunoController : Controller
    {

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NomeOrdemParam  = string.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewBag.RAOrdemParam    = sortOrder == "RA" ? "ra_desc" : "RA";
            ViewBag.CursoOrdemParam = sortOrder == "Curso" ? "curso_desc" : "Curso";

            HttpResponseMessage response = WebApiHelper.WebApiClient.GetAsync("aluno").Result;
            var alunos = response.Content.ReadAsAsync<IEnumerable<AlunoViewModel>>().Result;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToUpper();

                alunos = alunos.Where(s => s.Nome.ToUpper().Contains(searchString)
                                       || s.Curso.ToUpper().Contains(searchString)
                                       || s.Ra.ToUpper().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nome_desc":
                    alunos = alunos.OrderByDescending(s => s.Nome);
                    break;
                case "RA":
                    alunos = alunos.OrderBy(s => s.Ra);
                    break;
                case "ra_desc":
                    alunos = alunos.OrderByDescending(s => s.Ra);
                    break;
                case "Curso":
                    alunos = alunos.OrderBy(s => s.Curso);
                    break;
                case "curso_desc":
                    alunos = alunos.OrderByDescending(s => s.Curso);
                    break;
            }

            return View(alunos.ToList());
        }

        public IActionResult CreateOrEdit(int id = 0)
        {
            GetCursos();
            GetPeriodos();

            if (id == 0)
                return View(new TbAluno());
            else
            {
                HttpResponseMessage response = WebApiHelper.WebApiClient.GetAsync("aluno/" + id.ToString()).Result;
                var aluno = response.Content.ReadAsAsync<TbAluno>().Result;

                return View(aluno);
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(TbAluno model)
        {
            if (model.IdAluno == 0)
            {
                HttpResponseMessage response = WebApiHelper.WebApiClient.PostAsJsonAsync("aluno", model).Result;
            }
            else
            {
                HttpResponseMessage response = WebApiHelper.WebApiClient.PutAsJsonAsync("aluno/" + model.IdAluno, model).Result;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = WebApiHelper.WebApiClient.DeleteAsync("aluno/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

        private void GetCursos()
        {
            HttpResponseMessage response = WebApiHelper.WebApiClient.GetAsync("curso").Result;

            var cursos     = response.Content.ReadAsAsync<IEnumerable<TbCurso>>().Result;
            ViewBag.Cursos = new SelectList(cursos, "IdCurso", "Curso");
        }

        private void GetPeriodos()
        {
            HttpResponseMessage response = WebApiHelper.WebApiClient.GetAsync("periodo").Result;

            var periodos = response.Content.ReadAsAsync<IEnumerable<TbPeriodo>>().Result;
            ViewBag.Periodos = new SelectList(periodos, "IdPeriodo", "Periodo");
        }

    }
}