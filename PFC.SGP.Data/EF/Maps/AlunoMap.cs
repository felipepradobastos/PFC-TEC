using PFC.SGP.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PFC.SGP.Data.EF.Maps
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            //Tabela
            ToTable(nameof(Aluno));
            HasKey(pk => pk.Id);

            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Matricula)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(c => c.Sobrenome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(c => c.Status)
                .IsRequired();
            Property(c => c.Telefone)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(c => c.AnoIngresso)
                .IsRequired();
            Property(c => c.MesIngresso)
                .IsRequired();
            Property(c => c.DataCadastro);
            //Relacionamento
            HasRequired(aluno => aluno.Turma)
                .WithMany(turma => turma.Alunos);
        }
    }
}
