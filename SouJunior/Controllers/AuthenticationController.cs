using Microsoft.AspNetCore.Mvc;
using SouJunior.Service.Dtos;
using SouJunior.Service.Interfaces;
using System.Threading.Tasks;

namespace SouJunior.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthenticationController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (login == null)
                return NotFound();

            return Ok(await _auth.AuthenticateUser(login));
        }
    }
}
