namespace FullBarDigital.Dominio.Entidades.Aluno
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }

        public string RA { get; set; }

        public int CodigoDoCurso { get; set; }

        public int CodigoDoPeriodo { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Periodo Periodo { get; set; }
    }
}