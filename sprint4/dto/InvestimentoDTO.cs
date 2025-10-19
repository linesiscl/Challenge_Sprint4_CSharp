
using sprint4.model;

namespace sprint4.dto
{
    public class InvestimentoDTO
    {
        public string NomeInvestimento { get; set; }
        public decimal ValorAplicado { get; set; }
        public DateTime DataAplicacao { get; set; }
        public int ClienteId { get; set; }

    }
}
