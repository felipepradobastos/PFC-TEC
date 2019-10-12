using PFC.SGP.Domain.Entities;
using PFC.SGP.Domain.Security;
using System.Data.Entity;

namespace PFC.SGP.Data.EF
{
    internal class DbInitializer : CreateDatabaseIfNotExists<PFCSGPDataContext>
    {
        protected override void Seed(PFCSGPDataContext context)
        {
            //context.Usuarios.Add(
            //    new Usuario()
            //    {
            //        Login = "admin",
            //        Senha = "admin".Encrypt(),
            //        Codigo = "000",
            //        Nome = "Administrador",
            //        Sobrenome = "Do sistema",
            //        Email = "admin@sgpadmin.com",
            //        Telefone = "(55)95555-5555",
            //    }
            //);
            //context.SaveChanges();
        }
    }
}