using IssaPortfolio.Library;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services.PortfolioService
{
    public class PortfolioService
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
        public async Task DeletePortfolioItem(int id)
        {
            PortfolioItem? item = _context.PortfolioItems.Where(x => x.Id == id).FirstOrDefault();
            _context.PortfolioItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
