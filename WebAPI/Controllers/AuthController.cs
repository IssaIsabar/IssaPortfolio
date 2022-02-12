using IssaPortfolio.Library;
using WebAPI.Services.PortfolioService;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpGet]
        [Route("getuser")]
        public async Task<IActionResult> GetUser()
        {
            var user = new
            {
                username = "Issa",
                email = "issa@hotmail.com"
            };

            return Ok(user);
        }


        [HttpPost]
        [Route("postuser/{name}")]
        public async Task<IActionResult> SaveUser([FromRoute] string name)
        {

            if (name.Equals("issa"))
            {

                var item = new PortfolioItem("New Item", "hello this is my first item", "https://image.jpg");

                return StatusCode(321, item);

            }
            else
            {
                return Unauthorized("You are not Issa");
            }

        }


        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {

            var x = model;

            return Ok();

        }




    }
}
