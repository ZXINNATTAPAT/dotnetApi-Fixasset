using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AssetsContext _context;

        public UsersController(AssetsContext context)
        {
            _context = context;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<Users> CreateUser(Users user)
        {
            // Hash the password before saving to the database
            user.HashPassword();

            _context.Users?.Add(user);
            _context.SaveChanges();

            Response.Headers["Cache-Control"] = "no-cache";

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<Users> GetUser(int id)
        {
            var user = _context.Users?.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        [ResponseCache(Duration = 500, Location = ResponseCacheLocation.Client)] 
        public ActionResult<IEnumerable<Users>> GetUser()
        {
            var users = _context.Users?.ToList();

            if (users?.Count == 0)
            {
                return NotFound();
            }

            return users;
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Users user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            Response.Headers["Cache-Control"] = "no-cache";

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users?.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users?.Remove(user);
            _context.SaveChanges();

            Response.Headers["Cache-Control"] = "no-cache";

            return NoContent();
        }
    }
}
