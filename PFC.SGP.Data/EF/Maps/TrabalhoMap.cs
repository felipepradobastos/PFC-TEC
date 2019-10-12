using PFC.SGP.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PFC.SGP.Data.EF.Maps
{
    public class TrabalhoMap : EntityTypeConfiguration<Trabalho>
    {
        public TrabalhoMap()
        {
            //Tabela
            ToTable(nameof(Trabalho));
            HasKey(pk => pk.Id);
            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(c => c.DataCadastro);
            //Relacionamentos
            HasRequired(trab => trab.Aluno)
                .WithMany(aluno => aluno.Trabalhos);
            HasRequired(trab => trab.Orientador)
                .WithMany(orientador => orientador.Trabalhos);
        }
    }
}
