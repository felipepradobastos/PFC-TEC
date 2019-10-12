using PFC.SGP.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PFC.SGP.Data.EF.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Tabela
            ToTable(nameof(Usuario));
            HasKey(pk => pk.Id);
            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Codigo)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(new IndexAttribute() { IsUnique = true })
                );
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
            Property(c => c.Login)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(new IndexAttribute() { IsUnique = true })
                );
            Property(c => c.Senha)
                .HasColumnType("char")
                .HasMaxLength(88)
                .IsRequired();
            Property(c => c.DataCadastro);
            //Relacionamentos
        }
    }
}
