using System;
using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.ViewModels
{
    public class TrabalhoVM : AbstractEntity
    {
        public TrabalhoVM()
        {
            this.DataCadastro = DateTime.Now;
        }

        [StringLength(100,ErrorMessage = "Possui caracteres demais.")]
        [Required]
        public string Nome { get; set; }
        [Required]
        public String Correcao { get; set; }
        [Required]
        public String Apresentacao { get; set; }
        [Required]
        public AlunoVM Aluno { get; set; } = new AlunoVM();
        [Required]
        public OrientadorVM Orientador { get; set; } = new OrientadorVM();
        [Required]
        public String Turma { get; set; }
    }
}