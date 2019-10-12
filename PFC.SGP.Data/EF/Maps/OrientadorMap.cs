using PFC.SGP.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PFC.SGP.Data.EF.Maps
{
    public class OrientadorMap : EntityTypeConfiguration<Orientador>
    {
        public OrientadorMap()
        {
            //Tabela
            ToTable(nameof(Orientador));
            HasKey(pk => pk.Id);
            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Codigo)
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
            Property(c => c.Telefone)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(c => c.DataCadastro);
            Property(c => c.CoordenadorId);
            //Relacionamentos
            HasRequired(o => o.Coordenador)
                .WithMany(c => c.Orientadores)
                .HasForeignKey(o => o.CoordenadorId);
        }
    }
}
