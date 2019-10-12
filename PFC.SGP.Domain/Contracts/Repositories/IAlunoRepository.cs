using PFC.SGP.Domain.Entities;
using System.Collections.Generic;

namespace PFC.SGP.Domain.Contracts.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        //Custom Queries
        void Update(Aluno entidadePersistida, Aluno aluno, Turma turma);
    }
}
