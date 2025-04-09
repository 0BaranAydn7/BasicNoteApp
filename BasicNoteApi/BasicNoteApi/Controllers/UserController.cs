using Microsoft.AspNetCore.Mvc;
using BasicNoteApi.Data;
using BasicNoteApi.Models;

namespace BasicNoteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if (existingUser != null)
                return BadRequest("Kullanıcı adı zaten kayıtlı!");

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (existingUser == null)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre!");

            return Ok(existingUser);
        }
    }
}
