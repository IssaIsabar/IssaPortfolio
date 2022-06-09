using IssaPortfolio.Library;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<PortfolioItem>? PortfolioItems { get; set; }
        public DbSet<PortfolioItemDetails>? PortfolioItemDetails { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
