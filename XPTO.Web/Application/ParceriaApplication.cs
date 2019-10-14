using System;
using System.Collections.Generic;
using XPTO.Core.Domain;
using XPTO.Core.Model;
using XPTO.Web.Models.ViewModels;

namespace XPTO.Web.Application
{
    public class ParceriaApplication
    {
        private readonly ParceriaDomain _parceriaDomain;

        public ParceriaApplication()
        {
            _parceriaDomain = new ParceriaDomain();
        }

        public List<ParceriaViewModel> CarregarListaParcerias()
        {
            var parceriasModel = _parceriaDomain.CarregarListaParcerias();
            var viewModel = new List<ParceriaViewModel>();

            foreach (var parceriaModel in parceriasModel)
            {
                var parceriaViewModel = new ParceriaViewModel()
                {
                    Codigo = parceriaModel.Codigo,
                    Titulo = parceriaModel.Titulo,
                    Descricao = parceriaModel.Descricao,
                    URLPagina = parceriaModel.URLPagina,
                    Empresa = parceriaModel.Empresa,
                    DataInicio = parceriaModel.DataInicio,
                    DataTermino = parceriaModel.DataTermino,
                    QtdLikes = parceriaModel.QtdLikes,
                    DataHoraCadastro = parceriaModel.DataHoraCadastro
                };

                CarregarPermissoes(parceriaViewModel);

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
                Descricao = parceriaModel.Descricao,
                URLPagina = parceriaModel.URLPagina,
                Empresa = parceriaModel.Empresa,
                DataInicio = parceriaModel.DataInicio,
                DataTermino = parceriaModel.DataTermino,
                QtdLikes = parceriaModel.QtdLikes,
                DataHoraCadastro = parceriaModel.DataHoraCadastro
            };

            CarregarPermissoes(viewModel);

            return viewModel;
        }

        private void CarregarPermissoes(ParceriaViewModel viewModel)
        {
            viewModel.PermissoesParceria.Editar = true;
            viewModel.PermissoesParceria.Remover = viewModel.QtdLikes == 0;
        }

        public List<MensagemValidacao> CadastrarParceria(ParceriaViewModel parceriaViewModel)
        {
            List<MensagemValidacao> mensagens = ValidarCadastro(parceriaViewModel);

            if (mensagens.Count > 0)
                return mensagens;

            var parceriaModel = new ParceriaModel()
            {
                Codigo = parceriaViewModel.Codigo,
                Titulo = parceriaViewModel.Titulo,
                Descricao = parceriaViewModel.Descricao,
                URLPagina = parceriaViewModel.URLPagina,
                Empresa = parceriaViewModel.Empresa,
                DataInicio = parceriaViewModel.DataInicio,
                DataTermino = parceriaViewModel.DataTermino,
                QtdLikes = parceriaViewModel.QtdLikes,
                DataHoraCadastro = parceriaViewModel.DataHoraCadastro
            };

            _parceriaDomain.ExecutarAcao(parceriaModel, "INSERT");

            return mensagens;
        }

        public List<MensagemValidacao> EditarParceria(ParceriaViewModel parceriaViewModel)
        {
            List<MensagemValidacao> mensagens = ValidarEdicao(parceriaViewModel);

            if (mensagens.Count > 0)
                return mensagens;

            var parceriaModel = new ParceriaModel()
            {
                Codigo = parceriaViewModel.Codigo,
                Titulo = parceriaViewModel.Titulo,
                Descricao = parceriaViewModel.Descricao,
                URLPagina = parceriaViewModel.URLPagina,
                Empresa = parceriaViewModel.Empresa,
                DataInicio = parceriaViewModel.DataInicio,
                DataTermino = parceriaViewModel.DataTermino,
                QtdLikes = parceriaViewModel.QtdLikes,
                DataHoraCadastro = parceriaViewModel.DataHoraCadastro
            };

            _parceriaDomain.ExecutarAcao(parceriaModel, "UPDATE");

            return mensagens;
        }

        public void RemoverParceria(int id)
        {
            var parceria = CarregarParceria(id);
            CarregarPermissoes(parceria);

            if (!parceria.PermissoesParceria.Remover)
                throw new Exception("Parceria não pode ser removida");

            var parceriaModel = new ParceriaModel()
            {
                Codigo = id,
                Titulo = string.Empty,
                Descricao = string.Empty,
                URLPagina = string.Empty,
                Empresa = string.Empty,
                DataInicio = DateTime.Now.ToString(),
                DataTermino = DateTime.Now.ToString(),
                QtdLikes = 0,
                DataHoraCadastro = DateTime.Now
            };

            _parceriaDomain.ExecutarAcao(parceriaModel, "DELETE");
        }

        private List<MensagemValidacao> ValidarCadastro(ParceriaViewModel parceriaViewModel)
        {
            var mensagens = new List<MensagemValidacao>();

            ValidarTitulo(parceriaViewModel, mensagens);
            ValidarDataMaior(parceriaViewModel, mensagens);
            ValidarDataDiferenca(parceriaViewModel, mensagens);

            return mensagens;
        }

        private List<MensagemValidacao> ValidarEdicao(ParceriaViewModel parceriaViewModel)
        {
            var mensagens = new List<MensagemValidacao>();

            ValidarNovoTitulo(parceriaViewModel, mensagens);
            ValidarDataMaior(parceriaViewModel, mensagens);
            ValidarDataDiferenca(parceriaViewModel, mensagens);

            return mensagens;
        }

        private void ValidarNovoTitulo(ParceriaViewModel parceriaViewModel, List<MensagemValidacao> mensagens)
        {
            var parceria = CarregarListaParcerias().FindLast(x => x.Titulo == parceriaViewModel.Titulo);
            if (parceria != null && parceria.Codigo != parceriaViewModel.Codigo)
                mensagens.Add(new MensagemValidacao
                {
                    Campo = "Titulo",
                    Texto = "Novo titulo já existe em outra parceria."
                });
        }

        private void ValidarTitulo(ParceriaViewModel parceriaViewModel, List<MensagemValidacao> mensagens)
        {
            var parceria = CarregarListaParcerias().FindLast(x => x.Titulo == parceriaViewModel.Titulo);
            if (parceria != null)
                mensagens.Add(new MensagemValidacao
                {
                    Campo = "Titulo",
                    Texto = "Não pode ter dois cadastros com o mesmo título."
                });
        }

        private static void ValidarDataDiferenca(ParceriaViewModel parceriaViewModel, List<MensagemValidacao> mensagens)
        {
            if ((Convert.ToDateTime(parceriaViewModel.DataTermino) - Convert.ToDateTime(parceriaViewModel.DataInicio)).Days < 5)
                mensagens.Add(new MensagemValidacao
                {
                    Campo = "DataTermino",
                    Texto = "A diferença entre as datas de início e término, tem que ser 5 ou mais dias."
                });
        }

        private static void ValidarDataMaior(ParceriaViewModel parceriaViewModel, List<MensagemValidacao> mensagens)
        {
            if (Convert.ToDateTime(parceriaViewModel.DataInicio) > Convert.ToDateTime(parceriaViewModel.DataTermino))
                mensagens.Add(new MensagemValidacao
                {
                    Campo = "DataInicio",
                    Texto = "A Data de início tem que ser menor que a data de término."
                });
        }
    }
}