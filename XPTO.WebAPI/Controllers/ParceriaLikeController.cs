using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPTO.WebAPI.Application;

namespace XPTO.WebAPI.Controllers
{
    public class ParceriaLikeController : ApiController
    {
        private readonly ParceriaLikeApplication _parceriaLikeApplication;

        public ParceriaLikeController()
        {
            _parceriaLikeApplication = new ParceriaLikeApplication();
        }

        /// <summary>
        /// Chamada que recebe Codigo de Parceria e realiza cadastro na tabela “ParceriaLike”.
        /// </summary>
        //https://localhost:44354/api/parcerialike/2
        [HttpPost]
        public HttpResponseMessage CadastrarLike(int id)
        {
            try
            {
                _parceriaLikeApplication.CadastrarParceriaLike(id);
                return Request.CreateResponse(HttpStatusCode.Accepted, "Cadastro realizado com sucesso!");
            }
            catch (InvalidOperationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Não foi possível realizar seu cadastro: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}