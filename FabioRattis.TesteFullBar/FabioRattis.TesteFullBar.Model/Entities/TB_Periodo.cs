using System;
using System.Collections.Generic;
using System.Text;

namespace FabioRattis.TesteFullBar.Model.Entities
{
    public class TB_Periodo
    {
        public int idPeriodo { get; set; }
        public string Periodo { get; set; }
        public virtual ICollection<TB_Aluno> Alunos { get; set; }
    }
}
