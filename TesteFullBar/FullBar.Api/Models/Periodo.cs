using System.ComponentModel.DataAnnotations;

namespace FullBar.Api.Models
{
    public class Periodo
    {
        private int _idperiodo;
        private string _nmperiodo;

        public int idPeriodo { get => _idperiodo; set => _idperiodo = value; }
        public string nmPeriodo { get => _nmperiodo; set => _nmperiodo = value; }
    }
}
