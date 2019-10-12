using System;
using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.ViewModels
{
    public class AbstractEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
