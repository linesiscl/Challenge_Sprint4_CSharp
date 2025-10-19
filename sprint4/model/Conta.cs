
using System.ComponentModel.DataAnnotations;


namespace sprint4.model
{
    public class Conta
    {
        public int Id { get; set; }
        [Required]
        public string NumConta { get; set; } = null!;
        public decimal Balance { get; set; } = 0m;


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}
