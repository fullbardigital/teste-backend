using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teste_Backend.Models
{
    public partial class TbAluno
    {
        public int IdAluno { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo do nome é de 100 caracteres")]
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; }
        [StringLength(10, ErrorMessage = "O RA possui apenas 10 caracteres")]
        [Required(ErrorMessage = "O RA é obrigatorio")]
        public string Ra { get; set; }

        public int? IdPeriodo { get; set; }
        public int? IdCurso { get; set; }

        public TbCurso IdCursoNavigation { get; set; }
        public TbPeriodo IdPeriodoNavigation { get; set; }
    }
}
