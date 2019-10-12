using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PFC.SGP.Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(PFCSGPDataContext context) : base(context)
        {
        }

        public override IEnumerable<Usuario> Find(string auth)
        {
            return _ctx.Usuarios.Where(u => u.Login.Equals(auth));
        }
    }
}