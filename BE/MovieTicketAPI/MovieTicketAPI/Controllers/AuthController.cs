using Microsoft.AspNetCore.Mvc;
using MovieTicketAPI.Data;
using MovieTicketAPI.Models;
using System.Linq;

namespace MovieTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            // Generate a token (here we are using a dummy token for simplicity)
            var token = "dummy-jwt-token";

            return Ok(new { token });
        }
    }
}
