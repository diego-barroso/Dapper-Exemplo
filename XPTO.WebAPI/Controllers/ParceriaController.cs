using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPTO.WebAPI.Application;

namespace XPTO.WebAPI.Controllers
{
    public class ParceriaController : ApiController
    {
        private readonly ParceriaApplication _parceriaApplication;
        public ParceriaController() => _parceriaApplication = new ParceriaApplication();

        /// <summary>
        /// Chamada que retorna parcerias em que a data atual esteja entre a DataInicio e DataFim
        /// </summary>
        //https://localhost:44385/api/parceria
        [HttpGet]
        public HttpResponseMessage RetornaLista()
        {
            try
            {
                var parcerias = _parceriaApplication.CarregarListaParceriasVigentes(string.Empty);

                if(parcerias == null) 
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Não identificamos nenhuma parceria");

                return Request.CreateResponse(HttpStatusCode.Accepted, parcerias);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Chamada que retorna parcerias em que a data atual esteja entre a DataInicio e DataFim E que contenha o termo passado em Empresa ou Titulo
        /// </summary>
        //https://localhost:44354/api/parceria?termoBusca=hu
        [HttpGet]
        public HttpResponseMessage PesquisaParceria(string termoBusca)
        {
            try
            {
                var parcerias = _parceriaApplication.CarregarListaParceriasVigentes(termoBusca);

                if (parcerias == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Não identificamos nenhuma parceria");

                return Request.CreateResponse(HttpStatusCode.Accepted, parcerias);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Chamada que retorna parceria pelo código informado
        /// </summary>
        //https://localhost:44354/api/parceria/2
        [HttpGet]
        public HttpResponseMessage RetornaParceria(int id)
        {
            try
            {
                var parcerias = _parceriaApplication.CarregarParceria(id);

                if (parcerias == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Não identificamos a parceria solicitada");

                return Request.CreateResponse(HttpStatusCode.Accepted, parcerias);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}