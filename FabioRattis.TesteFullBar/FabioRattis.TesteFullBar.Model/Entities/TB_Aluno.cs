using System;
using System.Collections.Generic;
using System.Text;

namespace FabioRattis.TesteFullBar.Model.Entities
{
    public class TB_Aluno
    {

        public int idAluno { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public int idPeriodo { get; set; }
        public int idCurso { get; set; }
        public virtual TB_Curso Curso { get; set; }
        public virtual TB_Periodo Periodo { get; set; }

        public string Validar()
        {
            string Erro = "";
            if (string.IsNullOrEmpty(this.Nome))
            {
                Erro += "* Por Favor Preencher Nome! <br />";
            }
            if (string.IsNullOrEmpty(this.RA))
            {
                Erro += "* Por Favor Preencher RA! <br />";
            }
            if (this.idCurso <= -1)
            {
                Erro += "* Por Favor Escolher um Curso! <br />";
            }
            if (this.idPeriodo <= -1)
            {
                Erro += "* Por Favor Escolher um Período!";
            }

            return Erro;
        }
    }
}
