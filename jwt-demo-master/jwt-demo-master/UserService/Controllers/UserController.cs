using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserService.Helpers;
using UserService.Model;
using UserService.Repository;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User u)
        {
            _repo.AddUser(u);
            return Ok();
        }
        [HttpPost]
        [Route("validate")]
        public IActionResult Validate([FromBody] User u)
        {
            TokenResponse tr = new TokenResponse();
            if (_repo.ValidateUser(u))
            {               
                tr.Status = "success";
                tr.Token = new TokenHelper().GenerateToken(u);
                return Ok(tr);
            }
            tr.Status = "error";
            return BadRequest(tr);
        }

    }
}
