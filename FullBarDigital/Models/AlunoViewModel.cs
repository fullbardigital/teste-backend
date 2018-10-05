using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullbarDigital.TESTE.Models
{
    public partial class AlunoViewModel
    {
        public int IdAluno { get; set; }
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Esse campo tem tamanho máximo de 100 caracteres" )]
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "RA (Registro Acadêmico)")]
        [StringLength(10, ErrorMessage = "Esse campo tem tamanho máximo de 10 caracteres")]
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public string Ra { get; set; }

        [Display(Name = "Periodo")]
        public int? IdPeriodo { get; set; }
        [Display(Name = "Curso")]
        public int? IdCurso { get; set; }

        
        public PeriodoViewModel IdPeriodoNavigation { get; set; }        
        public CursoViewModel IdCursoNavigation { get; set; }
    }
}
