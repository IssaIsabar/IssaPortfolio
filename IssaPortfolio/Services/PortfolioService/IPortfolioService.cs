using IssaPortfolio.Library;


namespace IssaPortfolio.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<List<PortfolioItem>?> LoadPortfolioItems();
        Task DeleteItem(int id);
        Task AddPortfolioItem(string name, string desc, string imgUrl);

    }
}
