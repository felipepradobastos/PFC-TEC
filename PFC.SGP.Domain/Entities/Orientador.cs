using System;
using System.Collections.Generic;

namespace PFC.SGP.Domain.Entities
{
    public class Orientador: AbstractEntity
    {
        public Orientador()
        {
            this.DataCadastro = DateTime.Now;
        }

        public string Codigo { get; set; }
        
        public string Nome { get; set; }
        
        public string Sobrenome { get; set; }
        
        public string Telefone { get; set; }
        
        public string Email { get; set; }

        public virtual ICollection<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();

        public virtual long CoordenadorId { get; set; }
        public virtual Usuario Coordenador { get; set; }

        public override string ToString()
        {
            return this.Codigo +" - " + this.Nome + " " + this.Sobrenome;
        }
    }
}
