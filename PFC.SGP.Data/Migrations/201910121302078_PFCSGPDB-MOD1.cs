namespace PFC.SGP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PFCSGPDBMOD1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "AnoIngresso", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "MesIngresso", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "MesApresentacao", c => c.Int(nullable: false));
            DropColumn("dbo.Aluno", "AnoMatricula");
            DropColumn("dbo.Aluno", "SemestreMatricula");
            DropColumn("dbo.Aluno", "SemestreApresentacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "SemestreApresentacao", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "SemestreMatricula", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "AnoMatricula", c => c.Int(nullable: false));
            DropColumn("dbo.Aluno", "MesApresentacao");
            DropColumn("dbo.Aluno", "MesIngresso");
            DropColumn("dbo.Aluno", "AnoIngresso");
        }
    }
}
