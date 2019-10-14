using Dapper;
using XPTO.Core.Repository;

namespace XPTO.Core.Domain
{
    public class ParceriaLikeDomain
    {
        public void CadastrarParceriaLike(int id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@codigoParceria", id);

            GenericRepository.ExecutarStoredProcedure("spParceriaLike", param);
        }
    }
}