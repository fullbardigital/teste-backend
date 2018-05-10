using System;
using System.Collections.Generic;
using System.Text;

namespace FabioRattis.TesteFullBar.Model.Entities
{
    public class TB_Curso
    {
        public int idCurso { get; set; }
        public string Curso { get; set; }
        public virtual ICollection<TB_Aluno> Alunos { get; set; }
    }
}
