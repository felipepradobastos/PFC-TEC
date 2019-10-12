using System.Data.Entity;
using PFC.SGP.Domain.Entities;

namespace PFC.SGP.Data.EF
{
    public class PFCSGPDataContext : DbContext
    {
        public PFCSGPDataContext():base("devConn")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Orientador> Orientadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Maps.AlunoMap());
            modelBuilder.Configurations.Add(new Maps.TrabalhoMap());
            modelBuilder.Configurations.Add(new Maps.UsuarioMap());
            modelBuilder.Configurations.Add(new Maps.CursoMap());
            modelBuilder.Configurations.Add(new Maps.TurmaMap());
            modelBuilder.Configurations.Add(new Maps.OrientadorMap());
        }
    }
}
