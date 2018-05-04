using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFullBar.Models
{
    public class Periodo
    {
        private int _idperiodo;
        private string _nmperiodo;

        [Key]
        public int idPeriodo { get => _idperiodo; set => _idperiodo = value; }
        public string nmPeriodo { get => _nmperiodo; set => _nmperiodo = value; }
    }
}
