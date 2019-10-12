using PFC.SGP.Domain.Util;
using System;
using System.Collections.Generic;

namespace PFC.SGP.Domain.Entities
{
    public class Aluno : AbstractEntity
    {
        public Aluno()
        {
            this.Status = Constants.MATRICULADO;
            this.DataCadastro = DateTime.Now;
        }

        public string Matricula { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Status { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public int AnoIngresso { get; set; }

        public int MesIngresso { get; set; }

        public int AnoApresentacao { get; set; }

        public int MesApresentacao { get; set; }

        public virtual Turma Turma { get; set; }

        public virtual ICollection<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();

        public override string ToString()
        {
            return this.Matricula + " - " + this.Nome + " " + this.Sobrenome;
        }

        public string Ingresso()
        {
            return this.MesIngresso + "." + this.AnoIngresso;
        }
    }
}