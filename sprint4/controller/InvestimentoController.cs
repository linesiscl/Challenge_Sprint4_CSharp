using Microsoft.AspNetCore.Mvc;
using sprint4.dto;
using sprint4.model;
using sprint4.service;


namespace sprint4.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IServiceInvest _service;
        private readonly ILogger<InvestimentoController> _logger;

        public InvestimentoController(IServiceInvest service, ILogger<InvestimentoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllWithClienteAsync();
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetInvestment")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdWithClienteAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? nome, [FromQuery] string? tipo, [FromQuery] decimal? qtdeMin, [FromQuery] Perfil? risco)
        {
            var results = await _service.SearchAsync(nome, tipo, qtdeMin, risco);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriaInvestimentoDTO dto)
        {
            var created = await _service.CreateForClienteAsync(dto);
            if (created == null)
                return NotFound($"Cliente com ID {dto.ClienteId} não encontrado.");

            return CreatedAtRoute("GetInvestment", new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CriaInvestimentoDTO dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
