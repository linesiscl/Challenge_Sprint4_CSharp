using sprint4.dto;
using sprint4.model;


namespace sprint4.service
{
    public interface IServiceInvest
    {
        Task<IEnumerable<Investimento>> GetAllAsync();
        Task<Investimento?> GetByIdAsync(int id);
        Task<IEnumerable<Investimento>> SearchAsync(string? nome, string? tipo, decimal? qtdeMin, Perfil? risco);
        Task<Investimento> CreateAsync(Investimento investment);
        Task<bool> UpdateAsync(int id, CriaInvestimentoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Investimento>> GetAllWithClienteAsync(); 
        Task<Investimento?> GetByIdWithClienteAsync(int id);
        Task<Investimento?> CreateForClienteAsync(CriaInvestimentoDTO dto);
    }
}
