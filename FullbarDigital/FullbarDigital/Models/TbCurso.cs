using System.Collections.Generic;

namespace FullbarDigital.Models
{
    public partial class TbCurso
    {
        public TbCurso()
        {
            TbAluno = new HashSet<TbAluno>();
        }
        public int IdCurso { get; set; }
        public string Curso { get; set; }

        public TbCurso IdCursoNavigation { get; set; }
        public TbCurso InverseIdCursoNavigation { get; set; }

        public ICollection<TbAluno> TbAluno { get; set; }
    }
}
