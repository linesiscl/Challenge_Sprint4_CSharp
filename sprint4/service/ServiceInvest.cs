using sprint4.model;
using sprint4.dto;
using sprint4.repository;

namespace sprint4.service
{
    public class ServiceInvest : IServiceInvest
    {
        private readonly RepositorioInvest _repo;
        private readonly IRepositorio<Cliente> _repoCliente;

        public ServiceInvest(RepositorioInvest repo, IRepositorio<Cliente> repoCliente)
        {
            _repo = repo;
            _repoCliente = repoCliente;
        }

        public async Task<Investimento?> CreateForClienteAsync(CriaInvestimentoDTO dto)
        {
            var cliente = await _repoCliente.GetByIdAsync(dto.ClienteId);
            if (cliente == null)
                return null;

            var investimento = new Investimento
            {
                NomeInvestimento = dto.NomeInvestimento,
                ValorAplicado = dto.ValorAplicado,
                DataAplicacao = DateTime.Now,
                ClienteId = dto.ClienteId,
                Cliente = cliente
            };

            await _repo.AddAsync(investimento);
            await _repo.SaveChangesAsync();
            return investimento;
        }

        public async Task<Investimento> CreateAsync(Investimento investment)
        {
            await _repo.AddAsync(investment);
            await _repo.SaveChangesAsync();
            return investment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            _repo.Remove(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Investimento>> GetAllWithClienteAsync()
        {
            return await _repo.GetAllWithClienteAsync();
        }

        public async Task<Investimento?> GetByIdWithClienteAsync(int id)
        {
            return await _repo.GetByIdWithClienteAsync(id);
        }

        public async Task<IEnumerable<Investimento>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Investimento?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Investimento>> SearchAsync(string? nome, string? tipo, decimal? qtdeMin, Perfil? risco)
        {
            return await _repo.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(int id, CriaInvestimentoDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.NomeInvestimento = dto.NomeInvestimento;
            existing.ValorAplicado = dto.ValorAplicado;
            existing.DataAplicacao = DateTime.Now;

            if (dto.ClienteId != 0 && dto.ClienteId != existing.ClienteId)
            {
                var novoCliente = await _repoCliente.GetByIdAsync(dto.ClienteId);
                if (novoCliente == null) return false; 
                existing.ClienteId = dto.ClienteId;
                existing.Cliente = novoCliente;
            }

            _repo.Update(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

    }
}
