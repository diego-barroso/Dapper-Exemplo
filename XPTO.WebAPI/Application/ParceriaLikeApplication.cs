using System;
using XPTO.Core.Domain;

namespace XPTO.WebAPI.Application
{
    public class ParceriaLikeApplication
    {
        private readonly ParceriaLikeDomain _parceriaLikeDomain;
        private readonly ParceriaDomain _parceriaDomain;

        public ParceriaLikeApplication()
        {
            _parceriaLikeDomain = new ParceriaLikeDomain();
            _parceriaDomain = new ParceriaDomain();
        }

        public void CadastrarParceriaLike(int id)
        {
            ValidarCadastro(id);

            _parceriaLikeDomain.CadastrarParceriaLike(id);
        }

        private void ValidarCadastro(int id)
        {
            var parceria = _parceriaDomain.CarregarParceria(id);

            if (parceria == null)
                throw new InvalidOperationException("Não é possível dar like em uma parceria inexistente");

            if (!(Convert.ToDateTime(parceria.DataInicio) < DateTime.Now && Convert.ToDateTime(parceria.DataTermino) > DateTime.Now))
                throw new InvalidOperationException("Não é possível dar like em uma parceria que já acabou");
        }
    }
}