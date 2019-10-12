using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PFC.SGP.Data.EF.Repositories
{
    public class AlunoRepositoryEF : RepositoryEF<Aluno>, IAlunoRepository
    {
        public AlunoRepositoryEF(PFCSGPDataContext context) : base(context)
        {
        }

        public override IEnumerable<Aluno> Find(string auth)
        {
            return _ctx.Alunos.ToList().Where
                (a =>a.Turma.Curso.Coordenador.Login.Equals(auth));
        }

        public void Update(Aluno entidadePersistida, Aluno aluno, Turma turma)
        {
            _ctx.Entry(entidadePersistida).CurrentValues.SetValues(aluno);
            _ctx.Entry(entidadePersistida).State = System.Data.Entity.EntityState.Modified;
            _ctx.Entry(entidadePersistida).Reference(e => e.Turma).CurrentValue = turma;
            foreach (var trab in entidadePersistida.Trabalhos)
            {
                _ctx.Entry(trab).State = System.Data.Entity.EntityState.Modified;
            }
            _ctx.SaveChanges();
        }
    }
}
