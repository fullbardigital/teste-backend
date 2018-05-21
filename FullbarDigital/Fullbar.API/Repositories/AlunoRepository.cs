using Fullbar.API.Repositories.Interfaces;
using Fullbar.API.ViewModel;
using Fullbar.Core.Repositories;
using Fullbar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fullbar.API.Repositories
{
    public class AlunoRepository : RepositoryBase<TbAluno, DB_TESTEContext>,
                                   IAlunoRepository
    {
        public AlunoRepository(DB_TESTEContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AlunoViewModel>> GetAlunosDetalhado()
        {
            return await (from a in _context.TbAluno
                          join c in _context.TbCurso on a.IdCurso equals c.IdCurso
                          join p in _context.TbPeriodo on a.IdPeriodo equals p.IdPeriodo
                          select new AlunoViewModel
                          {
                              IdAluno   = a.IdAluno,
                              Nome      = a.Nome,
                              Ra        = a.Ra,
                              IdCurso   = c.IdCurso,
                              Curso     = c.Curso,
                              IdPeriodo = p.IdPeriodo,
                              Periodo   = p.Periodo
                          }).ToListAsync();
        }
    }
}
