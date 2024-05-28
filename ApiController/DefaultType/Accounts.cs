using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AccountsController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public ActionResult<IEnumerable<Accounts>> GetAccounts()
        {
            return _context.Accounts?.ToList();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public ActionResult<Accounts> GetAccounts(int id)
        {
            var account = _context.Accounts?.Find(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }


        // POST: api/Accounts
        [HttpPost]
        public ActionResult<Accounts> PostAccounts(Accounts account)
        {
            _context.Accounts?.Add(account);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAccounts), new { id = account.Id }, account);
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public IActionResult PutAccounts(int id, Accounts account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccounts(int id)
        {
            var account = _context.Accounts?.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts?.Remove(account);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
