using System;
using System.Web.Mvc;
using XPTO.Web.Application;
using XPTO.Web.Models.ViewModels;

namespace XPTO.Web.Controllers
{
    public class ParceriaController : Controller
    {
        private readonly ParceriaApplication _parceriaApplication;

        public ParceriaController()
        {
            _parceriaApplication = new ParceriaApplication();
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var viewModel = _parceriaApplication.CarregarListaParcerias();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(ParceriaViewModel parceriaViewModel)
        {
            try
            {
                var mensagensDeValidacao = _parceriaApplication.CadastrarParceria(parceriaViewModel);

                if (mensagensDeValidacao.Count > 0)
                    return RetornaViewComValidacoes(mensagensDeValidacao);
                else
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Editar(int id = 0)
        {
            try
            {
                return View(_parceriaApplication.CarregarParceria(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Editar(ParceriaViewModel parceriaViewModel)
        {
            try
            {
                var mensagensDeValidacao = _parceriaApplication.EditarParceria(parceriaViewModel);

                if (mensagensDeValidacao.Count > 0)
                    return RetornaViewComValidacoes(mensagensDeValidacao);
                else
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            try
            {
                return View(_parceriaApplication.CarregarParceria(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult RemoverConfirma(int codigo)
        {
            try
            {
                _parceriaApplication.RemoverParceria(codigo);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ActionResult RetornaViewComValidacoes(System.Collections.Generic.List<MensagemValidacao> mensagensDeValidacao)
        {
            foreach (var mensagem in mensagensDeValidacao)
            {
                ModelState.AddModelError(mensagem.Campo, mensagem.Texto);
            }

            return View();
        }
    }
}