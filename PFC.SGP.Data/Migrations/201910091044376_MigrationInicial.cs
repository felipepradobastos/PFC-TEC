namespace PFC.SGP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Matricula = c.String(maxLength: 50, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        AnoMatricula = c.Int(nullable: false),
                        SemestreMatricula = c.Int(nullable: false),
                        AnoApresentacao = c.Int(nullable: false),
                        SemestreApresentacao = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Turma_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turma", t => t.Turma_Id, cascadeDelete: true)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "dbo.Trabalho",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Aluno_Id = c.Long(nullable: false),
                        Orientador_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aluno", t => t.Aluno_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orientador", t => t.Orientador_Id, cascadeDelete: true)
                .Index(t => t.Aluno_Id)
                .Index(t => t.Orientador_Id);
            
            CreateTable(
                "dbo.Orientador",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 50, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        CoordenadorId = c.Long(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.CoordenadorId, cascadeDelete: true)
                .Index(t => t.CoordenadorId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 88, fixedLength: true, unicode: false),
                        Codigo = c.String(maxLength: 50, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true)
                .Index(t => t.Codigo, unique: true);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        QtdSemestres = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Coordenador_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Coordenador_Id)
                .Index(t => t.Coordenador_Id);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Curso_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.Curso_Id, cascadeDelete: true)
                .Index(t => t.Curso_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "Turma_Id", "dbo.Turma");
            DropForeignKey("dbo.Trabalho", "Orientador_Id", "dbo.Orientador");
            DropForeignKey("dbo.Orientador", "CoordenadorId", "dbo.Usuario");
            DropForeignKey("dbo.Turma", "Curso_Id", "dbo.Curso");
            DropForeignKey("dbo.Curso", "Coordenador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Trabalho", "Aluno_Id", "dbo.Aluno");
            DropIndex("dbo.Turma", new[] { "Curso_Id" });
            DropIndex("dbo.Curso", new[] { "Coordenador_Id" });
            DropIndex("dbo.Usuario", new[] { "Codigo" });
            DropIndex("dbo.Usuario", new[] { "Login" });
            DropIndex("dbo.Orientador", new[] { "CoordenadorId" });
            DropIndex("dbo.Trabalho", new[] { "Orientador_Id" });
            DropIndex("dbo.Trabalho", new[] { "Aluno_Id" });
            DropIndex("dbo.Aluno", new[] { "Turma_Id" });
            DropTable("dbo.Turma");
            DropTable("dbo.Curso");
            DropTable("dbo.Usuario");
            DropTable("dbo.Orientador");
            DropTable("dbo.Trabalho");
            DropTable("dbo.Aluno");
        }
    }
}
