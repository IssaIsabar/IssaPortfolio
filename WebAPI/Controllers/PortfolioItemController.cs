using Microsoft.AspNetCore.Http;
using IssaPortfolio.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.PortfolioService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioItemController : ControllerBase
    {
        private readonly PortfolioService _portfolioService;
        public PortfolioItemController(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        [Route("getitems")]
        public async Task<ActionResult<List<PortfolioItem>>> GetPortfolioItems()
        {
            return Ok(await _portfolioService.GetPortfolioItems());
        }

        [HttpPost]
        [Route("postportfolio")]
        public async Task CreatePortfolioItem(PortfolioItem portfolioItem)
        {
            await _portfolioService.CreatePortfolioItem(portfolioItem);
        }

        [HttpDelete]
        [Route("deletePortfolio/{id}")]
        public async Task<IActionResult> DeletePortfolioItem([FromRoute] string id)
        {
            await _portfolioService.DeletePortfolioItem(id);
            return Ok();
        }

    }
}
