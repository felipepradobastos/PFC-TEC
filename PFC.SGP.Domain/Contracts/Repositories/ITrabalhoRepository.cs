using PFC.SGP.Domain.Entities;

namespace PFC.SGP.Domain.Contracts.Repositories
{
    public interface ITrabalhoRepository : IRepository<Trabalho>
    {
        //Custom Queries
        void Update(Trabalho entidadePersistida, Trabalho trab);
    }
}
