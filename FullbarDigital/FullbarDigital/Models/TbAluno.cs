using System.ComponentModel.DataAnnotations;

namespace FullbarDigital.Models
{
    public partial class TbAluno
    {
        public int IdAluno { get; set; }
        [StringLength(100,ErrorMessage = "Tamanho máximo de 100 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Nome { get; set; }
        [StringLength(10, ErrorMessage = "Tamanho máximo de 10 caracteres")]
        [Required(ErrorMessage = "RA é obrigatorio")]
        public string Ra { get; set; }
        public int? IdPeriodo { get; set; }
        public int? IdCurso { get; set; }

        public TbPeriodo IdPeriodoNavigation { get; set; }
        public TbCurso IdCursoNavigation { get; set; }
    }
}
