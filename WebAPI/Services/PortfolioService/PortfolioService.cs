using IssaPortfolio.Library;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        private readonly DataContext _context;

        public PortfolioService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<PortfolioItem>> GetPortfolioItems()
        {
            return await _context.PortfolioItems.ToListAsync();
        }
        public async Task CreatePortfolioItem(PortfolioItem item)
        {
            await _context.PortfolioItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
