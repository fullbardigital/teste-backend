using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fullbar.Entities
{
    public partial class TbPeriodo
    {
        public TbPeriodo()
        {
            TbAluno = new HashSet<TbAluno>();
        }

        public int IdPeriodo { get; set; }

        [Required]
        public string Periodo { get; set; }

        [JsonIgnore]
        public ICollection<TbAluno> TbAluno { get; set; }
    }
}
