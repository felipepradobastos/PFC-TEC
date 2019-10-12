using System.Collections.Generic;
using System.Linq;
using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;

namespace PFC.SGP.Data.EF.Repositories
{
    public class TurmaRepositoryEF : RepositoryEF<Turma>, ITurmaRepository
    {
        public TurmaRepositoryEF(PFCSGPDataContext context) : base(context)
        {
        }

        public override IEnumerable<Turma> Find(string auth)
        {
            return _ctx.Turmas.Where(t => t.Curso.Coordenador.Login.Equals(auth));
        }
    }
}
