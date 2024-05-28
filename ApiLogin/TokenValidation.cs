using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace JWTLoginAuthenticationAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenValidationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TokenValidationController(IConfiguration config)
        {
            _config = config;
        }

        [Authorize]
        [HttpGet("validate")]
        public IActionResult ValidateToken()
        {
            var jwtToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized();
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

                var expirationDate = token?.ValidTo;

                if (expirationDate.HasValue && expirationDate.Value > DateTime.UtcNow)
                {
                    return Ok("Token is valid and active.");
                }
                else
                {
                    return Unauthorized("Token has expired.");
                }
            }
            catch (Exception)
            {
                return Unauthorized("Invalid token.");
            }
        }
    }
}
