using System.Collections.Generic;
using System.Linq;
using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;

namespace PFC.SGP.Data.EF.Repositories
{
    public class OrientadorRepositoryEF : RepositoryEF<Orientador>, IOrientadorRepository
    {
        public OrientadorRepositoryEF(PFCSGPDataContext context) : base(context)
        {
        }

        public override IEnumerable<Orientador> Find(string auth)
        {
            return _ctx.Orientadores.Where(o =>o.Coordenador.Login.Equals(auth));
        }

        public void Update(Orientador entidadePersistida, Orientador orientador)
        {
            long idAntigo = entidadePersistida.CoordenadorId;
            _ctx.Entry(entidadePersistida).CurrentValues.SetValues(orientador);
            entidadePersistida.CoordenadorId = idAntigo;
            _ctx.Entry(entidadePersistida).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
