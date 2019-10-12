using System;
using System.Collections.Generic;
using System.Linq;

namespace PFC.SGP.Domain.Entities
{
    public class Turma : AbstractEntity
    {
        public Turma()
        {
            this.DataCadastro = DateTime.Now;
        }

        public string Codigo { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
        
        public virtual Curso Curso { get; set; }

        public override string ToString()
        {
            return this.Codigo;
        }

        public long AlunosCadastrados()
        {
            return this.Alunos
                        .Count;
        }
    }
}
