using System;

namespace XPTO.WebAPI.Models.ViewModels
{
    public class ParceriaViewModel
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Empresa { get; set; }
        public String DataTermino { get; set; }
        public int QtdLikes { get; set; }
        public string URLPagina { get; set; }
    }
}