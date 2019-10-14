using System;

namespace XPTO.Core.Model
{
    public class ParceriaModel
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string URLPagina { get; set; }
        public string Empresa { get; set; }
        public String DataInicio { get; set; }
        public String DataTermino { get; set; }
        public int QtdLikes { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}