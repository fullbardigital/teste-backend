using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFullBar.Models
{
    public class Aluno
    {
        private int _idaluno;
        private string _nome;
        private string _ra;
        private int _idperiodo;
        private int _idcurso;

        private Periodo _periodo;
        private Curso _curso;
        private List<Aluno> _alunos;

        [Key]
        public int id { get => _idaluno; set => _idaluno = value; }

        [Required(ErrorMessage = "O Nome do Aluno é obrigatório.")]
        public string Nome { get => _nome; set => _nome = value; }

        [MaxLength(6)]
        [Required(ErrorMessage = "O RA do Aluno é obrigatório.")]
        public string RA { get => _ra; set => _ra = value; }

        [Display(Name = "Período")]
        [Range(1, int.MaxValue, ErrorMessage = "O Período é obrigatório")]
        public int idPeriodo { get => _idperiodo; set => _idperiodo = value; }

        [Display(Name = "Curso")]
        [Range(1, int.MaxValue, ErrorMessage = "O Curso é obrigatório")]
        public int idCurso { get => _idcurso; set => _idcurso = value; }

        public Periodo Periodo { get => _periodo; set => _periodo = value; }
        public Curso Curso { get => _curso; set => _curso = value; }
        public List<Aluno> Alunos { get => _alunos; set => _alunos = value; }
    }
}
