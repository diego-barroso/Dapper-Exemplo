using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using XPTO.WebEstatica.Models.ViewModels;

namespace XPTO.WebEstatica.Services
{
    public class ParceriaServices
    {
        private static readonly string _urlBase = ConfigurationManager.AppSettings.Get("XPTO.WebAPI.URL");

        public List<ParceriaViewModel> CarregarListaParceriasVigentes(string termoBusca)
        {
            var requestUri = string.Empty;

            if(string.IsNullOrEmpty(termoBusca))
                requestUri = $"{_urlBase}/api/parceria/";
            else
                requestUri = $"{_urlBase}/api/parceria/?termoBusca={termoBusca}";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(requestUri);

                    var httpResponseMessage = httpClient.GetAsync(requestUri);
                    httpResponseMessage.Result.EnsureSuccessStatusCode();

                    return JsonConvert.DeserializeObject<List<ParceriaViewModel>>(httpResponseMessage.Result.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParceriaViewModel CarregarParceria(int id)
        {
            var requestUri = $"{_urlBase}/api/parceria/{id}";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(requestUri);

                    var httpResponseMessage = httpClient.GetAsync(requestUri);
                    httpResponseMessage.Result.EnsureSuccessStatusCode();

                    var teste = httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
                    var result = new ParceriaViewModel().Deserialize(httpResponseMessage.Result.Content.ReadAsStringAsync().Result);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}