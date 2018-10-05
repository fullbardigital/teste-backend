using System;
using System.Collections.Generic;

namespace FullbarDigital.TESTE.Models
{
    public partial class CursoViewModel
    {
        public int IdCurso { get; set; }
        public string Curso { get; set; }

        public CursoViewModel IdCursoNavigation { get; set; }
        public CursoViewModel InverseIdCursoNavigation { get; set; }
    }
}
