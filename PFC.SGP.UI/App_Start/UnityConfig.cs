using PFC.SGP.Data.EF;
using PFC.SGP.Data.EF.Repositories;
using PFC.SGP.Domain.Contracts.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PFC.SGP.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IUsuarioRepository, UsuarioRepositoryEF>();
            container.RegisterType<ICursoRepository, CursoRepositoryEF>();
            container.RegisterType<IAlunoRepository, AlunoRepositoryEF>();
            container.RegisterType<ITurmaRepository, TurmaRepositoryEF>();
            container.RegisterType<ITrabalhoRepository, TrabalhoRepositoryEF>();
            container.RegisterType<IOrientadorRepository, OrientadorRepositoryEF>();
            PFCSGPDataContext context = new PFCSGPDataContext();
            container.RegisterInstance<PFCSGPDataContext>(context);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}