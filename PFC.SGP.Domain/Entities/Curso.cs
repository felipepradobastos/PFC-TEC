using System;
using System.Collections.Generic;

namespace PFC.SGP.Domain.Entities
{
    public class Curso : AbstractEntity
    {
        public Curso()
        {
            this.DataCadastro = DateTime.Now;
        }

        public string Nome { get; set; }

        public int QtdSemestres { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; } = new List<Turma>();

        public virtual Usuario Coordenador { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
