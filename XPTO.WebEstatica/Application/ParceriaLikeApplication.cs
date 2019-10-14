using XPTO.WebEstatica.Services;

namespace XPTO.WebEstatica.Application
{
    public class ParceriaLikeApplication
    {
        private readonly ParceriaLikeServices _parceriaLikeServices;

        public ParceriaLikeApplication() => _parceriaLikeServices = new ParceriaLikeServices();

        public void CadastrarParceriaLike(int id)
        {
            _parceriaLikeServices.CadastrarParceriaLike(id);
        }

    }
}