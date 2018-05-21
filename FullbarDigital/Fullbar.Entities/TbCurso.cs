using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Fullbar.Entities
{
    public partial class TbCurso
    {
        public int IdCurso { get; set; }

        [Required]
        public string Curso { get; set; }

        [JsonIgnore]
        public TbCurso IdCursoNavigation { get; set; }

        [JsonIgnore]
        public TbCurso InverseIdCursoNavigation { get; set; }
    }
}
