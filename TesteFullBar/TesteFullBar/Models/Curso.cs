using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFullBar.Models
{
    public class Curso
    {
        private int _idcurso;
        private string _nmcurso;

        [Key]
        public int idCurso { get => _idcurso; set => _idcurso = value; }
        public string nmCurso { get => _nmcurso; set => _nmcurso = value; }

    }
}
