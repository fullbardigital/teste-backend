using System;
using System.Collections.Generic;

namespace FullBar.Api.Models
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

        public int id { get => _idaluno; set => _idaluno = value; }
        //public int idAluno { get => _idaluno; set => _idaluno = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string RA { get => _ra; set => _ra = value; }
        public int idPeriodo { get => _idperiodo; set => _idperiodo = value; }
        public int idCurso { get => _idcurso; set => _idcurso = value; }

        public Periodo Periodo { get => _periodo; set => _periodo = value; }
        public Curso Curso { get => _curso; set => _curso = value; }
        public List<Aluno> Alunos { get => _alunos; set => _alunos = value; }
    }
}
