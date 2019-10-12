using PFC.SGP.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PFC.SGP.Data.EF.Maps
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            //Tabela
            ToTable(nameof(Turma));
            HasKey(pk => new { pk.Id });
            //Colunas
            Property(c => c.Codigo)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            //Property(c => c.QtdAlunos);
            Property(c => c.DataCadastro);
            //Relacionamentos
            HasRequired(turma => turma.Curso)
                .WithMany(curso => curso.Turmas);
        }
    }
}
