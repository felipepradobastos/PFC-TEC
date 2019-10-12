using System;
using System.Collections.Generic;

namespace PFC.SGP.Domain.Entities
{
    public class Usuario : AbstractEntity
    {
        public Usuario()
        {
            this.DataCadastro = DateTime.Now;
        }

        public string Login { get; set; }
        
        public string Senha { get; set; }
        
        public string Codigo { get; set; }
        
        public string Nome { get; set; }
        
        public string Sobrenome { get; set; }
        
        public string Telefone { get; set; }
        
        public string Email { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

        public virtual ICollection<Orientador> Orientadores { get; set; } = new List<Orientador>();

        public override string ToString()
        {
            return this.Nome + " " + this.Sobrenome;
        }
    }
}
