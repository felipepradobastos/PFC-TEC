using PFC.SGP.UI.Validation;
using System.Web.Mvc;

namespace PFC.SGP.UI.Controllers
{
    [CustomAuthorize(Roles = "Administrador,Coordenador")]
    public class ErroController : Controller
    {
        public ActionResult Oops()
        {
            return View();
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
        public ActionResult E404()
        {
            return View();
        }
    }
}
