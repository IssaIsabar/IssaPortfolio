using IssaPortfolio.Library;


namespace WebAPI.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<List<PortfolioItem>> GetPortfolioItems();
        Task CreatePortfolioItem(PortfolioItem item);


    }
}
