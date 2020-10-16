using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("/token")]
    [ApiController]
    public class TokenController : Controller
    {
        private IRepository<User> repository;
        private IAuthenticationHelper authenticationHelper;




        public TokenController(IRepository<User> repos, IAuthenticationHelper authHelper)
        {
            repository = repos;
            authenticationHelper = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = repository.GetAll().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!model.Password.Equals(user.Password))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }
    }
}
