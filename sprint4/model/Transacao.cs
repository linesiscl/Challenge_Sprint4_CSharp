

namespace sprint4.model
{
    public enum TipoTransacao { Compra, Venda, Depósito, Saque }
    public class Transacao
    {
        public int Id { get; set; }
        public TipoTransacao Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int AccountId { get; set; }
        public Conta Conta { get; set; } = null!;
    }
}
