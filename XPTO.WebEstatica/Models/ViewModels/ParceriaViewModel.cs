using System;
using XPTO.WebEstatica.Utils;

namespace XPTO.WebEstatica.Models.ViewModels
{
    public class ParceriaViewModel: SerializableJsonObject<ParceriaViewModel>
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Empresa { get; set; }
        public String DataTermino { get; set; }
        public int QtdLikes { get; set; }
        public string URLPagina { get; set; }
    }
}