using Microsoft.EntityFrameworkCore;
using sprint4.data;
using sprint4.model;


namespace sprint4.repository
{
    public class RepositorioInvest : Repositorio<Investimento>
    {
        private readonly AppDbContext _context;

        public RepositorioInvest(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investimento>> GetAllWithClienteAsync()
        {
            return await _context.Investimento
                                 .Include(i => i.Cliente)
                                 .ToListAsync();
        }

        public async Task<Investimento?> GetByIdWithClienteAsync(int id)
        {
            return await _context.Investimento
                                 .Include(i => i.Cliente)
                                 .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
