
namespace sprint4.model
{
    public enum Perfil { Conservador, Moderado, Arrojado }
    public class Investimento
    {
        public int Id { get; set; }
        public string NomeInvestimento { get; set; }
        public decimal ValorAplicado { get; set; }
        public DateTime DataAplicacao { get; set; }

        public int ClienteId { get; set; } 
        public Cliente Cliente { get; set; } 

    }
}
