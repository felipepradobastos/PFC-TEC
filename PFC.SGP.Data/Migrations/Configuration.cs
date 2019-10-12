namespace PFC.SGP.Data.Migrations
{
    using PFC.SGP.Domain.Entities;
    using PFC.SGP.Domain.Security;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PFC.SGP.Data.EF.PFCSGPDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PFC.SGP.Data.EF.PFCSGPDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Usuario admin = new Usuario()
            {
                Login = "admin",
                Senha = "admin".Encrypt(),
                Codigo = "000",
                Nome = "Administrador",
                Sobrenome = "Do sistema",
                Email = "admin@sgpadmin.com",
                Telefone = "(55)95555-5555"
            };
            context.Usuarios.AddOrUpdate(admin);
            context.SaveChanges();
        }
    }
}
