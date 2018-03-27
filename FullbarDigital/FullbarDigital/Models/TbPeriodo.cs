using System.Collections.Generic;

namespace FullbarDigital.Models
{
    public partial class TbPeriodo
    {
        public TbPeriodo()
        {
            TbAluno = new HashSet<TbAluno>();
        }

        public int IdPeriodo { get; set; }
        public string Periodo { get; set; }

        public ICollection<TbAluno> TbAluno { get; set; }
    }
}
