using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using XPTO.Core.Model;
using XPTO.Core.Repository;

namespace XPTO.Core.Domain
{
    public class ParceriaDomain
    {
        public IEnumerable<ParceriaModel> CarregarListaParcerias()
        {
            return GenericRepository.ExecutarQuery<ParceriaModel>("select * from vParceria");
        }

        public IEnumerable<ParceriaModel> CarregarListaParceriasVigentes(string termoBusca)
        {
            if (string.IsNullOrEmpty(termoBusca))
                return GenericRepository.ExecutarQuery<ParceriaModel>("select * from vParceriaVigente");
            else
                return GenericRepository.ExecutarQuery<ParceriaModel>("select * from vParceriaVigente").Where(x=> x.Titulo.Contains(termoBusca) || x.Empresa.Contains(termoBusca));
        }

        public ParceriaModel CarregarParceria(int id)
        {
            return GenericRepository.ExecutarQuery<ParceriaModel>("select * from vParceria").Where(x => x.Codigo == id).FirstOrDefault();
        }

        public void ExecutarAcao(ParceriaModel parceriaModel, string acao)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@acao", acao);
            param.Add("@codigo", parceriaModel.Codigo);
            param.Add("@titulo", parceriaModel.Titulo);
            param.Add("@descricao", parceriaModel.Descricao);
            param.Add("@urlPagina", parceriaModel.URLPagina);
            param.Add("@empresa", parceriaModel.Empresa);
            param.Add("@dataInicio", Convert.ToDateTime(parceriaModel.DataInicio));
            param.Add("@dataTermino", Convert.ToDateTime(parceriaModel.DataTermino));
            param.Add("@qtdLikes", parceriaModel.QtdLikes);
            param.Add("@dataHoraCadastro", DateTime.Now);

            GenericRepository.ExecutarStoredProcedure("spParceria", param);
        }
    }
}