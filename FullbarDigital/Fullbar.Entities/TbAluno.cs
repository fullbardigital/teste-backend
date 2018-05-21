using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Fullbar.Entities
{
    public partial class TbAluno
    {
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Ra { get; set; }

        [Required]
        public int? IdPeriodo { get; set; }

        [Required]
        public int? IdCurso { get; set; }

        [JsonIgnore]
        public TbPeriodo IdPeriodoNavigation { get; set; }
    }
}
