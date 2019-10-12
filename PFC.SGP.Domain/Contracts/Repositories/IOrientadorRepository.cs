using PFC.SGP.Domain.Entities;

namespace PFC.SGP.Domain.Contracts.Repositories
{
    public interface IOrientadorRepository : IRepository<Orientador>
    {
        //Custom Queries
        void Update(Orientador entidadePersistida, Orientador orientador);
    }
}
