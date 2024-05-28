// using JWTLoginAuthenticationAuthorization.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using WebApplication1.Models;

// namespace JWTLoginAuthenticationAuthorization.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         //For admin Only
//         [HttpGet]
//         [Route("Admins")]
//         [Authorize(Roles = "Admin")]
//         public IActionResult AdminEndPoint()
//         {
//             var currentUser = GetCurrentUser();
//             return Ok($"Hi you are an {currentUser.Roles}");
//         }
//         private Users GetCurrentUser()
//         {
//             var identity = HttpContext.User.Identity as ClaimsIdentity;
//             if (identity != null)
//             {
//                 var userClaims = identity.Claims;
//                 return new Users
//                 {
//                     Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
//                     Roles = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
//                 };
//             }
//             return null;
//         }
//     }
// }