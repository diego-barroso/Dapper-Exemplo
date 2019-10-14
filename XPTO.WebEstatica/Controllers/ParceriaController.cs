using System.Web.Mvc;
using XPTO.WebEstatica.Application;

namespace XPTO.WebEstatica.Controllers
{
    public class ParceriaController : Controller
    {
        private readonly ParceriaApplication _parceriaApplication;
        private readonly ParceriaLikeApplication _parceriaLikeApplication;

        public ParceriaController() 
        {
            _parceriaApplication = new ParceriaApplication();
            _parceriaLikeApplication = new ParceriaLikeApplication();
        }

        public ActionResult Index()
        {
            var vieModel = _parceriaApplication.CarregarParceria(2);
            return View();
        }

        public ActionResult Busca()
        {
            return View();
        }

        public ActionResult Listagem(string termoBusca)
        {
            var viewModel = _parceriaApplication.CarregarListaParceriasVigentes(termoBusca);
            return View(viewModel);
        }

        public ActionResult Detalhes(int id) 
        {
            var viewModel = _parceriaApplication.CarregarParceria(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Like(int codigo)
        {
            _parceriaLikeApplication.CadastrarParceriaLike(codigo);
            return RedirectToAction("Listagem");
        }
    }
}