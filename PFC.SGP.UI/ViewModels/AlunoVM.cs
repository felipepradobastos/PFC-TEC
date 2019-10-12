using PFC.SGP.UI.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.ViewModels
{
    public class AlunoVM : AbstractEntity
    {
        public AlunoVM()
        {
            this.DataCadastro = DateTime.Now;
        }

        [RegularExpression(@"^(([a-zA-Z0-9\u00C0-\u00FF]{1})+)$",
            ErrorMessage = "Esta não parece uma matricula válida, digite apenas a matricula, sem espaços.")]
        [StringLength(50)]
        [Required]
        public string Matricula { get; set; }
        
        [RegularExpression(@"^(([a-zA-Z\u00C0-\u00FF]{2,})+( ?[a-zA-Z\u00C0-\u00FF]+)+)$",
            ErrorMessage = "Este não parece um nome válido.")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [RegularExpression(@"^(([a-zA-Z\u00C0-\u00FF]{2,})+( ?[a-zA-Z\u00C0-\u00FF]+)+)$",
            ErrorMessage = "Este não parece um sobrenome válido.")]
        [StringLength(80)]
        [Required]
        public string Sobrenome { get; set; }

        public int Status { get; set; }

        [RegularExpression(@"(?:^\([0]?[1-9]{2}\)|^[0]?[1-9]{2}[\.-]?)[9]?[1-9]\d{3}[\.-]?\d{4}$",
            ErrorMessage = "Este não é um número válido.")]
        [StringLength(20)]
        [Required]
        public string Telefone { get; set; }

        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b",
            ErrorMessage = "Este não é um e-mail válido.")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [MinValue(2000, ErrorMessage = "O valor mínimo é 2000"), MaxValue(2090, ErrorMessage = "O valor é alto demais")]
        [Required]
        public int AnoIngresso { get; set; }

        [MinValue(1, ErrorMessage = "O valor mínimo é 1"), MaxValue(12, ErrorMessage = "O valor máximo é 12")]
        [Required]
        public int MesIngresso { get; set; }

        [MinValue(2000, ErrorMessage = "O valor mínimo é 2000"), MaxValue(2090, ErrorMessage = "O valor é alto demais")]
        [Required]
        public int AnoApresentacao { get; set; }

        [MinValue(1, ErrorMessage = "O valor mínimo é 1"), MaxValue(12, ErrorMessage = "O valor máximo é 12")]
        [Required]
        public int MesApresentacao { get; set; }

        [Required]
        public string Turma { get; set; }

        public override string ToString()
        {
            return this.Matricula + " - " + this.Nome + " " + this.Sobrenome;
        }

        public string Ingresso()
        {
            return this.MesIngresso + "/" + this.AnoIngresso;
        }
    }
}
