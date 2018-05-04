using System.ComponentModel.DataAnnotations;

namespace FullBar.Api.Models
{
    public class Curso
    {
        private int _idcurso;
        private string _nmcurso;

        public int idCurso { get => _idcurso; set => _idcurso = value; }
        public string nmCurso { get => _nmcurso; set => _nmcurso = value; }

    }
}
