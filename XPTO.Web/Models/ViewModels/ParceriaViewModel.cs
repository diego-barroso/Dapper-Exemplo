using System;
using System.ComponentModel.DataAnnotations;

namespace XPTO.Web.Models.ViewModels
{
    public class ParceriaViewModel
    {
        [Display(Name = "Código da parceria")]
        public int Codigo { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Título deve ser preenchido.")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição deve ser preenchid0.")]
        public string Descricao { get; set; }

        [Display(Name = "Link da página")]
        public string URLPagina { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Empresa deve ser preenchido.")]
        public string Empresa { get; set; }

        [Display(Name = "Data início")]
        [Required(ErrorMessage = "Data início deve ser preenchida.")]
        [RegularExpression(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$", ErrorMessage = "Data início invalida.")]
        public String DataInicio { get; set; }

        [Display(Name = "Data término")]
        [Required(ErrorMessage = "Data término deve ser preenchida.")]
        [RegularExpression(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$", ErrorMessage = "Data início invalida.")]
        public String DataTermino { get; set; }

        [Display(Name = "Qtd. likes")]
        public int QtdLikes { get; set; }

        [Display(Name = "Data cadastro")]
        public DateTime DataHoraCadastro { get; set; }

        public Permissoes PermissoesParceria;

        public ParceriaViewModel()
        {
            PermissoesParceria = new Permissoes();
        }
    }
}