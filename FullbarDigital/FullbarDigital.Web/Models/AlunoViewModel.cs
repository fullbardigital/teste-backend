using FullBarDigital.Dominio.DataTransferObjects;
using FullBarDigital.Dominio.Entidades.Aluno;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullbarDigital.Web.Models
{
    public class AlunoViewModel
    {

        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "RA")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string RA { get; set; }

        [Display(Name = "Período")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoDoPeriodo { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoDoCurso { get; set; }

        public SelectList Periodos { get; set; }

        public SelectList Cursos { get; set; }

        public IList<AlunoDTO> Alunos { get; set; }
    }
}