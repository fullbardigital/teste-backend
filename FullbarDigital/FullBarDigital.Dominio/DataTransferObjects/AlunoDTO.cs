namespace FullBarDigital.Dominio.DataTransferObjects
{
    public class AlunoDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public int CodigoDoCurso { get; set; }
        public string NomeDoCurso { get; set; }
        public int CodigoDoPeriodo { get; set; }
        public string NomeDoPeriodo { get; set; }
    }
}