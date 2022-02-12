using IssaPortfolio.Library;


namespace IssaPortfolio.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task LoadPortfolioItems();
        Task AddPortfolioItem(string name, string desc, string imgUrl);
        List<PortfolioItem> PortfolioItems { get; set; }

    }
}
