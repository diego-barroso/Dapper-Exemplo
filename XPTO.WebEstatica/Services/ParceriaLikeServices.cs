using System;
using System.Configuration;
using System.Net.Http;
using XPTO.WebEstatica.Models.ViewModels;

namespace XPTO.WebEstatica.Services
{
    public class ParceriaLikeServices
    {
        private static readonly string _urlBase = ConfigurationManager.AppSettings.Get("XPTO.WebAPI.URL");

        public void CadastrarParceriaLike(int id)
        {
            var requestUri = $"{_urlBase}/api/parcerialike/{id}";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(requestUri);

                    var httpResponseMessage = httpClient.PostAsync(requestUri, null);
                    httpResponseMessage.Result.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}