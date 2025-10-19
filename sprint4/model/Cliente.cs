
using System.ComponentModel.DataAnnotations;


namespace sprint4.model
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Conta> Conta { get; set; } = new List<Conta>();

    }
}
