using System;
using System.Collections.Generic;
using XPTO.WebEstatica.Models.ViewModels;
using XPTO.WebEstatica.Services;

namespace XPTO.WebEstatica.Application
{
    public class ParceriaApplication
    {
        private readonly ParceriaServices _parceriaServices;

        public ParceriaApplication() => _parceriaServices = new ParceriaServices();

        public List<ParceriaViewModel> CarregarListaParceriasVigentes(string termoBusca)
        {
            var parceriasViewModel = _parceriaServices.CarregarListaParceriasVigentes(termoBusca);
            //return viewModel;
            return parceriasViewModel;
        }

        public ParceriaViewModel CarregarParceria(int id)
        {
            return _parceriaServices.CarregarParceria(id);
        }
    }
}