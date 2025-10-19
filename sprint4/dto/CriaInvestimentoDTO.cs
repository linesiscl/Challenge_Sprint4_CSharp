
using sprint4.model;

namespace sprint4.dto
{
    public class CriaInvestimentoDTO
    {
        public string NomeInvestimento { get; set; }
        public decimal ValorAplicado { get; set; }

        public int ClienteId { get; set; }
    }
}
