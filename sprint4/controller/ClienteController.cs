using Microsoft.AspNetCore.Mvc;
using sprint4.data;
using sprint4.dto;
using sprint4.model;
using Microsoft.EntityFrameworkCore;


namespace sprint4.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(AppDbContext context, ILogger<ClienteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAll()
        {
            var clientes = await _context.Cliente
                .Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    NomeCompleto = c.FullName,
                    Email = c.Email,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return NotFound();

            var dto = new ClienteDTO
            {
                Id = cliente.Id,
                NomeCompleto = cliente.FullName,
                Email = cliente.Email,
                CreatedAt = cliente.CreatedAt
            };
            return Ok(dto);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Search([FromQuery] string? nome, [FromQuery] string? email)
        {
            var query = _context.Cliente.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(c => c.FullName.Contains(nome));

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(c => c.Email.Contains(email));

            var result = await query
                .Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    NomeCompleto = c.FullName,
                    Email = c.Email,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Create([FromBody] CriaClienteDTO dto)
        {
            if (await _context.Cliente.AnyAsync(c => c.Email == dto.Email))
                return Conflict("Email já cadastrado.");

            var novo = new Cliente
            {
                FullName = dto.NomeCompleto,
                Email = dto.Email
            };

            _context.Cliente.Add(novo);
            await _context.SaveChangesAsync();

            var result = new ClienteDTO
            {
                Id = novo.Id,
                NomeCompleto = novo.FullName,
                Email = novo.Email,
                CreatedAt = novo.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = novo.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CriaClienteDTO dto)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return NotFound();

            cliente.FullName = dto.NomeCompleto;
            cliente.Email = dto.Email;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
