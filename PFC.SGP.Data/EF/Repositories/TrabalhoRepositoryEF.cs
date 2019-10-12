using System.Collections.Generic;
using System.Linq;
using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;

namespace PFC.SGP.Data.EF.Repositories
{
    public class TrabalhoRepositoryEF : RepositoryEF<Trabalho>, ITrabalhoRepository
    {
        public TrabalhoRepositoryEF(PFCSGPDataContext context) : base(context)
        {
        }

        public override IEnumerable<Trabalho> Find(string auth)
        {
            return _ctx.Trabalhos.Where(t => t.Aluno.Turma.Curso.Coordenador.Login.Equals(auth));
        }

        public void Update(Trabalho entidadePersistida, Trabalho trab)
        {
            _ctx.Entry(entidadePersistida).CurrentValues.SetValues(trab);
            _ctx.Entry(entidadePersistida).Reference(e => e.Aluno).CurrentValue = trab.Aluno;
            _ctx.Entry(entidadePersistida).Reference(e => e.Orientador).CurrentValue = trab.Orientador;
            _ctx.Entry(entidadePersistida).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
