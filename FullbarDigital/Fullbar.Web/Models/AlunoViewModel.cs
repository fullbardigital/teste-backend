using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fullbar.Web.Models
{
    public class AlunoViewModel
    {
        public int IdAluno { get; set; }

        public string Nome { get; set; }

        public string Ra { get; set; }

        public int? IdPeriodo { get; set; }

        public string Periodo { get; set; }

        public int? IdCurso { get; set; }

        public string Curso { get; set; }

    }
}
