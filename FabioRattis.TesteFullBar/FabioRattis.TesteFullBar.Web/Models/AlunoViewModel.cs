using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FabioRattis.TesteFullBar.Web.Models
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            DataAccess.DataContext db = new DataAccess.DataContext(VariaveisGlobais.connectionString);

            List<SelectListItem> result = new List<SelectListItem>();
            SelectListItem defaultItem = new SelectListItem();

            defaultItem.Text = "-- Selecione um Período --";
            defaultItem.Selected = true;
            defaultItem.Value = "-1";
            result.Add(defaultItem);



            var periodos = db.Periodos.ToList();
            foreach (var item in periodos.OrderBy(x => x.idPeriodo))
            {
                SelectListItem SelectListItem = new SelectListItem();
                SelectListItem.Text = item.Periodo;
                SelectListItem.Selected = false;
                SelectListItem.Value = item.idPeriodo.ToString();
                result.Add(SelectListItem);
            }
            Periodos = result;



            result = new List<SelectListItem>();
            defaultItem = new SelectListItem();

            defaultItem.Text = "-- Selecione um Curso --";
            defaultItem.Selected = true;
            defaultItem.Value = "-1";
            result.Add(defaultItem);



            var cursos = db.Cursos.ToList();
            foreach (var item in cursos.OrderBy(x => x.Curso))
            {
                SelectListItem SelectListItem = new SelectListItem();
                SelectListItem.Text = item.Curso;
                SelectListItem.Selected = false;
                SelectListItem.Value = item.idCurso.ToString();
                result.Add(SelectListItem);
            }
            Cursos = result;

        }

        public List<FabioRattis.TesteFullBar.Model.Entities.TB_Aluno> Alunos { get; set; }
    public FabioRattis.TesteFullBar.Model.Entities.TB_Aluno Aluno { get; set; }

    public IEnumerable<SelectListItem> Cursos
    {
        get; set;
    }
    public string Curso { get; set; }
    public IEnumerable<SelectListItem> Periodos
    {
        get; set;
    }
    public string Periodo { get; set; }

    public string Erro { get; set; }
}
}