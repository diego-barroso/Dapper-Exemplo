using System.Web.Mvc;

namespace XPTO.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Web API de Parcerias";

            return View();
        }
    }
}
