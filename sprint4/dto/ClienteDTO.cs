

namespace sprint4.dto
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
