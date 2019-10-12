using System.Web.Mvc;

namespace PFC.SGP.UI.Validation
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //se não estiver logado, o comportamento desse atributo será o padrão e redicionará ao login
                base.HandleUnauthorizedRequest(filterContext);

            }
            else
            {
                //logado e sem a role que dá acesso - redireciona para uma rota customizada
                filterContext.Result = new RedirectResult("~/Erro/Unauthorized");
            }
        }
    }
}
