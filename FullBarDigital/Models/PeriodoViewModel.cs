using System;
using System.Collections.Generic;

namespace FullbarDigital.TESTE.Models
{
    public partial class PeriodoViewModel
    {
        public PeriodoViewModel()
        {
            TbAluno = new HashSet<AlunoViewModel>();
        }

        public int IdPeriodo { get; set; }
        public string Periodo { get; set; }

        public ICollection<AlunoViewModel> TbAluno { get; set; }
    }
}
