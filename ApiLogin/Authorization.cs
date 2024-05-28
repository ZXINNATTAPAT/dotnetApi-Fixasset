using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace JWTLoginAuthenticationAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authorization : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AssetsContext _context;

        public Authorization(IConfiguration config, AssetsContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("User not found or invalid credentials.");
        }

        // To generate token
        private string GenerateToken(Users user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // สร้าง Claim ให้กับข้อมูลเพิ่มเติมที่ต้องการใส่ลงใน Token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.Roles),
               
                new Claim("prefix", user.prefix),
                new Claim("Sname", user.Sname),
                new Claim("Lname", user.Lname),
                
                new Claim("affiliation", user.affiliation),
                new Claim("position", user.position),
                new Claim("positiontype", user.positiontype),
                new Claim("workgroup", user.workgroup),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1440), // เซตไป 24*60*3
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // To authenticate user
        private async Task<Users> Authenticate(UserLogin userLogin)
        {
            var hashedPassword = HashPassword(userLogin.Password);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userLogin.Username && u.Password == hashedPassword);
            return user;
        }
    }
}
