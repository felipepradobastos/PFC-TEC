using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PFC.SGP.Data.EF.Repositories
{
    public class CursoRepositoryEF : RepositoryEF<Curso>, ICursoRepository
    {
        public CursoRepositoryEF(PFCSGPDataContext context) : base(context)
        {
        }

        public override IEnumerable<Curso> Find(string auth)
        {
            return _ctx.Cursos.Where(c => c.Coordenador.Login.Equals(auth));
        }
    }
}
