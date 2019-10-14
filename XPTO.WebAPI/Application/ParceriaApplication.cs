using System.Collections.Generic;
using XPTO.Core.Domain;
using XPTO.WebAPI.Models.ViewModels;

namespace XPTO.WebAPI.Application
{
    public class ParceriaApplication
    {
        private readonly ParceriaDomain _parceriaDomain;

        public ParceriaApplication() => _parceriaDomain = new ParceriaDomain();

        public List<ParceriaViewModel> CarregarListaParceriasVigentes(string termoBusca)
        {
            var parceriasModel = _parceriaDomain.CarregarListaParceriasVigentes(termoBusca);

            var viewModel = new List<ParceriaViewModel>();

            foreach (var parceriaModel in parceriasModel)
            {
                var parceriaViewModel = new ParceriaViewModel()
                {
                    Codigo = parceriaModel.Codigo,
                    Titulo = parceriaModel.Titulo,
                    URLPagina = parceriaModel.URLPagina,
                    Empresa = parceriaModel.Empresa,
                    DataTermino = parceriaModel.DataTermino,
                    QtdLikes = parceriaModel.QtdLikes,
                };

                viewModel.Add(parceriaViewModel);
            }
            return viewModel;
        }

        public ParceriaViewModel CarregarParceria(int id)
        {
            var parceriaModel = _parceriaDomain.CarregarParceria(id);

            var viewModel = new ParceriaViewModel()
            {
                Codigo = parceriaModel.Codigo,
                Titulo = parceriaModel.Titulo,
                URLPagina = parceriaModel.URLPagina,
                Empresa = parceriaModel.Empresa,
                DataTermino = parceriaModel.DataTermino,
                QtdLikes = parceriaModel.QtdLikes
            };

            return viewModel;
        }
    }
}