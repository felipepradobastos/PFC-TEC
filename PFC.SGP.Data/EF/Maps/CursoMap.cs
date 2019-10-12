using PFC.SGP.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PFC.SGP.Data.EF.Maps
{
    public class CursoMap : EntityTypeConfiguration<Curso>
    {
        public CursoMap()
        {
            //Tabela
            ToTable(nameof(Curso));
            HasKey(pk => pk.Id);
            //Colunas
            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(c => c.QtdSemestres);
            Property(c => c.DataCadastro);
            //Relacionamentos
            HasOptional(curso => curso.Coordenador)
                .WithMany(coord => coord.Cursos);
        }
    }
}
